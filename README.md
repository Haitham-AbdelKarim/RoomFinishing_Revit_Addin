# RoomFinishing Revit Add-In

RoomFinishing is a custom Autodesk Revit Add-in built in C#. This tool is designed to automate and streamline the process of applying and managing architectural room finishes, with specific capabilities for Wall and Ceiling finishing within Revit models.

## Features

- **Automated Finishing Layouts:** Includes dedicated modules for Wall Finishing (`WallFinishing`) and Ceiling Finishing (`CeilingFinishing`).
- **Custom Ribbon Integration:** Neatly integrates into the Revit UI under a custom ribbon tab in the `Architecture` panel.
- **Interactive UI:** Provides a dedicated, floating Graphical User Interface (`AddinUI`) to configure and launch finishing operations directly in the active document's context.

## Repository Structure

- `App.cs`: Implements the `IExternalApplication` interface. Responsible for bootstrapping the add-in on Revit startup, creating the ribbon tab, ribbon panel, and the push-button with its icon.
- `Command.cs`: Implements the `IExternalCommand` interface. Acts as the entry point when the user clicks the ribbon button, retrieving the `UIDocument` and `Document` context, and launching the `AddinUI`.
- `UI/`: Contains the forms and graphical interfaces used by the add-in.
- `RoomFinishing.addin`: The manifest file that tells Revit how to load the compiled assembly.

## Installation

1. Clone or download this project.
2. Open `RoomFinishing.sln` in Visual Studio.
3. Ensure that the project references to `RevitAPI.dll` and `RevitAPIUI.dll` are correctly pointing to the installation path of your target Revit version.
4. Build the solution.
5. Copy the compiled assembly (`RoomFinishing.dll`), any required dependencies, and the `RoomFinishing.addin` manifest file to the standard Revit Addins folder:
   - Specific User: `%APPDATA%\Autodesk\Revit\Addins\<Version>\`
   - All Users: `%PROGRAMDATA%\Autodesk\Revit\Addins\<Version>\`
6. Launch Revit. You may be prompted to "Always Load" or "Load Once" for the unsigned add-in; confirm to load it.

## Usage

1. Open a project model in Autodesk Revit.
2. Navigate to the tab on the Revit ribbon.
3. Locate the **Architecture** panel and click the **RoomFinishing** button.
4. The add-in's UI will appear floating over the Revit window. Configure your wall or ceiling finishes from the prompt and execute the routines as needed.

## Requirements

- Autodesk Revit
- .NET Framework (version depending on the target Revit API version)
- Visual Studio (for development and building)

## Demo

https://github.com/user-attachments/assets/06fb2622-7e21-4cb0-837b-8260725cb003


