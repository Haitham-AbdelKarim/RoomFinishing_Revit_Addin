using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;

namespace RoomFinishing
{
    /// <summary>
    /// Main application class responsible for initializing the RoomFinishing add-in UI.
    /// Handles Revit startup and shutdown events.
    /// </summary>
    public class App : IExternalApplication
    {
        /// <summary>
        /// Creates the RoomFinishing ribbon tab, panel, and button in the Revit UI.
        /// </summary>
        /// <param name="app">The Revit controlled application instance.</param>
        /// <returns>Returns <see cref="Result.Succeeded"/> on successful UI setup.</returns>
        public static Result Run(UIControlledApplication app)
        {
            string tabName = "KAITECH-BD-R09";

            // Attempt to create custom ribbon tab; ignore if it already exists
            try { app.CreateRibbonTab(tabName); } catch { }

            // Create a ribbon panel under the custom tab
            RibbonPanel panel = app.CreateRibbonPanel(tabName, "Architecture");

            // Create button data for executing the RoomFinishing command
            PushButtonData btnData = new PushButtonData(
                "RoomFinishing",     // Unique internal button name
                "RoomFinishing",     // Text displayed on the button
                Assembly.GetExecutingAssembly().Location, // Path of the add-in assembly
                "RoomFinishing.Command"); // Entry point class for the button command

            // Add the button to the panel
            PushButton button = panel.AddItem(btnData) as PushButton;

            // Assign large icon for better visibility in the UI
            button.LargeImage = GetImageSource("RoomFinishing.Resources.AddinIcon.png");

            return Result.Succeeded;
        }

        /// <summary>
        /// Executes when Revit is shutting down.
        /// </summary>
        /// <param name="app">The Revit controlled application instance.</param>
        /// <returns>Returns <see cref="Result.Succeeded"/>.</returns>
        public Result OnShutdown(UIControlledApplication app)
        {
            // No cleanup operations required for this add-in
            return Result.Succeeded;
        }

        /// <summary>
        /// Executes when Revit starts up. Initializes the add-in UI.
        /// </summary>
        /// <param name="app">The Revit controlled application instance.</param>
        /// <returns>Returns <see cref="Result.Succeeded"/> after initialization.</returns>
        public Result OnStartup(UIControlledApplication app)
        {
            return Run(app);
        }

        /// <summary>
        /// Retrieves an embedded resource image to use as a button icon.
        /// </summary>
        /// <param name="imageFullName">Full resource name of the image within the assembly.</param>
        /// <returns>Returns an <see cref="ImageSource"/> representing the icon.</returns>
        private static ImageSource GetImageSource(string imageFullName)
        {
            // Load the embedded image stream from assembly resources
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(imageFullName);

            // Decode the PNG image for use in WPF-based Revit UI
            PngBitmapDecoder decoder = new PngBitmapDecoder(
                stream,
                BitmapCreateOptions.PreservePixelFormat,
                BitmapCacheOption.Default);

            // Return the first frame as an ImageSource
            return decoder.Frames[0];
        }
    }
}
