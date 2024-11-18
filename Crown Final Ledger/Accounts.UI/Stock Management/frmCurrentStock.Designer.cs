namespace Accounts.UI
{
    partial class frmCurrentStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrentStock));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new MetroFramework.Controls.MetroTile();
            this.CbxCategories = new MetroFramework.Controls.MetroComboBox();
            this.lblProductDiscription = new MetroFramework.Controls.MetroLabel();
            this.grdCurrentStock = new Accounts.UI.TabDataGrid();
            this.ColIdCurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpacking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCartons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpiry = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEngineNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChassisNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVehicleModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVehicleColors = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colVehicleNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFirstIMEI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSecondIMEI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBonusUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalOpeningStock = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrentStock)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.ActiveControl = null;
            this.btnSave.BackColor = System.Drawing.Color.RosyBrown;
            this.btnSave.Location = new System.Drawing.Point(888, 451);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 52);
            this.btnSave.Style = MetroFramework.MetroColorStyle.Teal;
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.TileImage = ((System.Drawing.Image)(resources.GetObject("btnSave.TileImage")));
            this.btnSave.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseCustomBackColor = true;
            this.btnSave.UseSelectable = true;
            this.btnSave.UseTileImage = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CbxCategories
            // 
            this.CbxCategories.BackColor = System.Drawing.SystemColors.Info;
            this.CbxCategories.FormattingEnabled = true;
            this.CbxCategories.ItemHeight = 24;
            this.CbxCategories.Location = new System.Drawing.Point(91, 72);
            this.CbxCategories.Name = "CbxCategories";
            this.CbxCategories.Size = new System.Drawing.Size(395, 30);
            this.CbxCategories.TabIndex = 15;
            this.CbxCategories.UseCustomBackColor = true;
            this.CbxCategories.UseSelectable = true;
            this.CbxCategories.SelectedIndexChanged += new System.EventHandler(this.CbxCategories_SelectedIndexChanged);
            // 
            // lblProductDiscription
            // 
            this.lblProductDiscription.AutoSize = true;
            this.lblProductDiscription.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.lblProductDiscription.Location = new System.Drawing.Point(9, 75);
            this.lblProductDiscription.Name = "lblProductDiscription";
            this.lblProductDiscription.Size = new System.Drawing.Size(76, 20);
            this.lblProductDiscription.TabIndex = 25;
            this.lblProductDiscription.Text = "Category :";
            // 
            // grdCurrentStock
            // 
            this.grdCurrentStock.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdCurrentStock.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCurrentStock.BackgroundColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCurrentStock.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdCurrentStock.ColumnHeadersHeight = 25;
            this.grdCurrentStock.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColIdCurrentStock,
            this.colIdItem,
            this.colItemNo,
            this.colItemName,
            this.colpacking,
            this.colCartons,
            this.colBatchNo,
            this.colExpiry,
            this.colEngineNo,
            this.colChassisNo,
            this.colVehicleModel,
            this.colVehicleColors,
            this.colVehicleNo,
            this.colFirstIMEI,
            this.colSecondIMEI,
            this.colQty,
            this.colBonusUnit,
            this.colUnitPrice,
            this.colTotalAmount});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.InactiveBorder;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCurrentStock.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdCurrentStock.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdCurrentStock.EnableHeadersVisualStyles = false;
            this.grdCurrentStock.Location = new System.Drawing.Point(10, 107);
            this.grdCurrentStock.MultiSelect = false;
            this.grdCurrentStock.Name = "grdCurrentStock";
            this.grdCurrentStock.RowHeadersVisible = false;
            this.grdCurrentStock.RowHeadersWidth = 51;
            this.grdCurrentStock.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdCurrentStock.Size = new System.Drawing.Size(1015, 301);
            this.grdCurrentStock.TabIndex = 26;
            this.grdCurrentStock.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCurrentStock_CellEndEdit);
            this.grdCurrentStock.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCurrentStock_CellLeave);
            this.grdCurrentStock.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdCurrentStock_EditingControlShowing);
            // 
            // ColIdCurrentStock
            // 
            this.ColIdCurrentStock.HeaderText = "IdCurrentStock";
            this.ColIdCurrentStock.MinimumWidth = 6;
            this.ColIdCurrentStock.Name = "ColIdCurrentStock";
            this.ColIdCurrentStock.Visible = false;
            this.ColIdCurrentStock.Width = 125;
            // 
            // colIdItem
            // 
            this.colIdItem.DataPropertyName = "IdItem";
            this.colIdItem.HeaderText = "IdItem";
            this.colIdItem.MinimumWidth = 6;
            this.colIdItem.Name = "colIdItem";
            this.colIdItem.Visible = false;
            this.colIdItem.Width = 125;
            // 
            // colItemNo
            // 
            this.colItemNo.DataPropertyName = "ItemNo";
            this.colItemNo.HeaderText = "Product Code";
            this.colItemNo.MinimumWidth = 6;
            this.colItemNo.Name = "colItemNo";
            this.colItemNo.Visible = false;
            this.colItemNo.Width = 125;
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "ItemName";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colItemName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colItemName.HeaderText = "Product Discription";
            this.colItemName.MinimumWidth = 6;
            this.colItemName.Name = "colItemName";
            this.colItemName.Width = 250;
            // 
            // colpacking
            // 
            this.colpacking.DataPropertyName = "PackingSize";
            this.colpacking.HeaderText = "UOM";
            this.colpacking.MinimumWidth = 6;
            this.colpacking.Name = "colpacking";
            this.colpacking.ReadOnly = true;
            this.colpacking.Width = 90;
            // 
            // colCartons
            // 
            this.colCartons.DataPropertyName = "TotalCartons";
            this.colCartons.HeaderText = "CTN";
            this.colCartons.MinimumWidth = 6;
            this.colCartons.Name = "colCartons";
            this.colCartons.Width = 90;
            // 
            // colBatchNo
            // 
            this.colBatchNo.DataPropertyName = "BatchNo";
            this.colBatchNo.HeaderText = "BatchNo";
            this.colBatchNo.MinimumWidth = 6;
            this.colBatchNo.Name = "colBatchNo";
            this.colBatchNo.Width = 90;
            // 
            // colExpiry
            // 
            this.colExpiry.DataPropertyName = "Expiry";
            this.colExpiry.HeaderText = "Expiry";
            this.colExpiry.MinimumWidth = 6;
            this.colExpiry.Name = "colExpiry";
            this.colExpiry.Width = 90;
            // 
            // colEngineNo
            // 
            this.colEngineNo.DataPropertyName = "EngineNo";
            this.colEngineNo.HeaderText = "Engine #";
            this.colEngineNo.MinimumWidth = 6;
            this.colEngineNo.Name = "colEngineNo";
            this.colEngineNo.Width = 80;
            // 
            // colChassisNo
            // 
            this.colChassisNo.DataPropertyName = "ChasisNo";
            this.colChassisNo.HeaderText = "Chassis #";
            this.colChassisNo.MinimumWidth = 6;
            this.colChassisNo.Name = "colChassisNo";
            this.colChassisNo.Width = 80;
            // 
            // colVehicleModel
            // 
            this.colVehicleModel.HeaderText = "Model";
            this.colVehicleModel.MinimumWidth = 6;
            this.colVehicleModel.Name = "colVehicleModel";
            this.colVehicleModel.Width = 80;
            // 
            // colVehicleColors
            // 
            this.colVehicleColors.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.colVehicleColors.HeaderText = "Color";
            this.colVehicleColors.Items.AddRange(new object[] {
            "",
            "Red",
            "Black",
            "Blue",
            "Silver"});
            this.colVehicleColors.MinimumWidth = 6;
            this.colVehicleColors.Name = "colVehicleColors";
            this.colVehicleColors.Width = 80;
            // 
            // colVehicleNo
            // 
            this.colVehicleNo.DataPropertyName = "VehicleNo";
            this.colVehicleNo.HeaderText = "Vehicle #";
            this.colVehicleNo.MinimumWidth = 6;
            this.colVehicleNo.Name = "colVehicleNo";
            this.colVehicleNo.Width = 90;
            // 
            // colFirstIMEI
            // 
            this.colFirstIMEI.DataPropertyName = "FirstIMEI";
            this.colFirstIMEI.HeaderText = "IMEI No";
            this.colFirstIMEI.MinimumWidth = 6;
            this.colFirstIMEI.Name = "colFirstIMEI";
            this.colFirstIMEI.Width = 125;
            // 
            // colSecondIMEI
            // 
            this.colSecondIMEI.DataPropertyName = "SecondIMEI";
            this.colSecondIMEI.HeaderText = "Second IMEI";
            this.colSecondIMEI.MinimumWidth = 6;
            this.colSecondIMEI.Name = "colSecondIMEI";
            this.colSecondIMEI.Width = 125;
            // 
            // colQty
            // 
            this.colQty.DataPropertyName = "Qty";
            this.colQty.HeaderText = "Quantity";
            this.colQty.MinimumWidth = 6;
            this.colQty.Name = "colQty";
            this.colQty.Width = 80;
            // 
            // colBonusUnit
            // 
            this.colBonusUnit.HeaderText = "Bonus";
            this.colBonusUnit.MinimumWidth = 6;
            this.colBonusUnit.Name = "colBonusUnit";
            this.colBonusUnit.Width = 125;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "Amount";
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.MinimumWidth = 6;
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.Width = 90;
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.DataPropertyName = "qty*amount";
            this.colTotalAmount.HeaderText = "Amount";
            this.colTotalAmount.MinimumWidth = 6;
            this.colTotalAmount.Name = "colTotalAmount";
            this.colTotalAmount.ReadOnly = true;
            this.colTotalAmount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTotalAmount.Width = 125;
            // 
            // txtTotalOpeningStock
            // 
            this.txtTotalOpeningStock.Location = new System.Drawing.Point(888, 414);
            this.txtTotalOpeningStock.Name = "txtTotalOpeningStock";
            this.txtTotalOpeningStock.Size = new System.Drawing.Size(137, 22);
            this.txtTotalOpeningStock.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(846, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "Total";
            // 
            // frmCurrentStock
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1060, 529);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalOpeningStock);
            this.Controls.Add(this.grdCurrentStock);
            this.Controls.Add(this.lblProductDiscription);
            this.Controls.Add(this.CbxCategories);
            this.Controls.Add(this.btnSave);
            this.MaximizeBox = false;
            this.Name = "frmCurrentStock";
            this.Text = "Add Current Stock";
            this.Load += new System.EventHandler(this.frmCurrentStock_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmCurrentStock_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.grdCurrentStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnSave;
        private MetroFramework.Controls.MetroComboBox CbxCategories;
        private MetroFramework.Controls.MetroLabel lblProductDiscription;
        private TabDataGrid grdCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIdCurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpacking;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCartons;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpiry;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEngineNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChassisNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVehicleModel;
        private System.Windows.Forms.DataGridViewComboBoxColumn colVehicleColors;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVehicleNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFirstIMEI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSecondIMEI;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBonusUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotalAmount;
        private System.Windows.Forms.TextBox txtTotalOpeningStock;
        private System.Windows.Forms.Label label1;
    }
}