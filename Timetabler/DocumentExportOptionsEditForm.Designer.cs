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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudLineWidth = new System.Windows.Forms.NumericUpDown();
            this.nudFillerDashLineWidth = new System.Windows.Forms.NumericUpDown();
            this.ckDisplayGraph = new System.Windows.Forms.CheckBox();
            this.ckDisplayGlossary = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFillerDashLineWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // ckDisplayLocoDiagram
            // 
            resources.ApplyResources(this.ckDisplayLocoDiagram, "ckDisplayLocoDiagram");
            this.ckDisplayLocoDiagram.Name = "ckDisplayLocoDiagram";
            this.ckDisplayLocoDiagram.UseVisualStyleBackColor = true;
            this.ckDisplayLocoDiagram.CheckedChanged += new System.EventHandler(this.ckDisplayLocoDiagram_CheckedChanged);
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
            this.ckDisplayToWorkRow.CheckedChanged += new System.EventHandler(this.ckDisplayToWorkRow_CheckedChanged);
            // 
            // ckDisplayBoxHours
            // 
            resources.ApplyResources(this.ckDisplayBoxHours, "ckDisplayBoxHours");
            this.ckDisplayBoxHours.Name = "ckDisplayBoxHours";
            this.ckDisplayBoxHours.UseVisualStyleBackColor = true;
            this.ckDisplayBoxHours.CheckedChanged += new System.EventHandler(this.ckDisplayBoxHours_CheckedChanged);
            // 
            // ckDisplayCredits
            // 
            resources.ApplyResources(this.ckDisplayCredits, "ckDisplayCredits");
            this.ckDisplayCredits.Name = "ckDisplayCredits";
            this.ckDisplayCredits.UseVisualStyleBackColor = true;
            this.ckDisplayCredits.CheckedChanged += new System.EventHandler(this.ckDisplayCredits_CheckedChanged);
            // 
            // ckDisplayLocoToWorkRow
            // 
            resources.ApplyResources(this.ckDisplayLocoToWorkRow, "ckDisplayLocoToWorkRow");
            this.ckDisplayLocoToWorkRow.Name = "ckDisplayLocoToWorkRow";
            this.ckDisplayLocoToWorkRow.UseVisualStyleBackColor = true;
            this.ckDisplayLocoToWorkRow.CheckedChanged += new System.EventHandler(this.ckDisplayLocoToWorkRow_CheckedChanged);
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
            this.nudLineWidth.ValueChanged += new System.EventHandler(this.nudLineWidth_ValueChanged);
            // 
            // nudFillerDashLineWidth
            // 
            this.nudFillerDashLineWidth.DecimalPlaces = 2;
            resources.ApplyResources(this.nudFillerDashLineWidth, "nudFillerDashLineWidth");
            this.nudFillerDashLineWidth.Name = "nudFillerDashLineWidth";
            this.nudFillerDashLineWidth.ValueChanged += new System.EventHandler(this.nudFillerDashLineWidth_ValueChanged);
            // 
            // ckDisplayGraph
            // 
            resources.ApplyResources(this.ckDisplayGraph, "ckDisplayGraph");
            this.ckDisplayGraph.Name = "ckDisplayGraph";
            this.ckDisplayGraph.UseVisualStyleBackColor = true;
            this.ckDisplayGraph.CheckedChanged += new System.EventHandler(this.ckDisplayGraph_CheckedChanged);
            // 
            // ckDisplayGlossary
            // 
            resources.ApplyResources(this.ckDisplayGlossary, "ckDisplayGlossary");
            this.ckDisplayGlossary.Name = "ckDisplayGlossary";
            this.ckDisplayGlossary.UseVisualStyleBackColor = true;
            this.ckDisplayGlossary.CheckedChanged += new System.EventHandler(this.ckDisplayGlossary_CheckedChanged);
            // 
            // DocumentExportOptionsEditForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ckDisplayGlossary);
            this.Controls.Add(this.ckDisplayGraph);
            this.Controls.Add(this.nudFillerDashLineWidth);
            this.Controls.Add(this.nudLineWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ckDisplayLocoToWorkRow);
            this.Controls.Add(this.ckDisplayCredits);
            this.Controls.Add(this.ckDisplayBoxHours);
            this.Controls.Add(this.ckDisplayToWorkRow);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ckDisplayLocoDiagram);
            this.Name = "DocumentExportOptionsEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.nudLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFillerDashLineWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}