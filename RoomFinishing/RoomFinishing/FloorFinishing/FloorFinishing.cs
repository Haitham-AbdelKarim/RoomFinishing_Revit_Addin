using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;

namespace RoomFinishing.RoomFinishing.FloorFinishing
{
    /// <summary>
    /// Provides methods for creating floor finishes in rooms.
    /// </summary>
    public static class FloorFinishing
    {
        /// <summary>
        /// Generates floor elements for the specified rooms using the selected floor type.
        /// </summary>
        /// <param name="doc">The active Revit document.</param>
        /// <param name="rooms">List of rooms to create floor finishes for.</param>
        /// <param name="floorType">The floor type to apply for the finishes.</param>
        public static void FlootFinish(Document doc, List<Room> rooms, FloorType floorType)
        {
            foreach (Room room in rooms)
            {
                // Configure boundary calculation to use the finished face of the room
                SpatialElementBoundaryOptions options = new SpatialElementBoundaryOptions
                {
                    SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish
                };

                // Retrieve room boundary loops
                IList<IList<BoundarySegment>> boundary = room.GetBoundarySegments(options);

                List<CurveLoop> floorLoops = new List<CurveLoop>();

                // Convert boundary segments to CurveLoop objects for Floor.Create
                foreach (IList<BoundarySegment> loop in boundary)
                {
                    CurveLoop curveLoop = new CurveLoop();

                    foreach (BoundarySegment segment in loop)
                        curveLoop.Append(segment.GetCurve());

                    floorLoops.Add(curveLoop);
                }

                // Create floor element based on boundary loops and floor type
                Floor newFloor = Floor.Create(doc, floorLoops, floorType.Id, room.LevelId);

                // Set the "Height Offset from Level" parameter
                Parameter offsetParam = newFloor.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM);
                if (offsetParam != null)
                {
                    // For finishes, usually we set the offset to 0 so the floor sits at the level
                    offsetParam.Set(0.0);
                }
            }
        }
    }
}
