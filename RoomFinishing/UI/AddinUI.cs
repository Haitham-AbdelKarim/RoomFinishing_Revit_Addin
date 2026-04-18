using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.UI;
using RoomFinishing.RoomFinishing;
using RoomFinishing.RoomFinishing.CeilingFinishing;
using RoomFinishing.RoomFinishing.FloorFinishing;
using RoomFinishing.RoomFinishing.WallFinishing;
using Form = System.Windows.Forms.Form;

namespace RoomFinishing.UI
{
    /// <summary>
    /// Main UI form for managing Room Finishing operations.
    /// Allows users to select rooms and apply wall, ceiling, and floor finishes.
    /// </summary>
    public partial class AddinUI : Form
    {
        private UIDocument uiDoc;
        private Document doc;
        private BindingSource bindingSource = new BindingSource();

        private WallFinishingHandler wallFinishingHandler;
        private ExternalEvent wallFinishingEvent;

        private CeilingFinishingHandler ceilingFinishingHandler;
        private ExternalEvent ceilingFinishingEvent;

        private FloorFinishingHandler floorFinishingHandler;
        private ExternalEvent floorFinishingEvent;

        /// <summary>
        /// Initializes the Room Finishing UI and populates controls with Revit context data.
        /// </summary>
        /// <param name="uiDoc">The active Revit UI document.</param>
        /// <param name="doc">The active Revit database document.</param>
        public AddinUI(UIDocument uiDoc, Document doc)
        {
            InitializeComponent();
            this.uiDoc = uiDoc;
            this.doc = doc;

            // Initialize handlers and external events for model-safe execution
            wallFinishingHandler = new WallFinishingHandler();
            wallFinishingEvent = ExternalEvent.Create(wallFinishingHandler);

            ceilingFinishingHandler = new CeilingFinishingHandler();
            ceilingFinishingEvent = ExternalEvent.Create(ceilingFinishingHandler);

            floorFinishingHandler = new FloorFinishingHandler();
            floorFinishingEvent = ExternalEvent.Create(floorFinishingHandler);

            // Retrieve rooms from the model
            List<Room> rooms = RoomsRetrieving.GetAllRooms(doc);

            // Configure room list UI bindings
            roomsCheckedListBox.DisplayMember = "Name";
            roomsCheckedListBox.ValueMember = "Id";

            // Add rooms to the checked list
            foreach (Room room in rooms)
                roomsCheckedListBox.Items.Add(room);

            // Load and bind available wall types for finishing selection
            List<WallType> wallTypeList = new FilteredElementCollector(doc).OfClass(typeof(WallType)).Cast<WallType>().ToList();
            wallTypeComboBox.DisplayMember = "Name";
            skirtingTypeComboBox.DisplayMember = "Name";

            foreach (WallType wallType in wallTypeList)
            {
                wallTypeComboBox.Items.Add(wallType);
                skirtingTypeComboBox.Items.Add(wallType);
            }

            wallTypeComboBox.SelectedIndex = 0;
            skirtingTypeComboBox.SelectedIndex = 0;

            // Load and bind ceiling types
            List<CeilingType> ceilingTypeList = new FilteredElementCollector(doc).OfClass(typeof(CeilingType)).Cast<CeilingType>().ToList();
            ceilingTypeComboBox.DisplayMember = "Name";

            foreach (CeilingType ceilingType in ceilingTypeList)
                ceilingTypeComboBox.Items.Add(ceilingType);

            ceilingTypeComboBox.SelectedIndex = 0;

            // Load and bind floor types
            List<FloorType> floorTypeList = new FilteredElementCollector(doc).OfClass(typeof(FloorType)).Cast<FloorType>().ToList();
            FloorTypeComboBox.DisplayMember = "Name";

            foreach (FloorType floorType in floorTypeList)
                FloorTypeComboBox.Items.Add(floorType);

            FloorTypeComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Allows the user to graphically select rooms in the active view.
        /// </summary>
        private void selectRoomsButton_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Use RoomsRetrieving to select rooms via Revit UI
            List<Room> selectedRooms = RoomsRetrieving.SelectRoomsFromView(uiDoc);

            this.Show();

            // Automatically check selected rooms in the list
            foreach (Room room in selectedRooms)
            {
                for (int i = 0; i < roomsCheckedListBox.Items.Count; i++)
                {
                    Room listItem = (Room)roomsCheckedListBox.Items[i];
                    if (listItem.Id == room.Id)
                    {
                        roomsCheckedListBox.SetItemChecked(i, true);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Clears selected rooms in the rooms list.
        /// </summary>
        private void clearSelectedRoombutton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < roomsCheckedListBox.Items.Count; i++)
                roomsCheckedListBox.SetItemChecked(i, false);
        }

        /// <summary>
        /// Retrieves only rooms checked by the user.
        /// </summary>
        private List<Room> GetSelectedRooms()
        {
            List<Room> selectedRooms = new List<Room>();
            foreach (Room room in roomsCheckedListBox.CheckedItems)
                selectedRooms.Add(room);

            return selectedRooms;
        }

        /// <summary>
        /// Applies wall finishing to selected rooms.
        /// </summary>
        private void wallFinishButton_Click(object sender, EventArgs e)
        {
            List<Room> rooms = GetSelectedRooms();
            if (rooms.Count == 0)
            {
                MessageBox.Show("Please Select a room");
                return;
            }

            // Pass handler execution context
            wallFinishingHandler.Doc = this.doc;
            wallFinishingHandler.Rooms = rooms;
            wallFinishingHandler.WallType = wallTypeComboBox.SelectedItem as WallType;
            wallFinishingHandler.IsSkirting = false;
            wallFinishingHandler.SkirtingHeight = 0;

            wallFinishingEvent.Raise();
            MessageBox.Show("Done");
        }

        /// <summary>
        /// Applies ceiling finishing to selected rooms.
        /// </summary>
        private void ceilingFinishingButton_Click(object sender, EventArgs e)
        {
            List<Room> rooms = GetSelectedRooms();
            if (rooms.Count == 0)
            {
                MessageBox.Show("Please Select a room");
                return;
            }

            ceilingFinishingHandler.Doc = this.doc;
            ceilingFinishingHandler.Rooms = rooms;
            ceilingFinishingHandler.CeilingType = ceilingTypeComboBox.SelectedItem as CeilingType;

            ceilingFinishingEvent.Raise();
            MessageBox.Show("Done");
        }

        /// <summary>
        /// Applies floor finishing to selected rooms.
        /// </summary>
        private void floorFinishingButton_Click(object sender, EventArgs e)
        {
            List<Room> rooms = GetSelectedRooms();
            if (rooms.Count == 0)
            {
                MessageBox.Show("Please Select a room");
                return;
            }

            floorFinishingHandler.Doc = this.doc;
            floorFinishingHandler.Rooms = rooms;
            floorFinishingHandler.FloorType = FloorTypeComboBox.SelectedItem as FloorType;

            floorFinishingEvent.Raise();
            MessageBox.Show("Done");
        }

        /// <summary>
        /// Displays usage information for the add-in.
        /// </summary>
        private void informationButton_Click(object sender, EventArgs e)
        {
            string msg = "Please check the boundary of the room and its height to make the addin work correctly";
            MessageBox.Show(msg);
        }

        /// <summary>
        /// Applies skirting finishing to selected rooms.
        /// </summary>
        private void skirtingFinishingButton_Click(object sender, EventArgs e)
        {
            List<Room> rooms = GetSelectedRooms();
            if (rooms.Count == 0)
            {
                MessageBox.Show("Please Select a room");
                return;
            }

            wallFinishingHandler.Doc = this.doc;
            wallFinishingHandler.Rooms = rooms;
            wallFinishingHandler.WallType = skirtingTypeComboBox.SelectedItem as WallType;

            // Validate skirting height input
            if (!double.TryParse(skirtingHeightTextBox.Text, out double height))
            {
                MessageBox.Show("Please Enter a valid number");
                return;
            }

            // Convert from mm to feet
            wallFinishingHandler.IsSkirting = true;
            wallFinishingHandler.SkirtingHeight = height * 0.0032808399;

            wallFinishingEvent.Raise();
            MessageBox.Show("Done");
        }

        /// <summary>
        /// Opens LinkedIn profile in browser.
        /// </summary>
        private void linkedinButton_Click(object sender, EventArgs e)
        {
            string url = "https://www.linkedin.com/in/mostafa-abdelkarim-b152b125a/";
            try { Process.Start(new ProcessStartInfo(url) { UseShellExecute = true }); }
            catch (Exception ex) { MessageBox.Show("Cannot open browser: " + ex.Message); }
        }
    }
}
