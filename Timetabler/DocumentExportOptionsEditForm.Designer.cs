﻿namespace Timetabler
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudLineWidth = new System.Windows.Forms.NumericUpDown();
            this.nudFillerDashLineWidth = new System.Windows.Forms.NumericUpDown();
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
            this.cbFontChoice = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFillerDashLineWidth)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            // nudLineWidth
            // 
            this.nudLineWidth.DecimalPlaces = 2;
            resources.ApplyResources(this.nudLineWidth, "nudLineWidth");
            this.nudLineWidth.Name = "nudLineWidth";
            this.nudLineWidth.ValueChanged += new System.EventHandler(this.NudLineWidth_ValueChanged);
            // 
            // nudFillerDashLineWidth
            // 
            this.nudFillerDashLineWidth.DecimalPlaces = 2;
            resources.ApplyResources(this.nudFillerDashLineWidth, "nudFillerDashLineWidth");
            this.nudFillerDashLineWidth.Name = "nudFillerDashLineWidth";
            this.nudFillerDashLineWidth.ValueChanged += new System.EventHandler(this.NudFillerDashLineWidth_ValueChanged);
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
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cbGraphOrientation);
            this.tabPage1.Controls.Add(this.cbTableOrientation);
            this.tabPage1.Controls.Add(this.ckDisplayLocoDiagram);
            this.tabPage1.Controls.Add(this.ckDisplayGlossary);
            this.tabPage1.Controls.Add(this.ckDisplayToWorkRow);
            this.tabPage1.Controls.Add(this.ckDisplayGraph);
            this.tabPage1.Controls.Add(this.ckDisplayBoxHours);
            this.tabPage1.Controls.Add(this.nudFillerDashLineWidth);
            this.tabPage1.Controls.Add(this.ckDisplayCredits);
            this.tabPage1.Controls.Add(this.nudLineWidth);
            this.tabPage1.Controls.Add(this.ckDisplayLocoToWorkRow);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
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
            this.tabPage2.Controls.Add(this.cbFontChoice);
            this.tabPage2.Controls.Add(this.label6);
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
            // cbFontChoice
            // 
            this.cbFontChoice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontChoice.FormattingEnabled = true;
            resources.ApplyResources(this.cbFontChoice, "cbFontChoice");
            this.cbFontChoice.Name = "cbFontChoice";
            this.cbFontChoice.SelectedIndexChanged += new System.EventHandler(this.CbFontChoice_SelectedIndexChanged);
            // 
            // DocumentExportOptionsEditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "DocumentExportOptionsEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFillerDashLineWidth)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudLineWidth;
        private System.Windows.Forms.NumericUpDown nudFillerDashLineWidth;
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
        private System.Windows.Forms.ComboBox cbFontChoice;
        private System.Windows.Forms.Label label6;
    }
}