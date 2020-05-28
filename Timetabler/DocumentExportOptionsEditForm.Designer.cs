namespace Timetabler
{
    partial class DocumentExportOptionsEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentExportOptionsEditForm));
            this.ckDisplayLocoDiagram = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ckDisplayToWorkRow = new System.Windows.Forms.CheckBox();
            this.ckDisplayBoxHours = new System.Windows.Forms.CheckBox();
            this.ckDisplayCredits = new System.Windows.Forms.CheckBox();
            this.ckDisplayLocoToWorkRow = new System.Windows.Forms.CheckBox();
            this.ckDisplayGraph = new System.Windows.Forms.CheckBox();
            this.ckDisplayGlossary = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbGraphOrientation = new System.Windows.Forms.ComboBox();
            this.cbTableOrientation = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbPdfEngine = new System.Windows.Forms.ComboBox();
            this.lblWarning = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nudGraphAxisLineWidth = new System.Windows.Forms.NumericUpDown();
            this.nudFillerDashLineWidth = new System.Windows.Forms.NumericUpDown();
            this.nudLineWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbUpSectionLabel = new System.Windows.Forms.TextBox();
            this.tbDownSectionLabel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGraphAxisLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFillerDashLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ckDisplayLocoDiagram
            // 
            resources.ApplyResources(this.ckDisplayLocoDiagram, "ckDisplayLocoDiagram");
            this.ckDisplayLocoDiagram.Name = "ckDisplayLocoDiagram";
            this.ckDisplayLocoDiagram.UseVisualStyleBackColor = true;
            this.ckDisplayLocoDiagram.CheckedChanged += new System.EventHandler(this.CkDisplayLocoDiagram_CheckedChanged);
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
            // ckDisplayToWorkRow
            // 
            resources.ApplyResources(this.ckDisplayToWorkRow, "ckDisplayToWorkRow");
            this.ckDisplayToWorkRow.Name = "ckDisplayToWorkRow";
            this.ckDisplayToWorkRow.UseVisualStyleBackColor = true;
            this.ckDisplayToWorkRow.CheckedChanged += new System.EventHandler(this.CkDisplayToWorkRow_CheckedChanged);
            // 
            // ckDisplayBoxHours
            // 
            resources.ApplyResources(this.ckDisplayBoxHours, "ckDisplayBoxHours");
            this.ckDisplayBoxHours.Name = "ckDisplayBoxHours";
            this.ckDisplayBoxHours.UseVisualStyleBackColor = true;
            this.ckDisplayBoxHours.CheckedChanged += new System.EventHandler(this.CkDisplayBoxHours_CheckedChanged);
            // 
            // ckDisplayCredits
            // 
            resources.ApplyResources(this.ckDisplayCredits, "ckDisplayCredits");
            this.ckDisplayCredits.Name = "ckDisplayCredits";
            this.ckDisplayCredits.UseVisualStyleBackColor = true;
            this.ckDisplayCredits.CheckedChanged += new System.EventHandler(this.CkDisplayCredits_CheckedChanged);
            // 
            // ckDisplayLocoToWorkRow
            // 
            resources.ApplyResources(this.ckDisplayLocoToWorkRow, "ckDisplayLocoToWorkRow");
            this.ckDisplayLocoToWorkRow.Name = "ckDisplayLocoToWorkRow";
            this.ckDisplayLocoToWorkRow.UseVisualStyleBackColor = true;
            this.ckDisplayLocoToWorkRow.CheckedChanged += new System.EventHandler(this.CkDisplayLocoToWorkRow_CheckedChanged);
            // 
            // ckDisplayGraph
            // 
            resources.ApplyResources(this.ckDisplayGraph, "ckDisplayGraph");
            this.ckDisplayGraph.Name = "ckDisplayGraph";
            this.ckDisplayGraph.UseVisualStyleBackColor = true;
            this.ckDisplayGraph.CheckedChanged += new System.EventHandler(this.CkDisplayGraph_CheckedChanged);
            // 
            // ckDisplayGlossary
            // 
            resources.ApplyResources(this.ckDisplayGlossary, "ckDisplayGlossary");
            this.ckDisplayGlossary.Name = "ckDisplayGlossary";
            this.ckDisplayGlossary.UseVisualStyleBackColor = true;
            this.ckDisplayGlossary.CheckedChanged += new System.EventHandler(this.CkDisplayGlossary_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
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
            // cbGraphOrientation
            // 
            this.cbGraphOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGraphOrientation.FormattingEnabled = true;
            resources.ApplyResources(this.cbGraphOrientation, "cbGraphOrientation");
            this.cbGraphOrientation.Name = "cbGraphOrientation";
            this.cbGraphOrientation.SelectedIndexChanged += new System.EventHandler(this.CbGraphOrientation_SelectedIndexChanged);
            // 
            // cbTableOrientation
            // 
            this.cbTableOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTableOrientation.FormattingEnabled = true;
            resources.ApplyResources(this.cbTableOrientation, "cbTableOrientation");
            this.cbTableOrientation.Name = "cbTableOrientation";
            this.cbTableOrientation.SelectedIndexChanged += new System.EventHandler(this.CbTableOrientation_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.nudGraphAxisLineWidth);
            this.tabPage2.Controls.Add(this.nudFillerDashLineWidth);
            this.tabPage2.Controls.Add(this.nudLineWidth);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cbPdfEngine);
            this.tabPage2.Controls.Add(this.lblWarning);
            this.tabPage2.Controls.Add(this.label3);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            // 
            // cbPdfEngine
            // 
            this.cbPdfEngine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPdfEngine.FormattingEnabled = true;
            resources.ApplyResources(this.cbPdfEngine, "cbPdfEngine");
            this.cbPdfEngine.Name = "cbPdfEngine";
            this.cbPdfEngine.SelectedIndexChanged += new System.EventHandler(this.CbPdfEngine_SelectedIndexChanged);
            // 
            // lblWarning
            // 
            resources.ApplyResources(this.lblWarning, "lblWarning");
            this.lblWarning.Name = "lblWarning";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // nudGraphAxisLineWidth
            // 
            this.nudGraphAxisLineWidth.DecimalPlaces = 2;
            resources.ApplyResources(this.nudGraphAxisLineWidth, "nudGraphAxisLineWidth");
            this.nudGraphAxisLineWidth.Name = "nudGraphAxisLineWidth";
            // 
            // nudFillerDashLineWidth
            // 
            this.nudFillerDashLineWidth.DecimalPlaces = 2;
            resources.ApplyResources(this.nudFillerDashLineWidth, "nudFillerDashLineWidth");
            this.nudFillerDashLineWidth.Name = "nudFillerDashLineWidth";
            // 
            // nudLineWidth
            // 
            this.nudLineWidth.DecimalPlaces = 2;
            resources.ApplyResources(this.nudLineWidth, "nudLineWidth");
            this.nudLineWidth.Name = "nudLineWidth";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.ckDisplayLocoDiagram);
            this.groupBox1.Controls.Add(this.ckDisplayLocoToWorkRow);
            this.groupBox1.Controls.Add(this.ckDisplayCredits);
            this.groupBox1.Controls.Add(this.ckDisplayBoxHours);
            this.groupBox1.Controls.Add(this.ckDisplayGraph);
            this.groupBox1.Controls.Add(this.ckDisplayToWorkRow);
            this.groupBox1.Controls.Add(this.ckDisplayGlossary);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbDownSectionLabel);
            this.groupBox2.Controls.Add(this.tbUpSectionLabel);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.cbTableOrientation);
            this.groupBox3.Controls.Add(this.cbGraphOrientation);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // tbUpSectionLabel
            // 
            resources.ApplyResources(this.tbUpSectionLabel, "tbUpSectionLabel");
            this.tbUpSectionLabel.Name = "tbUpSectionLabel";
            this.tbUpSectionLabel.TextChanged += new System.EventHandler(this.TbUpSectionLabel_TextChanged);
            // 
            // tbDownSectionLabel
            // 
            resources.ApplyResources(this.tbDownSectionLabel, "tbDownSectionLabel");
            this.tbDownSectionLabel.Name = "tbDownSectionLabel";
            this.tbDownSectionLabel.TextChanged += new System.EventHandler(this.TbDownSectionLabel_TextChanged);
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
            // DocumentExportOptionsEditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "DocumentExportOptionsEditForm";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudGraphAxisLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFillerDashLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox ckDisplayLocoDiagram;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox ckDisplayToWorkRow;
        private System.Windows.Forms.CheckBox ckDisplayBoxHours;
        private System.Windows.Forms.CheckBox ckDisplayCredits;
        private System.Windows.Forms.CheckBox ckDisplayLocoToWorkRow;
        private System.Windows.Forms.CheckBox ckDisplayGraph;
        private System.Windows.Forms.CheckBox ckDisplayGlossary;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbPdfEngine;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbGraphOrientation;
        private System.Windows.Forms.ComboBox cbTableOrientation;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbDownSectionLabel;
        private System.Windows.Forms.TextBox tbUpSectionLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudGraphAxisLineWidth;
        private System.Windows.Forms.NumericUpDown nudFillerDashLineWidth;
        private System.Windows.Forms.NumericUpDown nudLineWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}