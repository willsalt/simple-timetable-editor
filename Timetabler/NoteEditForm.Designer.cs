namespace Timetabler
{
    partial class NoteEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteEditForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSymbol = new System.Windows.Forms.TextBox();
            this.tbDefinition = new System.Windows.Forms.TextBox();
            this.ckAppliesToTrains = new System.Windows.Forms.CheckBox();
            this.ckAppliesToTimings = new System.Windows.Forms.CheckBox();
            this.ckPageFootnote = new System.Windows.Forms.CheckBox();
            this.ckInGlossary = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            // tbSymbol
            // 
            resources.ApplyResources(this.tbSymbol, "tbSymbol");
            this.tbSymbol.Name = "tbSymbol";
            this.tbSymbol.Validated += new System.EventHandler(this.TbSymbol_Validated);
            // 
            // tbDefinition
            // 
            resources.ApplyResources(this.tbDefinition, "tbDefinition");
            this.tbDefinition.Name = "tbDefinition";
            this.tbDefinition.Validated += new System.EventHandler(this.TbDefinition_Validated);
            // 
            // ckAppliesToTrains
            // 
            resources.ApplyResources(this.ckAppliesToTrains, "ckAppliesToTrains");
            this.ckAppliesToTrains.Name = "ckAppliesToTrains";
            this.ckAppliesToTrains.UseVisualStyleBackColor = true;
            this.ckAppliesToTrains.CheckedChanged += new System.EventHandler(this.CkAppliesToTrains_CheckedChanged);
            // 
            // ckAppliesToTimings
            // 
            resources.ApplyResources(this.ckAppliesToTimings, "ckAppliesToTimings");
            this.ckAppliesToTimings.Name = "ckAppliesToTimings";
            this.ckAppliesToTimings.UseVisualStyleBackColor = true;
            this.ckAppliesToTimings.CheckedChanged += new System.EventHandler(this.CkAppliesToTimings_CheckedChanged);
            // 
            // ckPageFootnote
            // 
            resources.ApplyResources(this.ckPageFootnote, "ckPageFootnote");
            this.ckPageFootnote.Name = "ckPageFootnote";
            this.ckPageFootnote.UseVisualStyleBackColor = true;
            this.ckPageFootnote.CheckedChanged += new System.EventHandler(this.CkPageFootnote_CheckedChanged);
            // 
            // ckInGlossary
            // 
            resources.ApplyResources(this.ckInGlossary, "ckInGlossary");
            this.ckInGlossary.Name = "ckInGlossary";
            this.ckInGlossary.UseVisualStyleBackColor = true;
            this.ckInGlossary.CheckedChanged += new System.EventHandler(this.CkInGlossary_CheckedChanged);
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
            // NoteEditForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.ckInGlossary);
            this.Controls.Add(this.ckPageFootnote);
            this.Controls.Add(this.ckAppliesToTimings);
            this.Controls.Add(this.ckAppliesToTrains);
            this.Controls.Add(this.tbDefinition);
            this.Controls.Add(this.tbSymbol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NoteEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSymbol;
        private System.Windows.Forms.TextBox tbDefinition;
        private System.Windows.Forms.CheckBox ckAppliesToTrains;
        private System.Windows.Forms.CheckBox ckAppliesToTimings;
        private System.Windows.Forms.CheckBox ckPageFootnote;
        private System.Windows.Forms.CheckBox ckInGlossary;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}