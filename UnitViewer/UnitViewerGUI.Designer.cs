namespace UnitViewer
{
    partial class UnitViewerGUI
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
            if ( disposing && (components != null) )
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
            this.treeViewUnits = new System.Windows.Forms.TreeView();
            this.unitTreeFixPanel = new System.Windows.Forms.Panel();
            this.buttonFreeze = new System.Windows.Forms.Button();
            this.viewByAddress = new System.Windows.Forms.Button();
            this.addressInput = new System.Windows.Forms.TextBox();
            this.Units = new System.Windows.Forms.TabControl();
            this.unitsTab = new System.Windows.Forms.TabPage();
            this.deathsTab = new System.Windows.Forms.TabPage();
            this.deathsTreeFixPanel = new System.Windows.Forms.Panel();
            this.treeViewDeaths = new System.Windows.Forms.TreeView();
            this.unitTreeFixPanel.SuspendLayout();
            this.Units.SuspendLayout();
            this.unitsTab.SuspendLayout();
            this.deathsTab.SuspendLayout();
            this.deathsTreeFixPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewUnits
            // 
            this.treeViewUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewUnits.HideSelection = false;
            this.treeViewUnits.Location = new System.Drawing.Point(3, 3);
            this.treeViewUnits.Name = "treeViewUnits";
            this.treeViewUnits.Size = new System.Drawing.Size(310, 383);
            this.treeViewUnits.TabIndex = 0;
            this.treeViewUnits.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewUnits_NodeMouseDoubleClick);
            // 
            // unitTreeFixPanel
            // 
            this.unitTreeFixPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitTreeFixPanel.Controls.Add(this.treeViewUnits);
            this.unitTreeFixPanel.Location = new System.Drawing.Point(6, 7);
            this.unitTreeFixPanel.Name = "unitTreeFixPanel";
            this.unitTreeFixPanel.Size = new System.Drawing.Size(316, 389);
            this.unitTreeFixPanel.TabIndex = 1;
            // 
            // buttonFreeze
            // 
            this.buttonFreeze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFreeze.Location = new System.Drawing.Point(328, 370);
            this.buttonFreeze.Name = "buttonFreeze";
            this.buttonFreeze.Size = new System.Drawing.Size(75, 23);
            this.buttonFreeze.TabIndex = 2;
            this.buttonFreeze.Text = "Freeze SC";
            this.buttonFreeze.UseVisualStyleBackColor = true;
            this.buttonFreeze.Click += new System.EventHandler(this.buttonFreeze_Click);
            // 
            // viewByAddress
            // 
            this.viewByAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.viewByAddress.Location = new System.Drawing.Point(328, 36);
            this.viewByAddress.Name = "viewByAddress";
            this.viewByAddress.Size = new System.Drawing.Size(75, 38);
            this.viewByAddress.TabIndex = 3;
            this.viewByAddress.Text = "View By Address";
            this.viewByAddress.UseVisualStyleBackColor = true;
            this.viewByAddress.Click += new System.EventHandler(this.viewByAddress_Click);
            // 
            // addressInput
            // 
            this.addressInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addressInput.Location = new System.Drawing.Point(329, 10);
            this.addressInput.Name = "addressInput";
            this.addressInput.Size = new System.Drawing.Size(74, 20);
            this.addressInput.TabIndex = 4;
            this.addressInput.Text = "0x";
            // 
            // Units
            // 
            this.Units.Controls.Add(this.unitsTab);
            this.Units.Controls.Add(this.deathsTab);
            this.Units.Location = new System.Drawing.Point(13, 13);
            this.Units.Name = "Units";
            this.Units.SelectedIndex = 0;
            this.Units.Size = new System.Drawing.Size(417, 428);
            this.Units.TabIndex = 5;
            // 
            // unitsTab
            // 
            this.unitsTab.Controls.Add(this.unitTreeFixPanel);
            this.unitsTab.Controls.Add(this.buttonFreeze);
            this.unitsTab.Controls.Add(this.viewByAddress);
            this.unitsTab.Controls.Add(this.addressInput);
            this.unitsTab.Location = new System.Drawing.Point(4, 22);
            this.unitsTab.Name = "unitsTab";
            this.unitsTab.Padding = new System.Windows.Forms.Padding(3);
            this.unitsTab.Size = new System.Drawing.Size(409, 402);
            this.unitsTab.TabIndex = 0;
            this.unitsTab.Text = "Units";
            this.unitsTab.UseVisualStyleBackColor = true;
            // 
            // deathsTab
            // 
            this.deathsTab.Controls.Add(this.deathsTreeFixPanel);
            this.deathsTab.Location = new System.Drawing.Point(4, 22);
            this.deathsTab.Name = "deathsTab";
            this.deathsTab.Padding = new System.Windows.Forms.Padding(3);
            this.deathsTab.Size = new System.Drawing.Size(409, 402);
            this.deathsTab.TabIndex = 1;
            this.deathsTab.Text = "Deaths";
            this.deathsTab.UseVisualStyleBackColor = true;
            // 
            // deathsTreeFixPanel
            // 
            this.deathsTreeFixPanel.Controls.Add(this.treeViewDeaths);
            this.deathsTreeFixPanel.Location = new System.Drawing.Point(4, 4);
            this.deathsTreeFixPanel.Name = "deathsTreeFixPanel";
            this.deathsTreeFixPanel.Size = new System.Drawing.Size(528, 392);
            this.deathsTreeFixPanel.TabIndex = 1;
            // 
            // treeViewDeaths
            // 
            this.treeViewDeaths.Location = new System.Drawing.Point(3, 3);
            this.treeViewDeaths.Name = "treeViewDeaths";
            this.treeViewDeaths.Size = new System.Drawing.Size(396, 386);
            this.treeViewDeaths.TabIndex = 0;
            // 
            // UnitViewerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 456);
            this.Controls.Add(this.Units);
            this.Name = "UnitViewerGUI";
            this.Text = "Unit Viewer";
            this.Load += new System.EventHandler(this.UnitViewerGUI_Load);
            this.unitTreeFixPanel.ResumeLayout(false);
            this.Units.ResumeLayout(false);
            this.unitsTab.ResumeLayout(false);
            this.unitsTab.PerformLayout();
            this.deathsTab.ResumeLayout(false);
            this.deathsTreeFixPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewUnits;
        private System.Windows.Forms.Panel unitTreeFixPanel;
        private System.Windows.Forms.Button buttonFreeze;
        private System.Windows.Forms.Button viewByAddress;
        private System.Windows.Forms.TextBox addressInput;
        private System.Windows.Forms.TabControl Units;
        private System.Windows.Forms.TabPage unitsTab;
        private System.Windows.Forms.TabPage deathsTab;
        private System.Windows.Forms.TreeView treeViewDeaths;
        private System.Windows.Forms.Panel deathsTreeFixPanel;
    }
}

