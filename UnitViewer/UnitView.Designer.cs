namespace UnitViewer
{
    partial class UnitView
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
            this.unitPropSheet = new System.Windows.Forms.DataGridView();
            this.UnitPropAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitProperty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPropertyValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.unitPropSheet)).BeginInit();
            this.SuspendLayout();
            // 
            // unitPropSheet
            // 
            this.unitPropSheet.AllowUserToAddRows = false;
            this.unitPropSheet.AllowUserToDeleteRows = false;
            this.unitPropSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.unitPropSheet.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.unitPropSheet.ColumnHeadersHeight = 10;
            this.unitPropSheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.unitPropSheet.ColumnHeadersVisible = false;
            this.unitPropSheet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UnitPropAddress,
            this.UnitProperty,
            this.UnitPropertyValue});
            this.unitPropSheet.Location = new System.Drawing.Point(12, 12);
            this.unitPropSheet.Name = "unitPropSheet";
            this.unitPropSheet.RowHeadersVisible = false;
            this.unitPropSheet.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.unitPropSheet.Size = new System.Drawing.Size(398, 342);
            this.unitPropSheet.TabIndex = 0;
            // 
            // UnitPropAddress
            // 
            this.UnitPropAddress.HeaderText = "";
            this.UnitPropAddress.Name = "UnitPropAddress";
            this.UnitPropAddress.Width = 75;
            // 
            // UnitProperty
            // 
            this.UnitProperty.HeaderText = "";
            this.UnitProperty.Name = "UnitProperty";
            this.UnitProperty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.UnitProperty.Width = 200;
            // 
            // UnitPropertyValue
            // 
            this.UnitPropertyValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UnitPropertyValue.HeaderText = "";
            this.UnitPropertyValue.Name = "UnitPropertyValue";
            this.UnitPropertyValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // UnitView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 366);
            this.Controls.Add(this.unitPropSheet);
            this.Name = "UnitView";
            this.Text = "UnitView";
            this.Load += new System.EventHandler(this.UnitView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.unitPropSheet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView unitPropSheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPropAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitProperty;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPropertyValue;
    }
}