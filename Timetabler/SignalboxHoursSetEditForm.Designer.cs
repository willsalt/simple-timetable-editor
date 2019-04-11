namespace Timetabler
{
    partial class SignalboxHoursSetEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignalboxHoursSetEditForm));
            this.dgvHours = new System.Windows.Forms.DataGridView();
            this.colBoxId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBoxName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbCategory = new System.Windows.Forms.TextBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHours)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHours
            // 
            this.dgvHours.AllowUserToAddRows = false;
            this.dgvHours.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvHours, "dgvHours");
            this.dgvHours.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvHours.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHours.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBoxId,
            this.colBoxName,
            this.colStartTime,
            this.colEndTime});
            this.dgvHours.Name = "dgvHours";
            this.dgvHours.ReadOnly = true;
            this.dgvHours.RowHeadersVisible = false;
            this.dgvHours.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHours_CellContentDoubleClick);
            this.dgvHours.SelectionChanged += new System.EventHandler(this.dgvHours_SelectionChanged);
            // 
            // colBoxId
            // 
            resources.ApplyResources(this.colBoxId, "colBoxId");
            this.colBoxId.Name = "colBoxId";
            this.colBoxId.ReadOnly = true;
            // 
            // colBoxName
            // 
            resources.ApplyResources(this.colBoxName, "colBoxName");
            this.colBoxName.Name = "colBoxName";
            this.colBoxName.ReadOnly = true;
            // 
            // colStartTime
            // 
            resources.ApplyResources(this.colStartTime, "colStartTime");
            this.colStartTime.Name = "colStartTime";
            this.colStartTime.ReadOnly = true;
            // 
            // colEndTime
            // 
            resources.ApplyResources(this.colEndTime, "colEndTime");
            this.colEndTime.Name = "colEndTime";
            this.colEndTime.ReadOnly = true;
            // 
            // tbCategory
            // 
            resources.ApplyResources(this.tbCategory, "tbCategory");
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.TextChanged += new System.EventHandler(this.tbCategory_TextChanged);
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // SignalboxHoursSetEditForm
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.tbCategory);
            this.Controls.Add(this.dgvHours);
            this.Name = "SignalboxHoursSetEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHours)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHours;
        private System.Windows.Forms.TextBox tbCategory;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBoxId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBoxName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
    }
}