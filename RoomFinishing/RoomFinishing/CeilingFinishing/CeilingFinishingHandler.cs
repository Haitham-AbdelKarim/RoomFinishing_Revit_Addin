using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;

namespace RoomFinishing.RoomFinishing.CeilingFinishing
{
    /// <summary>
    /// Handles execution of the Ceiling Finishing operation via a Revit ExternalEvent.
    /// Allows ceilings to be safely created in the Revit model from a UI thread.
    /// </summary>
    public class CeilingFinishingHandler : IExternalEventHandler
    {
        /// <summary>
        /// The active Revit document where ceiling finishing will be applied.
        /// </summary>
        public Document Doc;

        /// <summary>
        /// Rooms selected by the user to apply ceiling finishing to.
        /// </summary>
        public List<Room> Rooms;

        /// <summary>
        /// Ceiling type to use when creating ceiling finishes.
        /// </summary>
        public CeilingType CeilingType;

        /// <summary>
        /// Executes the ceiling finishing logic when the external event is triggered.
        /// Runs inside a Revit transaction.
        /// </summary>
        /// <param name="app">Active Revit UIApplication context.</param>
        public void Execute(UIApplication app)
        {
            // Revit document changes must occur inside a transaction
            using (Transaction t = new Transaction(Doc, "Ceiling Finishing"))
            {
                t.Start();

                // Main logic call: create ceiling finishes for the selected rooms
                CeilingFinishing.CeilingFinish(Doc, Rooms, CeilingType);

                t.Commit();
            }
        }

        /// <summary>
        /// Provides a friendly name for this external event handler.
        /// </summary>
        /// <returns>String name identifying the handler.</returns>
        public string GetName() => "Ceiling Finishing";
    }
}
