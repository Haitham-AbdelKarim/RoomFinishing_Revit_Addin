using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;

namespace RoomFinishing.RoomFinishing.FloorFinishing
{
    /// <summary>
    /// Handles execution of the Floor Finishing operation via a Revit ExternalEvent.
    /// Allows floor elements to be safely created in the Revit model from a UI thread.
    /// </summary>
    public class FloorFinishingHandler : IExternalEventHandler
    {
        /// <summary>
        /// The active Revit document where floor finishing will be applied.
        /// </summary>
        public Document Doc;

        /// <summary>
        /// Rooms selected by the user to apply floor finishing to.
        /// </summary>
        public List<Room> Rooms;

        /// <summary>
        /// Floor type to use when creating floor finishes.
        /// </summary>
        public FloorType FloorType;

        /// <summary>
        /// Executes the floor finishing logic when the external event is triggered.
        /// Runs inside a Revit transaction.
        /// </summary>
        /// <param name="app">Active Revit UIApplication context.</param>
        public void Execute(UIApplication app)
        {
            // Revit document changes must occur within a transaction
            using (Transaction t = new Transaction(Doc, "Floor Finishing"))
            {
                t.Start();

                // Main logic call: create floor finishes for the selected rooms
                FloorFinishing.FlootFinish(Doc, Rooms, FloorType);

                t.Commit();
            }
        }

        /// <summary>
        /// Provides a friendly name for this external event handler.
        /// </summary>
        /// <returns>String name identifying the handler.</returns>
        public string GetName() => "Floor Finishing";
    }
}
