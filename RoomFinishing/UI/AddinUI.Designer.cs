namespace RoomFinishing.UI
{
    partial class AddinUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddinUI));
            this.selectRoomsButton = new System.Windows.Forms.Button();
            this.roomsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.clearSelectedRoombutton = new System.Windows.Forms.Button();
            this.wallFinishButton = new System.Windows.Forms.Button();
            this.wallTypeComboBox = new System.Windows.Forms.ComboBox();
            this.wallTypeLabel = new System.Windows.Forms.Label();
            this.ceilingTypelabel = new System.Windows.Forms.Label();
            this.ceilingTypeComboBox = new System.Windows.Forms.ComboBox();
            this.ceilingFinishingButton = new System.Windows.Forms.Button();
            this.floorTypeLabel = new System.Windows.Forms.Label();
            this.FloorTypeComboBox = new System.Windows.Forms.ComboBox();
            this.floorFinishingButton = new System.Windows.Forms.Button();
            this.skirtingTypeLabel = new System.Windows.Forms.Label();
            this.skirtingTypeComboBox = new System.Windows.Forms.ComboBox();
            this.skirtingFinishingButton = new System.Windows.Forms.Button();
            this.skirtingHeightTextBox = new System.Windows.Forms.TextBox();
            this.unconnectedHeightLable = new System.Windows.Forms.Label();
            this.linkedinButton = new System.Windows.Forms.Button();
            this.informationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // selectRoomsButton
            // 
            this.selectRoomsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.selectRoomsButton.ForeColor = System.Drawing.Color.White;
            this.selectRoomsButton.Location = new System.Drawing.Point(310, 19);
            this.selectRoomsButton.Name = "selectRoomsButton";
            this.selectRoomsButton.Size = new System.Drawing.Size(255, 52);
            this.selectRoomsButton.TabIndex = 0;
            this.selectRoomsButton.Text = "Select Rooms From View";
            this.selectRoomsButton.UseVisualStyleBackColor = false;
            this.selectRoomsButton.Click += new System.EventHandler(this.selectRoomsButton_Click);
            // 
            // roomsCheckedListBox
            // 
            this.roomsCheckedListBox.BackColor = System.Drawing.Color.White;
            this.roomsCheckedListBox.ForeColor = System.Drawing.Color.Black;
            this.roomsCheckedListBox.FormattingEnabled = true;
            this.roomsCheckedListBox.Location = new System.Drawing.Point(43, 19);
            this.roomsCheckedListBox.Name = "roomsCheckedListBox";
            this.roomsCheckedListBox.Size = new System.Drawing.Size(216, 123);
            this.roomsCheckedListBox.TabIndex = 1;
            // 
            // clearSelectedRoombutton
            // 
            this.clearSelectedRoombutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.clearSelectedRoombutton.ForeColor = System.Drawing.Color.White;
            this.clearSelectedRoombutton.Location = new System.Drawing.Point(310, 90);
            this.clearSelectedRoombutton.Name = "clearSelectedRoombutton";
            this.clearSelectedRoombutton.Size = new System.Drawing.Size(255, 52);
            this.clearSelectedRoombutton.TabIndex = 2;
            this.clearSelectedRoombutton.Text = "Clear Selected Rooms";
            this.clearSelectedRoombutton.UseVisualStyleBackColor = false;
            this.clearSelectedRoombutton.Click += new System.EventHandler(this.clearSelectedRoombutton_Click);
            // 
            // wallFinishButton
            // 
            this.wallFinishButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.wallFinishButton.ForeColor = System.Drawing.Color.White;
            this.wallFinishButton.Location = new System.Drawing.Point(408, 171);
            this.wallFinishButton.Name = "wallFinishButton";
            this.wallFinishButton.Size = new System.Drawing.Size(157, 44);
            this.wallFinishButton.TabIndex = 3;
            this.wallFinishButton.Text = "Wall Finishing";
            this.wallFinishButton.UseVisualStyleBackColor = false;
            this.wallFinishButton.Click += new System.EventHandler(this.wallFinishButton_Click);
            // 
            // wallTypeComboBox
            // 
            this.wallTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.wallTypeComboBox.FormattingEnabled = true;
            this.wallTypeComboBox.Location = new System.Drawing.Point(138, 182);
            this.wallTypeComboBox.Name = "wallTypeComboBox";
            this.wallTypeComboBox.Size = new System.Drawing.Size(234, 24);
            this.wallTypeComboBox.TabIndex = 4;
            // 
            // wallTypeLabel
            // 
            this.wallTypeLabel.AutoSize = true;
            this.wallTypeLabel.ForeColor = System.Drawing.Color.White;
            this.wallTypeLabel.Location = new System.Drawing.Point(40, 185);
            this.wallTypeLabel.Name = "wallTypeLabel";
            this.wallTypeLabel.Size = new System.Drawing.Size(69, 16);
            this.wallTypeLabel.TabIndex = 5;
            this.wallTypeLabel.Text = "Wall Type";
            // 
            // ceilingTypelabel
            // 
            this.ceilingTypelabel.AutoSize = true;
            this.ceilingTypelabel.ForeColor = System.Drawing.Color.White;
            this.ceilingTypelabel.Location = new System.Drawing.Point(40, 241);
            this.ceilingTypelabel.Name = "ceilingTypelabel";
            this.ceilingTypelabel.Size = new System.Drawing.Size(83, 16);
            this.ceilingTypelabel.TabIndex = 6;
            this.ceilingTypelabel.Text = "Ceiling Type";
            // 
            // ceilingTypeComboBox
            // 
            this.ceilingTypeComboBox.FormattingEnabled = true;
            this.ceilingTypeComboBox.Location = new System.Drawing.Point(138, 238);
            this.ceilingTypeComboBox.Name = "ceilingTypeComboBox";
            this.ceilingTypeComboBox.Size = new System.Drawing.Size(234, 24);
            this.ceilingTypeComboBox.TabIndex = 7;
            // 
            // ceilingFinishingButton
            // 
            this.ceilingFinishingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.ceilingFinishingButton.ForeColor = System.Drawing.Color.White;
            this.ceilingFinishingButton.Location = new System.Drawing.Point(408, 227);
            this.ceilingFinishingButton.Name = "ceilingFinishingButton";
            this.ceilingFinishingButton.Size = new System.Drawing.Size(157, 44);
            this.ceilingFinishingButton.TabIndex = 8;
            this.ceilingFinishingButton.Text = "Ceiling Finishing";
            this.ceilingFinishingButton.UseVisualStyleBackColor = false;
            this.ceilingFinishingButton.Click += new System.EventHandler(this.ceilingFinishingButton_Click);
            // 
            // floorTypeLabel
            // 
            this.floorTypeLabel.AutoSize = true;
            this.floorTypeLabel.ForeColor = System.Drawing.Color.White;
            this.floorTypeLabel.Location = new System.Drawing.Point(40, 300);
            this.floorTypeLabel.Name = "floorTypeLabel";
            this.floorTypeLabel.Size = new System.Drawing.Size(73, 16);
            this.floorTypeLabel.TabIndex = 9;
            this.floorTypeLabel.Text = "Floor Type";
            // 
            // FloorTypeComboBox
            // 
            this.FloorTypeComboBox.FormattingEnabled = true;
            this.FloorTypeComboBox.Location = new System.Drawing.Point(138, 297);
            this.FloorTypeComboBox.Name = "FloorTypeComboBox";
            this.FloorTypeComboBox.Size = new System.Drawing.Size(234, 24);
            this.FloorTypeComboBox.TabIndex = 10;
            // 
            // floorFinishingButton
            // 
            this.floorFinishingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.floorFinishingButton.ForeColor = System.Drawing.Color.White;
            this.floorFinishingButton.Location = new System.Drawing.Point(408, 286);
            this.floorFinishingButton.Name = "floorFinishingButton";
            this.floorFinishingButton.Size = new System.Drawing.Size(157, 44);
            this.floorFinishingButton.TabIndex = 11;
            this.floorFinishingButton.Text = "Floor Finishing";
            this.floorFinishingButton.UseVisualStyleBackColor = false;
            this.floorFinishingButton.Click += new System.EventHandler(this.floorFinishingButton_Click);
            // 
            // skirtingTypeLabel
            // 
            this.skirtingTypeLabel.AutoSize = true;
            this.skirtingTypeLabel.ForeColor = System.Drawing.Color.White;
            this.skirtingTypeLabel.Location = new System.Drawing.Point(40, 361);
            this.skirtingTypeLabel.Name = "skirtingTypeLabel";
            this.skirtingTypeLabel.Size = new System.Drawing.Size(86, 16);
            this.skirtingTypeLabel.TabIndex = 13;
            this.skirtingTypeLabel.Text = "Skirting Type";
            // 
            // skirtingTypeComboBox
            // 
            this.skirtingTypeComboBox.FormattingEnabled = true;
            this.skirtingTypeComboBox.Location = new System.Drawing.Point(138, 358);
            this.skirtingTypeComboBox.Name = "skirtingTypeComboBox";
            this.skirtingTypeComboBox.Size = new System.Drawing.Size(234, 24);
            this.skirtingTypeComboBox.TabIndex = 14;
            // 
            // skirtingFinishingButton
            // 
            this.skirtingFinishingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.skirtingFinishingButton.ForeColor = System.Drawing.Color.White;
            this.skirtingFinishingButton.Location = new System.Drawing.Point(408, 348);
            this.skirtingFinishingButton.Name = "skirtingFinishingButton";
            this.skirtingFinishingButton.Size = new System.Drawing.Size(157, 43);
            this.skirtingFinishingButton.TabIndex = 15;
            this.skirtingFinishingButton.Text = "Skirting Finishing";
            this.skirtingFinishingButton.UseVisualStyleBackColor = false;
            this.skirtingFinishingButton.Click += new System.EventHandler(this.skirtingFinishingButton_Click);
            // 
            // skirtingHeightTextBox
            // 
            this.skirtingHeightTextBox.Location = new System.Drawing.Point(618, 369);
            this.skirtingHeightTextBox.Name = "skirtingHeightTextBox";
            this.skirtingHeightTextBox.Size = new System.Drawing.Size(59, 22);
            this.skirtingHeightTextBox.TabIndex = 16;
            // 
            // unconnectedHeightLable
            // 
            this.unconnectedHeightLable.AutoSize = true;
            this.unconnectedHeightLable.ForeColor = System.Drawing.Color.White;
            this.unconnectedHeightLable.Location = new System.Drawing.Point(578, 348);
            this.unconnectedHeightLable.Name = "unconnectedHeightLable";
            this.unconnectedHeightLable.Size = new System.Drawing.Size(129, 16);
            this.unconnectedHeightLable.TabIndex = 17;
            this.unconnectedHeightLable.Text = "Unconnected Height";
            // 
            // linkedinButton
            // 
            this.linkedinButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.linkedinButton.Image = global::RoomFinishing.Properties.Resources.linkedin;
            this.linkedinButton.Location = new System.Drawing.Point(618, 90);
            this.linkedinButton.Name = "linkedinButton";
            this.linkedinButton.Size = new System.Drawing.Size(60, 60);
            this.linkedinButton.TabIndex = 18;
            this.linkedinButton.UseVisualStyleBackColor = false;
            this.linkedinButton.Click += new System.EventHandler(this.linkedinButton_Click);
            // 
            // informationButton
            // 
            this.informationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(37)))), ((int)(((byte)(55)))));
            this.informationButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.informationButton.ForeColor = System.Drawing.Color.White;
            this.informationButton.Image = global::RoomFinishing.Properties.Resources.information;
            this.informationButton.Location = new System.Drawing.Point(618, 19);
            this.informationButton.Name = "informationButton";
            this.informationButton.Size = new System.Drawing.Size(60, 60);
            this.informationButton.TabIndex = 12;
            this.informationButton.UseVisualStyleBackColor = false;
            this.informationButton.Click += new System.EventHandler(this.informationButton_Click);
            // 
            // AddinUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(732, 402);
            this.Controls.Add(this.linkedinButton);
            this.Controls.Add(this.unconnectedHeightLable);
            this.Controls.Add(this.skirtingHeightTextBox);
            this.Controls.Add(this.skirtingFinishingButton);
            this.Controls.Add(this.skirtingTypeComboBox);
            this.Controls.Add(this.skirtingTypeLabel);
            this.Controls.Add(this.informationButton);
            this.Controls.Add(this.floorFinishingButton);
            this.Controls.Add(this.FloorTypeComboBox);
            this.Controls.Add(this.floorTypeLabel);
            this.Controls.Add(this.ceilingFinishingButton);
            this.Controls.Add(this.ceilingTypeComboBox);
            this.Controls.Add(this.ceilingTypelabel);
            this.Controls.Add(this.wallTypeLabel);
            this.Controls.Add(this.wallTypeComboBox);
            this.Controls.Add(this.wallFinishButton);
            this.Controls.Add(this.clearSelectedRoombutton);
            this.Controls.Add(this.roomsCheckedListBox);
            this.Controls.Add(this.selectRoomsButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddinUI";
            this.Text = "RoomFinishingUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectRoomsButton;
        private System.Windows.Forms.CheckedListBox roomsCheckedListBox;
        private System.Windows.Forms.Button clearSelectedRoombutton;
        private System.Windows.Forms.Button wallFinishButton;
        private System.Windows.Forms.ComboBox wallTypeComboBox;
        private System.Windows.Forms.Label wallTypeLabel;
        private System.Windows.Forms.Label ceilingTypelabel;
        private System.Windows.Forms.ComboBox ceilingTypeComboBox;
        private System.Windows.Forms.Button ceilingFinishingButton;
        private System.Windows.Forms.Label floorTypeLabel;
        private System.Windows.Forms.ComboBox FloorTypeComboBox;
        private System.Windows.Forms.Button floorFinishingButton;
        private System.Windows.Forms.Button informationButton;
        private System.Windows.Forms.Label skirtingTypeLabel;
        private System.Windows.Forms.ComboBox skirtingTypeComboBox;
        private System.Windows.Forms.Button skirtingFinishingButton;
        private System.Windows.Forms.TextBox skirtingHeightTextBox;
        private System.Windows.Forms.Label unconnectedHeightLable;
        private System.Windows.Forms.Button linkedinButton;
    }
}