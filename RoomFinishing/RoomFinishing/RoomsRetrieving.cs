using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;

namespace RoomFinishing.RoomFinishing
{
    /// <summary>
    /// Helper class for retrieving rooms from the Revit model.
    /// Provides utilities for collecting all rooms or selecting rooms from the UI.
    /// </summary>
    public static class RoomsRetrieving
    {
        /// <summary>
        /// Retrieves all room elements in the document.
        /// </summary>
        /// <param name="doc">The Revit database document.</param>
        /// <returns>List of all rooms in the project.</returns>
        public static List<Room> GetAllRooms(Document doc)
        {
            // Collect room elements in the model
            FilteredElementCollector collector = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Rooms)
                .WhereElementIsNotElementType();

            List<Room> allRooms = new List<Room>();

            // Convert elements to room instances
            foreach (Element element in collector)
            {
                Room room = element as Room;
                if (room != null)
                {
                    allRooms.Add(room);
                }
            }

            return allRooms;
        }

        /// <summary>
        /// Allows the user to graphically pick rooms in the active view.
        /// </summary>
        /// <param name="uidoc">Active UI document for selection operations.</param>
        /// <returns>List of rooms selected by the user; empty if canceled.</returns>
        public static List<Room> SelectRoomsFromView(UIDocument uidoc)
        {
            IList<Reference> refs = new List<Reference>();

            try
            {
                // Let user select room elements visually in Revit
                refs = uidoc.Selection.PickObjects(
                    ObjectType.Element,
                    "Select rooms");
            }
            catch
            {
                // User pressed ESC or selection canceled
                return new List<Room>();
            }

            // Return only items that are truly rooms
            return refs
                .Select(r => uidoc.Document.GetElement(r))
                .OfType<Room>()
                .ToList();
        }
    }
}
