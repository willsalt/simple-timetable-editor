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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentOptionsEditForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbClockType = new System.Windows.Forms.ComboBox();
            this.ckDisplayTrainLabelsOnGraphs = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbGraphEditStyle = new System.Windows.Forms.ComboBox();
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
            this.cbClockType.SelectedIndexChanged += new System.EventHandler(this.cbClockType_SelectedIndexChanged);
            // 
            // ckDisplayTrainLabelsOnGraphs
            // 
            resources.ApplyResources(this.ckDisplayTrainLabelsOnGraphs, "ckDisplayTrainLabelsOnGraphs");
            this.ckDisplayTrainLabelsOnGraphs.Name = "ckDisplayTrainLabelsOnGraphs";
            this.ckDisplayTrainLabelsOnGraphs.UseVisualStyleBackColor = true;
            this.ckDisplayTrainLabelsOnGraphs.CheckedChanged += new System.EventHandler(this.ckDisplayTrainLabelsOnGraphs_CheckedChanged);
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
            this.cbGraphEditStyle.SelectedIndexChanged += new System.EventHandler(this.cbGraphEditStyle_SelectedIndexChanged);
            // 
            // DocumentOptionsEditForm
            // 
            this.AcceptButton = this.btnOk;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.cbGraphEditStyle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ckDisplayTrainLabelsOnGraphs);
            this.Controls.Add(this.cbClockType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "DocumentOptionsEditForm";
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
    }
}