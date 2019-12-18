namespace Timetabler
{
    partial class TrainEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainEditForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDetails = new System.Windows.Forms.TabPage();
            this.tbInlineNote = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbLocoDiagram = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.clbFootnotes = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTrainClass = new System.Windows.Forms.ComboBox();
            this.tbHeadcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabTimings = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbLocoToWorkHalfOfDay = new System.Windows.Forms.ComboBox();
            this.tbLocoToWorkText = new System.Windows.Forms.TextBox();
            this.tbLocoToWorkHour = new System.Windows.Forms.TextBox();
            this.tbLocoToWorkMinute = new System.Windows.Forms.TextBox();
            this.tbToWorkText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbToWorkHalfOfDay = new System.Windows.Forms.ComboBox();
            this.tbToWorkMinute = new System.Windows.Forms.TextBox();
            this.tbToWorkHour = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAdjust = new System.Windows.Forms.Button();
            this.dgvTimings = new System.Windows.Forms.DataGridView();
            this.colTimingLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimingArr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimingDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteTiming = new System.Windows.Forms.Button();
            this.btnEditTiming = new System.Windows.Forms.Button();
            this.btnAddTiming = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nudLineWidth = new System.Windows.Forms.NumericUpDown();
            this.btnColour = new System.Windows.Forms.Button();
            this.cbLinePattern = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ckSeparatorBelow = new System.Windows.Forms.CheckBox();
            this.ckSeparatorAbove = new System.Windows.Forms.CheckBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1.SuspendLayout();
            this.tabDetails.SuspendLayout();
            this.tabTimings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimings)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Name = "btnOk";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabDetails);
            this.tabControl1.Controls.Add(this.tabTimings);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.tbInlineNote);
            this.tabDetails.Controls.Add(this.label8);
            this.tabDetails.Controls.Add(this.tbLocoDiagram);
            this.tabDetails.Controls.Add(this.label7);
            this.tabDetails.Controls.Add(this.label6);
            this.tabDetails.Controls.Add(this.clbFootnotes);
            this.tabDetails.Controls.Add(this.label2);
            this.tabDetails.Controls.Add(this.cbTrainClass);
            this.tabDetails.Controls.Add(this.tbHeadcode);
            this.tabDetails.Controls.Add(this.label1);
            resources.ApplyResources(this.tabDetails, "tabDetails");
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.UseVisualStyleBackColor = true;
            // 
            // tbInlineNote
            // 
            resources.ApplyResources(this.tbInlineNote, "tbInlineNote");
            this.tbInlineNote.Name = "tbInlineNote";
            this.tbInlineNote.TextChanged += new System.EventHandler(this.TbInlineNote_TextChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // tbLocoDiagram
            // 
            resources.ApplyResources(this.tbLocoDiagram, "tbLocoDiagram");
            this.tbLocoDiagram.Name = "tbLocoDiagram";
            this.tbLocoDiagram.TextChanged += new System.EventHandler(this.TbLocoDiagram_TextChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // clbFootnotes
            // 
            this.clbFootnotes.FormattingEnabled = true;
            resources.ApplyResources(this.clbFootnotes, "clbFootnotes");
            this.clbFootnotes.Name = "clbFootnotes";
            this.clbFootnotes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ClbFootnotes_ItemCheck);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // cbTrainClass
            // 
            this.cbTrainClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrainClass.FormattingEnabled = true;
            resources.ApplyResources(this.cbTrainClass, "cbTrainClass");
            this.cbTrainClass.Name = "cbTrainClass";
            this.cbTrainClass.SelectedIndexChanged += new System.EventHandler(this.CbTrainClass_SelectedIndexChanged);
            // 
            // tbHeadcode
            // 
            resources.ApplyResources(this.tbHeadcode, "tbHeadcode");
            this.tbHeadcode.Name = "tbHeadcode";
            this.tbHeadcode.Validated += new System.EventHandler(this.TbHeadcode_Validated);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tabTimings
            // 
            this.tabTimings.Controls.Add(this.label12);
            this.tabTimings.Controls.Add(this.label11);
            this.tabTimings.Controls.Add(this.cbLocoToWorkHalfOfDay);
            this.tabTimings.Controls.Add(this.tbLocoToWorkText);
            this.tabTimings.Controls.Add(this.tbLocoToWorkHour);
            this.tabTimings.Controls.Add(this.tbLocoToWorkMinute);
            this.tabTimings.Controls.Add(this.tbToWorkText);
            this.tabTimings.Controls.Add(this.label10);
            this.tabTimings.Controls.Add(this.cbToWorkHalfOfDay);
            this.tabTimings.Controls.Add(this.tbToWorkMinute);
            this.tabTimings.Controls.Add(this.tbToWorkHour);
            this.tabTimings.Controls.Add(this.label9);
            this.tabTimings.Controls.Add(this.btnAdjust);
            this.tabTimings.Controls.Add(this.dgvTimings);
            this.tabTimings.Controls.Add(this.btnDeleteTiming);
            this.tabTimings.Controls.Add(this.btnEditTiming);
            this.tabTimings.Controls.Add(this.btnAddTiming);
            resources.ApplyResources(this.tabTimings, "tabTimings");
            this.tabTimings.Name = "tabTimings";
            this.tabTimings.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // cbLocoToWorkHalfOfDay
            // 
            resources.ApplyResources(this.cbLocoToWorkHalfOfDay, "cbLocoToWorkHalfOfDay");
            this.cbLocoToWorkHalfOfDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLocoToWorkHalfOfDay.FormattingEnabled = true;
            this.cbLocoToWorkHalfOfDay.Name = "cbLocoToWorkHalfOfDay";
            this.cbLocoToWorkHalfOfDay.SelectedIndexChanged += new System.EventHandler(this.CbLocoToWorkHalfOfDay_SelectedIndexChanged);
            // 
            // tbLocoToWorkText
            // 
            resources.ApplyResources(this.tbLocoToWorkText, "tbLocoToWorkText");
            this.tbLocoToWorkText.Name = "tbLocoToWorkText";
            this.tbLocoToWorkText.TextChanged += new System.EventHandler(this.TbLocoToWorkText_TextChanged);
            // 
            // tbLocoToWorkHour
            // 
            resources.ApplyResources(this.tbLocoToWorkHour, "tbLocoToWorkHour");
            this.tbLocoToWorkHour.Name = "tbLocoToWorkHour";
            this.tbLocoToWorkHour.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxHoursMinutes_Validating);
            this.tbLocoToWorkHour.Validated += new System.EventHandler(this.TextBoxLocoToWorkHoursMinutes_Validated);
            // 
            // tbLocoToWorkMinute
            // 
            resources.ApplyResources(this.tbLocoToWorkMinute, "tbLocoToWorkMinute");
            this.tbLocoToWorkMinute.Name = "tbLocoToWorkMinute";
            this.tbLocoToWorkMinute.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxHoursMinutes_Validating);
            this.tbLocoToWorkMinute.Validated += new System.EventHandler(this.TextBoxLocoToWorkHoursMinutes_Validated);
            // 
            // tbToWorkText
            // 
            resources.ApplyResources(this.tbToWorkText, "tbToWorkText");
            this.tbToWorkText.Name = "tbToWorkText";
            this.tbToWorkText.TextChanged += new System.EventHandler(this.TbToWorkText_TextChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // cbToWorkHalfOfDay
            // 
            resources.ApplyResources(this.cbToWorkHalfOfDay, "cbToWorkHalfOfDay");
            this.cbToWorkHalfOfDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbToWorkHalfOfDay.FormattingEnabled = true;
            this.cbToWorkHalfOfDay.Name = "cbToWorkHalfOfDay";
            this.cbToWorkHalfOfDay.SelectedIndexChanged += new System.EventHandler(this.CbToWorkHalfOfDay_SelectedIndexChanged);
            // 
            // tbToWorkMinute
            // 
            resources.ApplyResources(this.tbToWorkMinute, "tbToWorkMinute");
            this.tbToWorkMinute.Name = "tbToWorkMinute";
            this.tbToWorkMinute.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxHoursMinutes_Validating);
            this.tbToWorkMinute.Validated += new System.EventHandler(this.TextBoxToWorkHoursMinutes_Validated);
            // 
            // tbToWorkHour
            // 
            resources.ApplyResources(this.tbToWorkHour, "tbToWorkHour");
            this.tbToWorkHour.Name = "tbToWorkHour";
            this.tbToWorkHour.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxHoursMinutes_Validating);
            this.tbToWorkHour.Validated += new System.EventHandler(this.TextBoxToWorkHoursMinutes_Validated);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // btnAdjust
            // 
            resources.ApplyResources(this.btnAdjust, "btnAdjust");
            this.btnAdjust.Name = "btnAdjust";
            this.btnAdjust.UseVisualStyleBackColor = true;
            this.btnAdjust.Click += new System.EventHandler(this.BtnAdjust_Click);
            // 
            // dgvTimings
            // 
            this.dgvTimings.AllowUserToAddRows = false;
            this.dgvTimings.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dgvTimings, "dgvTimings");
            this.dgvTimings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTimings.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTimings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTimingLocation,
            this.colTimingArr,
            this.colTimingDep});
            this.dgvTimings.Name = "dgvTimings";
            this.dgvTimings.RowHeadersVisible = false;
            this.dgvTimings.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvTimings_CellContentDoubleClick);
            this.dgvTimings.SelectionChanged += new System.EventHandler(this.DgvTimings_SelectionChanged);
            // 
            // colTimingLocation
            // 
            resources.ApplyResources(this.colTimingLocation, "colTimingLocation");
            this.colTimingLocation.Name = "colTimingLocation";
            // 
            // colTimingArr
            // 
            resources.ApplyResources(this.colTimingArr, "colTimingArr");
            this.colTimingArr.Name = "colTimingArr";
            // 
            // colTimingDep
            // 
            resources.ApplyResources(this.colTimingDep, "colTimingDep");
            this.colTimingDep.Name = "colTimingDep";
            // 
            // btnDeleteTiming
            // 
            resources.ApplyResources(this.btnDeleteTiming, "btnDeleteTiming");
            this.btnDeleteTiming.Name = "btnDeleteTiming";
            this.btnDeleteTiming.UseVisualStyleBackColor = true;
            this.btnDeleteTiming.Click += new System.EventHandler(this.BtnDeleteTiming_Click);
            // 
            // btnEditTiming
            // 
            resources.ApplyResources(this.btnEditTiming, "btnEditTiming");
            this.btnEditTiming.Name = "btnEditTiming";
            this.btnEditTiming.UseVisualStyleBackColor = true;
            this.btnEditTiming.Click += new System.EventHandler(this.BtnEditTiming_Click);
            // 
            // btnAddTiming
            // 
            resources.ApplyResources(this.btnAddTiming, "btnAddTiming");
            this.btnAddTiming.Name = "btnAddTiming";
            this.btnAddTiming.UseVisualStyleBackColor = true;
            this.btnAddTiming.Click += new System.EventHandler(this.BtnAddTiming_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.nudLineWidth);
            this.tabPage1.Controls.Add(this.btnColour);
            this.tabPage1.Controls.Add(this.cbLinePattern);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
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
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ckSeparatorBelow);
            this.tabPage2.Controls.Add(this.ckSeparatorAbove);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ckSeparatorBelow
            // 
            resources.ApplyResources(this.ckSeparatorBelow, "ckSeparatorBelow");
            this.ckSeparatorBelow.Name = "ckSeparatorBelow";
            this.ckSeparatorBelow.UseVisualStyleBackColor = true;
            this.ckSeparatorBelow.CheckedChanged += new System.EventHandler(this.CkSeparatorBelow_CheckedChanged);
            // 
            // ckSeparatorAbove
            // 
            resources.ApplyResources(this.ckSeparatorAbove, "ckSeparatorAbove");
            this.ckSeparatorAbove.Name = "ckSeparatorAbove";
            this.ckSeparatorAbove.UseVisualStyleBackColor = true;
            this.ckSeparatorAbove.CheckedChanged += new System.EventHandler(this.CkSeparatorAbove_CheckedChanged);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // TrainEditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "TrainEditForm";
            this.tabControl1.ResumeLayout(false);
            this.tabDetails.ResumeLayout(false);
            this.tabDetails.PerformLayout();
            this.tabTimings.ResumeLayout(false);
            this.tabTimings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimings)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDetails;
        private System.Windows.Forms.TextBox tbHeadcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabTimings;
        private System.Windows.Forms.DataGridView dgvTimings;
        private System.Windows.Forms.Button btnDeleteTiming;
        private System.Windows.Forms.Button btnEditTiming;
        private System.Windows.Forms.Button btnAddTiming;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimingLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimingArr;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimingDep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTrainClass;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.NumericUpDown nudLineWidth;
        private System.Windows.Forms.Button btnColour;
        private System.Windows.Forms.ComboBox cbLinePattern;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAdjust;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckedListBox clbFootnotes;
        private System.Windows.Forms.TextBox tbLocoDiagram;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox ckSeparatorBelow;
        private System.Windows.Forms.CheckBox ckSeparatorAbove;
        private System.Windows.Forms.TextBox tbInlineNote;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbToWorkText;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbToWorkHalfOfDay;
        private System.Windows.Forms.TextBox tbToWorkMinute;
        private System.Windows.Forms.TextBox tbToWorkHour;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbLocoToWorkHalfOfDay;
        private System.Windows.Forms.TextBox tbLocoToWorkText;
        private System.Windows.Forms.TextBox tbLocoToWorkHour;
        private System.Windows.Forms.TextBox tbLocoToWorkMinute;
    }
}