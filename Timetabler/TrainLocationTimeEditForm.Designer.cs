namespace Timetabler
{
    /// <summary>
    /// A form for editing train timing points.
    /// </summary>
    partial class TrainLocationTimeEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainLocationTimeEditForm));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbArrivalHour = new System.Windows.Forms.TextBox();
            this.tbArrivalMinute = new System.Windows.Forms.TextBox();
            this.tbDepartureHour = new System.Windows.Forms.TextBox();
            this.tbDepartureMinute = new System.Windows.Forms.TextBox();
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ckPassingTime = new System.Windows.Forms.CheckBox();
            this.clbArrival = new System.Windows.Forms.CheckedListBox();
            this.clbDeparture = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbArrivalHalfOfDay = new System.Windows.Forms.ComboBox();
            this.cbDepartureHalfOfDay = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbPlatform = new System.Windows.Forms.TextBox();
            this.tbPath = new System.Windows.Forms.TextBox();
            this.tbLine = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tbArrivalHour
            // 
            resources.ApplyResources(this.tbArrivalHour, "tbArrivalHour");
            this.tbArrivalHour.Name = "tbArrivalHour";
            this.tbArrivalHour.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxHoursMinutes_Validating);
            this.tbArrivalHour.Validated += new System.EventHandler(this.tbArrivalHour_Validated);
            // 
            // tbArrivalMinute
            // 
            resources.ApplyResources(this.tbArrivalMinute, "tbArrivalMinute");
            this.tbArrivalMinute.Name = "tbArrivalMinute";
            this.tbArrivalMinute.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxHoursMinutes_Validating);
            this.tbArrivalMinute.Validated += new System.EventHandler(this.tbArrivalMinute_Validated);
            // 
            // tbDepartureHour
            // 
            resources.ApplyResources(this.tbDepartureHour, "tbDepartureHour");
            this.tbDepartureHour.Name = "tbDepartureHour";
            this.tbDepartureHour.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxHoursMinutes_Validating);
            this.tbDepartureHour.Validated += new System.EventHandler(this.tbDepartureHour_Validated);
            // 
            // tbDepartureMinute
            // 
            resources.ApplyResources(this.tbDepartureMinute, "tbDepartureMinute");
            this.tbDepartureMinute.Name = "tbDepartureMinute";
            this.tbDepartureMinute.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxHoursMinutes_Validating);
            this.tbDepartureMinute.Validated += new System.EventHandler(this.tbDepartureMinute_Validated);
            // 
            // cbLocation
            // 
            this.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocation.FormattingEnabled = true;
            resources.ApplyResources(this.cbLocation, "cbLocation");
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.SelectedIndexChanged += new System.EventHandler(this.cbLocation_SelectedIndexChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // ckPassingTime
            // 
            resources.ApplyResources(this.ckPassingTime, "ckPassingTime");
            this.ckPassingTime.Name = "ckPassingTime";
            this.ckPassingTime.UseVisualStyleBackColor = true;
            this.ckPassingTime.CheckedChanged += new System.EventHandler(this.ckPassingTime_CheckedChanged);
            // 
            // clbArrival
            // 
            resources.ApplyResources(this.clbArrival, "clbArrival");
            this.clbArrival.FormattingEnabled = true;
            this.clbArrival.Name = "clbArrival";
            this.clbArrival.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbArrival_ItemCheck);
            // 
            // clbDeparture
            // 
            resources.ApplyResources(this.clbDeparture, "clbDeparture");
            this.clbDeparture.FormattingEnabled = true;
            this.clbDeparture.Name = "clbDeparture";
            this.clbDeparture.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbDeparture_ItemCheck);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // cbArrivalHalfOfDay
            // 
            this.cbArrivalHalfOfDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArrivalHalfOfDay.FormattingEnabled = true;
            resources.ApplyResources(this.cbArrivalHalfOfDay, "cbArrivalHalfOfDay");
            this.cbArrivalHalfOfDay.Name = "cbArrivalHalfOfDay";
            this.cbArrivalHalfOfDay.SelectedIndexChanged += new System.EventHandler(this.cbArrivalHalfOfDay_SelectedIndexChanged);
            // 
            // cbDepartureHalfOfDay
            // 
            this.cbDepartureHalfOfDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartureHalfOfDay.FormattingEnabled = true;
            resources.ApplyResources(this.cbDepartureHalfOfDay, "cbDepartureHalfOfDay");
            this.cbDepartureHalfOfDay.Name = "cbDepartureHalfOfDay";
            this.cbDepartureHalfOfDay.SelectedIndexChanged += new System.EventHandler(this.cbDepartureHalfOfDay_SelectedIndexChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // tbPlatform
            // 
            resources.ApplyResources(this.tbPlatform, "tbPlatform");
            this.tbPlatform.Name = "tbPlatform";
            this.tbPlatform.TextChanged += new System.EventHandler(this.tbPlatform_TextChanged);
            // 
            // tbPath
            // 
            resources.ApplyResources(this.tbPath, "tbPath");
            this.tbPath.Name = "tbPath";
            this.tbPath.TextChanged += new System.EventHandler(this.tbPath_TextChanged);
            // 
            // tbLine
            // 
            resources.ApplyResources(this.tbLine, "tbLine");
            this.tbLine.Name = "tbLine";
            this.tbLine.TextChanged += new System.EventHandler(this.tbLine_TextChanged);
            // 
            // TrainLocationTimeEditForm
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tbLine);
            this.Controls.Add(this.tbPath);
            this.Controls.Add(this.tbPlatform);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbDepartureHalfOfDay);
            this.Controls.Add(this.cbArrivalHalfOfDay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clbDeparture);
            this.Controls.Add(this.clbArrival);
            this.Controls.Add(this.ckPassingTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbLocation);
            this.Controls.Add(this.tbDepartureMinute);
            this.Controls.Add(this.tbDepartureHour);
            this.Controls.Add(this.tbArrivalMinute);
            this.Controls.Add(this.tbArrivalHour);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "TrainLocationTimeEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbArrivalHour;
        private System.Windows.Forms.TextBox tbArrivalMinute;
        private System.Windows.Forms.TextBox tbDepartureHour;
        private System.Windows.Forms.TextBox tbDepartureMinute;
        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.CheckBox ckPassingTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox clbDeparture;
        private System.Windows.Forms.CheckedListBox clbArrival;
        private System.Windows.Forms.ComboBox cbDepartureHalfOfDay;
        private System.Windows.Forms.ComboBox cbArrivalHalfOfDay;
        private System.Windows.Forms.TextBox tbLine;
        private System.Windows.Forms.TextBox tbPath;
        private System.Windows.Forms.TextBox tbPlatform;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}