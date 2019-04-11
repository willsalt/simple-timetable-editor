namespace Timetabler
{
    partial class TrainAdjustTimesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainAdjustTimesForm));
            this.cbLocation = new System.Windows.Forms.ComboBox();
            this.cbArriveDepart = new System.Windows.Forms.ComboBox();
            this.cbAddSubtract = new System.Windows.Forms.ComboBox();
            this.tbOffset = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAfter = new System.Windows.Forms.Label();
            this.lblTiming = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cbLocation
            // 
            this.cbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocation.FormattingEnabled = true;
            resources.ApplyResources(this.cbLocation, "cbLocation");
            this.cbLocation.Name = "cbLocation";
            this.cbLocation.SelectedIndexChanged += new System.EventHandler(this.cbLocation_SelectedIndexChanged);
            // 
            // cbArriveDepart
            // 
            this.cbArriveDepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbArriveDepart.FormattingEnabled = true;
            resources.ApplyResources(this.cbArriveDepart, "cbArriveDepart");
            this.cbArriveDepart.Name = "cbArriveDepart";
            this.cbArriveDepart.SelectedIndexChanged += new System.EventHandler(this.cbArriveDepart_SelectedIndexChanged);
            // 
            // cbAddSubtract
            // 
            this.cbAddSubtract.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAddSubtract.FormattingEnabled = true;
            resources.ApplyResources(this.cbAddSubtract, "cbAddSubtract");
            this.cbAddSubtract.Name = "cbAddSubtract";
            this.cbAddSubtract.SelectedIndexChanged += new System.EventHandler(this.cbAddSubtract_SelectedIndexChanged);
            // 
            // tbOffset
            // 
            resources.ApplyResources(this.tbOffset, "tbOffset");
            this.tbOffset.Name = "tbOffset";
            this.tbOffset.Validating += new System.ComponentModel.CancelEventHandler(this.tbOffset_Validating);
            this.tbOffset.Validated += new System.EventHandler(this.tbOffset_Validated);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblAfter
            // 
            resources.ApplyResources(this.lblAfter, "lblAfter");
            this.lblAfter.Name = "lblAfter";
            // 
            // lblTiming
            // 
            resources.ApplyResources(this.lblTiming, "lblTiming");
            this.lblTiming.Name = "lblTiming";
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
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // TrainAdjustTimesForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblTiming);
            this.Controls.Add(this.lblAfter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbOffset);
            this.Controls.Add(this.cbAddSubtract);
            this.Controls.Add(this.cbArriveDepart);
            this.Controls.Add(this.cbLocation);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrainAdjustTimesForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLocation;
        private System.Windows.Forms.ComboBox cbArriveDepart;
        private System.Windows.Forms.ComboBox cbAddSubtract;
        private System.Windows.Forms.TextBox tbOffset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAfter;
        private System.Windows.Forms.Label lblTiming;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}