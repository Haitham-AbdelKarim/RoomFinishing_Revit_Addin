using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;

namespace RoomFinishing.RoomFinishing.WallFinishing
{
    /// <summary>
    /// Provides methods for creating wall finishes and optional skirting around rooms.
    /// </summary>
    public static class WallFinishing
    {
        /// <summary>
        /// Generates wall finishing for a list of rooms.
        /// Can optionally create skirting walls at the bottom of walls.
        /// </summary>
        /// <param name="doc">The active Revit document.</param>
        /// <param name="rooms">List of rooms to apply wall finishing to.</param>
        /// <param name="wallType">Wall type to use for the finishing.</param>
        /// <param name="IsSkirting">If true, only creates a skirting at the specified height.</param>
        /// <param name="SkirtingHeight">Height of the skirting wall in Revit internal units (feet).</param>
        public static void WallFinish(Document doc, List<Room> rooms, WallType wallType, bool IsSkirting, double SkirtingHeight)
        {
            foreach (Room room in rooms)
            {
                // Configure boundary calculation to use the finished face
                SpatialElementBoundaryOptions options = new SpatialElementBoundaryOptions
                {
                    SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish
                };

                // Determine wall height: full room height or skirting height
                double wallHeight = IsSkirting
                    ? SkirtingHeight
                    : room.get_Parameter(BuiltInParameter.ROOM_HEIGHT).AsDouble();

                // Retrieve room boundary segments
                IList<IList<BoundarySegment>> boundary = room.GetBoundarySegments(options);

                foreach (IList<BoundarySegment> loop in boundary)
                {
                    foreach (BoundarySegment segment in loop)
                    {
                        // Get the curve (geometry) of the segment
                        Curve curve = segment.GetCurve();

                        // Offset curve by half the wall thickness to align the finish correctly
                        double thickness = wallType.get_Parameter(BuiltInParameter.WALL_ATTR_WIDTH_PARAM).AsDouble();
                        curve = curve.CreateOffset((-thickness) / 2, XYZ.BasisZ);

                        // Identify the existing wall that forms this room boundary (if any)
                        ElementId elementId = segment.ElementId;
                        Wall wallElement = doc.GetElement(elementId) as Wall;

                        if (wallElement != null && wallType != null)
                        {
                            // Create the finishing wall
                            Wall finishWall = Wall.Create(doc, curve, wallType.Id, room.LevelId, wallHeight, 0, false, false);

                            // Set wall location line to finish face interior
                            Parameter locLine = finishWall.get_Parameter(BuiltInParameter.WALL_KEY_REF_PARAM);
                            locLine.Set((int)WallLocationLine.FinishFaceInterior);

                            // Join geometry to the existing wall for clean intersections
                            JoinGeometryUtils.JoinGeometry(doc, finishWall, wallElement);
                        }
                    }
                }
            }
        }
    }
}
