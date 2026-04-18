using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;

namespace RoomFinishing.RoomFinishing.WallFinishing
{
    /// <summary>
    /// Handles execution of the Wall Finishing operation through an external Revit event.
    /// This allows UI threads to safely trigger Revit API actions such as creating
    /// wall finishes and optional skirting around the selected rooms.
    /// </summary>
    public class WallFinishingHandler : IExternalEventHandler
    {
        /// <summary>
        /// The active Revit document where the wall finishing will be created.
        /// </summary>
        public Document Doc;

        /// <summary>
        /// Rooms selected by the user to apply wall finishing to.
        /// </summary>
        public List<Room> Rooms;

        /// <summary>
        /// Wall type that will be used for generating internal room finishes.
        /// </summary>
        public WallType WallType;

        /// <summary>
        /// Indicates whether be wall or skirting finishing.
        /// </summary>
        public bool IsSkirting;

        /// <summary>
        /// The height of the skirting in Revit internal units (feet).
        /// Only used when <see cref="IsSkirting"/> is true.
        /// </summary>
        public double SkirtingHeight;

        /// <summary>
        /// Executes the handler logic when triggered by a Revit ExternalEvent.
        /// This runs inside a transaction so that Revit can modify the document.
        /// </summary>
        /// <param name="app">The active Revit UIApplication context.</param>
        public void Execute(UIApplication app)
        {
            // Revit document changes must always happen inside a Transaction
            using (Transaction t = new Transaction(Doc, "Wall Finishing"))
            {
                t.Start();

                // Main logic call (contained in WallFinishing class)
                WallFinishing.WallFinish(Doc, Rooms, WallType, IsSkirting, SkirtingHeight);

                t.Commit();
            }
        }

        /// <summary>
        /// Provides a friendly name for this external event handler.
        /// This name appears in debugging and event contexts.
        /// </summary>
        /// <returns>String label identifying this handler.</returns>
        public string GetName() => "Wall Finishing";
    }
}
