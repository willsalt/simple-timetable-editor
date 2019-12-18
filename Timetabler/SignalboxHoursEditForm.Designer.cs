namespace Timetabler
{
    partial class SignalboxHoursEditForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignalboxHoursEditForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lblBoxName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ckTokenWarning = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbStartHours = new System.Windows.Forms.TextBox();
            this.tbStartMinutes = new System.Windows.Forms.TextBox();
            this.tbEndMinutes = new System.Windows.Forms.TextBox();
            this.tbEndHours = new System.Windows.Forms.TextBox();
            this.cbStartHalfOfDay = new System.Windows.Forms.ComboBox();
            this.cbEndHalfOfDay = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblBoxName
            // 
            resources.ApplyResources(this.lblBoxName, "lblBoxName");
            this.lblBoxName.Name = "lblBoxName";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // ckTokenWarning
            // 
            resources.ApplyResources(this.ckTokenWarning, "ckTokenWarning");
            this.ckTokenWarning.Name = "ckTokenWarning";
            this.ckTokenWarning.UseVisualStyleBackColor = true;
            this.ckTokenWarning.CheckedChanged += new System.EventHandler(this.CkTokenWarning_CheckedChanged);
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbStartHours
            // 
            resources.ApplyResources(this.tbStartHours, "tbStartHours");
            this.tbStartHours.Name = "tbStartHours";
            this.tbStartHours.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxHoursMinutes_Validating);
            this.tbStartHours.Validated += new System.EventHandler(this.TbStartHours_Validated);
            // 
            // tbStartMinutes
            // 
            resources.ApplyResources(this.tbStartMinutes, "tbStartMinutes");
            this.tbStartMinutes.Name = "tbStartMinutes";
            this.tbStartMinutes.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxHoursMinutes_Validating);
            this.tbStartMinutes.Validated += new System.EventHandler(this.TbStartMinutes_Validated);
            // 
            // tbEndMinutes
            // 
            resources.ApplyResources(this.tbEndMinutes, "tbEndMinutes");
            this.tbEndMinutes.Name = "tbEndMinutes";
            this.tbEndMinutes.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxHoursMinutes_Validating);
            this.tbEndMinutes.Validated += new System.EventHandler(this.TbEndMinutes_Validated);
            // 
            // tbEndHours
            // 
            resources.ApplyResources(this.tbEndHours, "tbEndHours");
            this.tbEndHours.Name = "tbEndHours";
            this.tbEndHours.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxHoursMinutes_Validating);
            this.tbEndHours.Validated += new System.EventHandler(this.TbEndHours_Validated);
            // 
            // cbStartHalfOfDay
            // 
            this.cbStartHalfOfDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStartHalfOfDay.FormattingEnabled = true;
            resources.ApplyResources(this.cbStartHalfOfDay, "cbStartHalfOfDay");
            this.cbStartHalfOfDay.Name = "cbStartHalfOfDay";
            this.cbStartHalfOfDay.SelectedIndexChanged += new System.EventHandler(this.CbStartHalfOfDay_SelectedIndexChanged);
            // 
            // cbEndHalfOfDay
            // 
            this.cbEndHalfOfDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEndHalfOfDay.FormattingEnabled = true;
            resources.ApplyResources(this.cbEndHalfOfDay, "cbEndHalfOfDay");
            this.cbEndHalfOfDay.Name = "cbEndHalfOfDay";
            this.cbEndHalfOfDay.SelectedIndexChanged += new System.EventHandler(this.CbEndHalfOfDay_SelectedIndexChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // SignalboxHoursEditForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.cbEndHalfOfDay);
            this.Controls.Add(this.cbStartHalfOfDay);
            this.Controls.Add(this.tbEndHours);
            this.Controls.Add(this.tbEndMinutes);
            this.Controls.Add(this.tbStartMinutes);
            this.Controls.Add(this.tbStartHours);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ckTokenWarning);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblBoxName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignalboxHoursEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBoxName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ckTokenWarning;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbStartHours;
        private System.Windows.Forms.TextBox tbStartMinutes;
        private System.Windows.Forms.TextBox tbEndMinutes;
        private System.Windows.Forms.TextBox tbEndHours;
        private System.Windows.Forms.ComboBox cbStartHalfOfDay;
        private System.Windows.Forms.ComboBox cbEndHalfOfDay;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}