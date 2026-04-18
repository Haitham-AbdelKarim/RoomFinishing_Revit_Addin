using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;

namespace RoomFinishing.RoomFinishing.CeilingFinishing
{
    /// <summary>
    /// Provides methods for creating ceiling finishes in rooms.
    /// </summary>
    public static class CeilingFinishing
    {
        /// <summary>
        /// Generates ceiling elements for the specified rooms using the selected ceiling type.
        /// </summary>
        /// <param name="doc">The active Revit document.</param>
        /// <param name="rooms">List of rooms to create ceiling finishes for.</param>
        /// <param name="ceilingType">The ceiling type to apply for the finishes.</param>
        public static void CeilingFinish(Document doc, List<Room> rooms, CeilingType ceilingType)
        {
            foreach (Room room in rooms)
            {
                // Configure boundary calculation to use the finished face of the room
                SpatialElementBoundaryOptions options = new SpatialElementBoundaryOptions
                {
                    SpatialElementBoundaryLocation = SpatialElementBoundaryLocation.Finish
                };

                // Get the offset from the upper limit of the room
                double roomLimitOffset = room.get_Parameter(BuiltInParameter.ROOM_UPPER_OFFSET).AsDouble();

                // Determine ceiling thickness from compound structure or parameter
                CompoundStructure structure = ceilingType.GetCompoundStructure();
                double ceilingThickness = 0;

                if (structure != null)
                {
                    ceilingThickness = structure.GetWidth();
                }
                else
                {
                    Parameter p = ceilingType.get_Parameter(BuiltInParameter.CEILING_THICKNESS);
                    if (p != null)
                        ceilingThickness = p.AsDouble();
                }

                // Final offset from level for ceiling placement
                double finalHeightOffset = roomLimitOffset - ceilingThickness;

                // Retrieve boundary loops for the room
                IList<IList<BoundarySegment>> boundary = room.GetBoundarySegments(options);
                List<CurveLoop> ceilingLoops = new List<CurveLoop>();

                foreach (IList<BoundarySegment> loop in boundary)
                {
                    CurveLoop curveLoop = new CurveLoop();

                    foreach (BoundarySegment segment in loop)
                        curveLoop.Append(segment.GetCurve());

                    ceilingLoops.Add(curveLoop);
                }

                // Create the ceiling element
                Ceiling newCeiling = Ceiling.Create(doc, ceilingLoops, ceilingType.Id, room.LevelId);

                // Set the "Height Offset from Level" parameter
                Parameter heightParam = newCeiling.get_Parameter(BuiltInParameter.CEILING_HEIGHTABOVELEVEL_PARAM);
                if (heightParam != null)
                {
                    heightParam.Set(finalHeightOffset);
                }
            }
        }
    }
}
