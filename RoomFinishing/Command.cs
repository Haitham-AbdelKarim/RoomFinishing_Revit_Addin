using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using RoomFinishing.UI;
using RoomFinishing.RoomFinishing.WallFinishing;
using RoomFinishing.RoomFinishing.CeilingFinishing;

namespace RoomFinishing
{
    /// <summary>
    /// External command entry point for launching the RoomFinishing UI.
    /// </summary>
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        /// <summary>
        /// Executes the RoomFinishing command.
        /// Initializes and displays the user interface.
        /// </summary>
        /// <param name="commandData">Provides access to the Revit application and UI environment.</param>
        /// <param name="message">Error message output if the command fails.</param>
        /// <param name="elements">Elements associated with a failure, if applicable.</param>
        /// <returns>
        /// Returns <see cref="Result.Succeeded"/> when the UI is successfully displayed.
        /// </returns>
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // Access the active Revit UI document (context where user is working)
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;

            // Access the underlying DB document representing the model
            Document doc = uiDoc.Document;

            // Instantiate the main add-in UI, passing project context
            AddinUI ui = new AddinUI(uiDoc, doc);

            // Keep UI window on top of Revit for convenience
            ui.TopMost = true;

            // Show the RoomFinishing UI form
            ui.Show();

            return Result.Succeeded;
        }
    }
}
