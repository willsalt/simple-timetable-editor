namespace Timetabler
{
    partial class DocumentOptionsEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentOptionsEditForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbClockType = new System.Windows.Forms.ComboBox();
            this.ckDisplayTrainLabelsOnGraphs = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGraphEditStyle = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbSpeedLineSpacing = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbSpeedLineSpeed = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nudLineWidth = new System.Windows.Forms.NumericUpDown();
            this.btnColour = new System.Windows.Forms.Button();
            this.cbLinePattern = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ckDisplaySpeedLines = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
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
            // cbClockType
            // 
            this.cbClockType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClockType.FormattingEnabled = true;
            resources.ApplyResources(this.cbClockType, "cbClockType");
            this.cbClockType.Name = "cbClockType";
            this.cbClockType.SelectedIndexChanged += new System.EventHandler(this.CbClockType_SelectedIndexChanged);
            // 
            // ckDisplayTrainLabelsOnGraphs
            // 
            resources.ApplyResources(this.ckDisplayTrainLabelsOnGraphs, "ckDisplayTrainLabelsOnGraphs");
            this.ckDisplayTrainLabelsOnGraphs.Name = "ckDisplayTrainLabelsOnGraphs";
            this.ckDisplayTrainLabelsOnGraphs.UseVisualStyleBackColor = true;
            this.ckDisplayTrainLabelsOnGraphs.CheckedChanged += new System.EventHandler(this.CkDisplayTrainLabelsOnGraphs_CheckedChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cbGraphEditStyle
            // 
            this.cbGraphEditStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGraphEditStyle.FormattingEnabled = true;
            resources.ApplyResources(this.cbGraphEditStyle, "cbGraphEditStyle");
            this.cbGraphEditStyle.Name = "cbGraphEditStyle";
            this.cbGraphEditStyle.SelectedIndexChanged += new System.EventHandler(this.CbGraphEditStyle_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.tbSpeedLineSpacing);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tbSpeedLineSpeed);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.nudLineWidth);
            this.groupBox1.Controls.Add(this.btnColour);
            this.groupBox1.Controls.Add(this.cbLinePattern);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ckDisplaySpeedLines);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // tbSpeedLineSpacing
            // 
            resources.ApplyResources(this.tbSpeedLineSpacing, "tbSpeedLineSpacing");
            this.tbSpeedLineSpacing.Name = "tbSpeedLineSpacing";
            this.tbSpeedLineSpacing.Validating += new System.ComponentModel.CancelEventHandler(this.TbSpeedLineSpacing_Validating);
            this.tbSpeedLineSpacing.Validated += new System.EventHandler(this.TbSpeedLineSpacing_Validated);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // tbSpeedLineSpeed
            // 
            resources.ApplyResources(this.tbSpeedLineSpeed, "tbSpeedLineSpeed");
            this.tbSpeedLineSpeed.Name = "tbSpeedLineSpeed";
            this.tbSpeedLineSpeed.Validating += new System.ComponentModel.CancelEventHandler(this.TbSpeedLineSpeed_Validating);
            this.tbSpeedLineSpeed.Validated += new System.EventHandler(this.TbSpeedLineSpeed_Validated);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // nudLineWidth
            // 
            this.nudLineWidth.DecimalPlaces = 1;
            this.nudLineWidth.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            resources.ApplyResources(this.nudLineWidth, "nudLineWidth");
            this.nudLineWidth.Name = "nudLineWidth";
            this.nudLineWidth.ValueChanged += new System.EventHandler(this.NudLineWidth_ValueChanged);
            // 
            // btnColour
            // 
            resources.ApplyResources(this.btnColour, "btnColour");
            this.btnColour.Name = "btnColour";
            this.btnColour.UseVisualStyleBackColor = true;
            this.btnColour.Click += new System.EventHandler(this.BtnColour_Click);
            // 
            // cbLinePattern
            // 
            this.cbLinePattern.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLinePattern.FormattingEnabled = true;
            resources.ApplyResources(this.cbLinePattern, "cbLinePattern");
            this.cbLinePattern.Name = "cbLinePattern";
            this.cbLinePattern.SelectedIndexChanged += new System.EventHandler(this.CbLinePattern_SelectedIndexChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // ckDisplaySpeedLines
            // 
            resources.ApplyResources(this.ckDisplaySpeedLines, "ckDisplaySpeedLines");
            this.ckDisplaySpeedLines.Name = "ckDisplaySpeedLines";
            this.ckDisplaySpeedLines.UseVisualStyleBackColor = true;
            this.ckDisplaySpeedLines.CheckedChanged += new System.EventHandler(this.CkDisplaySpeedLines_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // DocumentOptionsEditForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbGraphEditStyle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ckDisplayTrainLabelsOnGraphs);
            this.Controls.Add(this.cbClockType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "DocumentOptionsEditForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbClockType;
        private System.Windows.Forms.CheckBox ckDisplayTrainLabelsOnGraphs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbGraphEditStyle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckDisplaySpeedLines;
        private System.Windows.Forms.NumericUpDown nudLineWidth;
        private System.Windows.Forms.Button btnColour;
        private System.Windows.Forms.ComboBox cbLinePattern;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSpeedLineSpacing;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbSpeedLineSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}