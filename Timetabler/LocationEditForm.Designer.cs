namespace Timetabler
{
    partial class LocationEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocationEditForm));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbTiploc = new System.Windows.Forms.TextBox();
            this.tbEditorName = new System.Windows.Forms.TextBox();
            this.tbGraphName = new System.Windows.Forms.TextBox();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.tbChainage = new System.Windows.Forms.TextBox();
            this.tbMileage = new System.Windows.Forms.TextBox();
            this.ckShowDepartureUp = new System.Windows.Forms.CheckBox();
            this.ckShowArrivalUp = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckShowLineUp = new System.Windows.Forms.CheckBox();
            this.ckShowPlatformUp = new System.Windows.Forms.CheckBox();
            this.ckShowPathUp = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckShowLineDown = new System.Windows.Forms.CheckBox();
            this.ckShowPlatformDown = new System.Windows.Forms.CheckBox();
            this.ckShowPathDown = new System.Windows.Forms.CheckBox();
            this.ckShowArrivalDown = new System.Windows.Forms.CheckBox();
            this.ckShowDepartureDown = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbFontType = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ckDisplaySeparatorAbove = new System.Windows.Forms.CheckBox();
            this.ckDisplaySeparatorBelow = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // tbTiploc
            // 
            resources.ApplyResources(this.tbTiploc, "tbTiploc");
            this.tbTiploc.Name = "tbTiploc";
            this.tbTiploc.Validated += new System.EventHandler(this.tbTiploc_Validated);
            // 
            // tbEditorName
            // 
            resources.ApplyResources(this.tbEditorName, "tbEditorName");
            this.tbEditorName.Name = "tbEditorName";
            this.tbEditorName.Validated += new System.EventHandler(this.tbEditorName_Validated);
            // 
            // tbGraphName
            // 
            resources.ApplyResources(this.tbGraphName, "tbGraphName");
            this.tbGraphName.Name = "tbGraphName";
            this.tbGraphName.Validated += new System.EventHandler(this.tbGraphName_Validated);
            // 
            // tbTableName
            // 
            resources.ApplyResources(this.tbTableName, "tbTableName");
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Validated += new System.EventHandler(this.tbTableName_Validated);
            // 
            // tbChainage
            // 
            resources.ApplyResources(this.tbChainage, "tbChainage");
            this.tbChainage.Name = "tbChainage";
            this.tbChainage.Validating += new System.ComponentModel.CancelEventHandler(this.tbChainage_Validating);
            this.tbChainage.Validated += new System.EventHandler(this.tbChainage_Validated);
            // 
            // tbMileage
            // 
            resources.ApplyResources(this.tbMileage, "tbMileage");
            this.tbMileage.Name = "tbMileage";
            this.tbMileage.Validating += new System.ComponentModel.CancelEventHandler(this.tbMileage_Validating);
            this.tbMileage.Validated += new System.EventHandler(this.tbMileage_Validated);
            // 
            // ckShowDepartureUp
            // 
            resources.ApplyResources(this.ckShowDepartureUp, "ckShowDepartureUp");
            this.ckShowDepartureUp.Name = "ckShowDepartureUp";
            this.ckShowDepartureUp.UseVisualStyleBackColor = true;
            this.ckShowDepartureUp.CheckedChanged += new System.EventHandler(this.ckShowDepartureUp_CheckedChanged);
            // 
            // ckShowArrivalUp
            // 
            resources.ApplyResources(this.ckShowArrivalUp, "ckShowArrivalUp");
            this.ckShowArrivalUp.Name = "ckShowArrivalUp";
            this.ckShowArrivalUp.UseVisualStyleBackColor = true;
            this.ckShowArrivalUp.CheckedChanged += new System.EventHandler(this.ckShowArrivalUp_CheckedChanged);
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
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
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
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbEditorName);
            this.groupBox1.Controls.Add(this.tbGraphName);
            this.groupBox1.Controls.Add(this.tbTableName);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.ckShowLineUp);
            this.groupBox2.Controls.Add(this.ckShowPlatformUp);
            this.groupBox2.Controls.Add(this.ckShowPathUp);
            this.groupBox2.Controls.Add(this.ckShowArrivalUp);
            this.groupBox2.Controls.Add(this.ckShowDepartureUp);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // ckShowLineUp
            // 
            resources.ApplyResources(this.ckShowLineUp, "ckShowLineUp");
            this.ckShowLineUp.Name = "ckShowLineUp";
            this.ckShowLineUp.UseVisualStyleBackColor = true;
            this.ckShowLineUp.CheckedChanged += new System.EventHandler(this.ckShowLineUp_CheckedChanged);
            // 
            // ckShowPlatformUp
            // 
            resources.ApplyResources(this.ckShowPlatformUp, "ckShowPlatformUp");
            this.ckShowPlatformUp.Name = "ckShowPlatformUp";
            this.ckShowPlatformUp.UseVisualStyleBackColor = true;
            this.ckShowPlatformUp.CheckedChanged += new System.EventHandler(this.ckShowPlatformUp_CheckedChanged);
            // 
            // ckShowPathUp
            // 
            resources.ApplyResources(this.ckShowPathUp, "ckShowPathUp");
            this.ckShowPathUp.Name = "ckShowPathUp";
            this.ckShowPathUp.UseVisualStyleBackColor = true;
            this.ckShowPathUp.CheckedChanged += new System.EventHandler(this.ckShowPathUp_CheckedChanged);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.ckShowLineDown);
            this.groupBox3.Controls.Add(this.ckShowPlatformDown);
            this.groupBox3.Controls.Add(this.ckShowPathDown);
            this.groupBox3.Controls.Add(this.ckShowArrivalDown);
            this.groupBox3.Controls.Add(this.ckShowDepartureDown);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // ckShowLineDown
            // 
            resources.ApplyResources(this.ckShowLineDown, "ckShowLineDown");
            this.ckShowLineDown.Name = "ckShowLineDown";
            this.ckShowLineDown.UseVisualStyleBackColor = true;
            this.ckShowLineDown.CheckedChanged += new System.EventHandler(this.ckShowLineDown_CheckedChanged);
            // 
            // ckShowPlatformDown
            // 
            resources.ApplyResources(this.ckShowPlatformDown, "ckShowPlatformDown");
            this.ckShowPlatformDown.Name = "ckShowPlatformDown";
            this.ckShowPlatformDown.UseVisualStyleBackColor = true;
            this.ckShowPlatformDown.CheckedChanged += new System.EventHandler(this.ckShowPlatformDown_CheckedChanged);
            // 
            // ckShowPathDown
            // 
            resources.ApplyResources(this.ckShowPathDown, "ckShowPathDown");
            this.ckShowPathDown.Name = "ckShowPathDown";
            this.ckShowPathDown.UseVisualStyleBackColor = true;
            this.ckShowPathDown.CheckedChanged += new System.EventHandler(this.ckShowPathDown_CheckedChanged);
            // 
            // ckShowArrivalDown
            // 
            resources.ApplyResources(this.ckShowArrivalDown, "ckShowArrivalDown");
            this.ckShowArrivalDown.Name = "ckShowArrivalDown";
            this.ckShowArrivalDown.UseVisualStyleBackColor = true;
            this.ckShowArrivalDown.CheckedChanged += new System.EventHandler(this.ckShowArrivalDown_CheckedChanged);
            // 
            // ckShowDepartureDown
            // 
            resources.ApplyResources(this.ckShowDepartureDown, "ckShowDepartureDown");
            this.ckShowDepartureDown.Name = "ckShowDepartureDown";
            this.ckShowDepartureDown.UseVisualStyleBackColor = true;
            this.ckShowDepartureDown.CheckedChanged += new System.EventHandler(this.ckShowDepartureDown_CheckedChanged);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.ckDisplaySeparatorBelow);
            this.groupBox4.Controls.Add(this.ckDisplaySeparatorAbove);
            this.groupBox4.Controls.Add(this.cbFontType);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // cbFontType
            // 
            this.cbFontType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontType.FormattingEnabled = true;
            resources.ApplyResources(this.cbFontType, "cbFontType");
            this.cbFontType.Name = "cbFontType";
            this.cbFontType.SelectedIndexChanged += new System.EventHandler(this.cbFontType_SelectedIndexChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // ckDisplaySeparatorAbove
            // 
            resources.ApplyResources(this.ckDisplaySeparatorAbove, "ckDisplaySeparatorAbove");
            this.ckDisplaySeparatorAbove.Name = "ckDisplaySeparatorAbove";
            this.ckDisplaySeparatorAbove.UseVisualStyleBackColor = true;
            this.ckDisplaySeparatorAbove.CheckedChanged += new System.EventHandler(this.ckDisplaySeparatorAbove_CheckedChanged);
            // 
            // ckDisplaySeparatorBelow
            // 
            resources.ApplyResources(this.ckDisplaySeparatorBelow, "ckDisplaySeparatorBelow");
            this.ckDisplaySeparatorBelow.Name = "ckDisplaySeparatorBelow";
            this.ckDisplaySeparatorBelow.UseVisualStyleBackColor = true;
            this.ckDisplaySeparatorBelow.CheckedChanged += new System.EventHandler(this.ckDisplaySeparatorBelow_CheckedChanged);
            // 
            // LocationEditForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbMileage);
            this.Controls.Add(this.tbChainage);
            this.Controls.Add(this.tbTiploc);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "LocationEditForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbTiploc;
        private System.Windows.Forms.TextBox tbEditorName;
        private System.Windows.Forms.TextBox tbGraphName;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.TextBox tbChainage;
        private System.Windows.Forms.TextBox tbMileage;
        private System.Windows.Forms.CheckBox ckShowDepartureUp;
        private System.Windows.Forms.CheckBox ckShowArrivalUp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox ckShowArrivalDown;
        private System.Windows.Forms.CheckBox ckShowDepartureDown;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbFontType;
        private System.Windows.Forms.CheckBox ckShowLineDown;
        private System.Windows.Forms.CheckBox ckShowPlatformDown;
        private System.Windows.Forms.CheckBox ckShowPathDown;
        private System.Windows.Forms.CheckBox ckShowLineUp;
        private System.Windows.Forms.CheckBox ckShowPlatformUp;
        private System.Windows.Forms.CheckBox ckShowPathUp;
        private System.Windows.Forms.CheckBox ckDisplaySeparatorBelow;
        private System.Windows.Forms.CheckBox ckDisplaySeparatorAbove;
    }
}