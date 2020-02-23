namespace Timetabler
{
    partial class MainForm
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newEmptyFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFromTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locationsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.footnotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signalboxesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supportSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofdDocument = new System.Windows.Forms.OpenFileDialog();
            this.sfdDocument = new System.Windows.Forms.SaveFileDialog();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabDown = new System.Windows.Forms.TabPage();
            this.dgvDown = new System.Windows.Forms.DataGridView();
            this.colLocationIdDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocationDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrDepDown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabUp = new System.Windows.Forms.TabPage();
            this.dgvUp = new System.Windows.Forms.DataGridView();
            this.colLocationIdUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocationUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArrDepUp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabGraph = new System.Windows.Forms.TabPage();
            this.trainGraph = new Timetabler.Controls.TrainGraph();
            this.tabHours = new System.Windows.Forms.TabPage();
            this.dgvHours = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEdit = new System.Windows.Forms.Button();
            this.sfdLocations = new System.Windows.Forms.SaveFileDialog();
            this.ofdLocations = new System.Windows.Forms.OpenFileDialog();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSubtitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDateDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.btnDel = new System.Windows.Forms.Button();
            this.tbWrittenBy = new System.Windows.Forms.TextBox();
            this.tbCheckedBy = new System.Windows.Forms.TextBox();
            this.tbTimetableVersion = new System.Windows.Forms.TextBox();
            this.tbPublishedDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.sfdTemplate = new System.Windows.Forms.SaveFileDialog();
            this.ofdTemplate = new System.Windows.Forms.OpenFileDialog();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tabDown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDown)).BeginInit();
            this.tabUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUp)).BeginInit();
            this.tabGraph.SuspendLayout();
            this.tabHours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHours)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.templateToolStripMenuItem,
            this.exportToPDFToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newEmptyFileToolStripMenuItem,
            this.newFromTemplateToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            // 
            // newEmptyFileToolStripMenuItem
            // 
            this.newEmptyFileToolStripMenuItem.Name = "newEmptyFileToolStripMenuItem";
            resources.ApplyResources(this.newEmptyFileToolStripMenuItem, "newEmptyFileToolStripMenuItem");
            this.newEmptyFileToolStripMenuItem.Click += new System.EventHandler(this.NewEmptyDocumentEventHandler);
            // 
            // newFromTemplateToolStripMenuItem
            // 
            this.newFromTemplateToolStripMenuItem.Name = "newFromTemplateToolStripMenuItem";
            resources.ApplyResources(this.newFromTemplateToolStripMenuItem, "newFromTemplateToolStripMenuItem");
            this.newFromTemplateToolStripMenuItem.Click += new System.EventHandler(this.NewFromTemplateToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // templateToolStripMenuItem
            // 
            this.templateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsTemplateToolStripMenuItem});
            this.templateToolStripMenuItem.Name = "templateToolStripMenuItem";
            resources.ApplyResources(this.templateToolStripMenuItem, "templateToolStripMenuItem");
            // 
            // saveAsTemplateToolStripMenuItem
            // 
            this.saveAsTemplateToolStripMenuItem.Name = "saveAsTemplateToolStripMenuItem";
            resources.ApplyResources(this.saveAsTemplateToolStripMenuItem, "saveAsTemplateToolStripMenuItem");
            this.saveAsTemplateToolStripMenuItem.Click += new System.EventHandler(this.SaveAsTemplateToolStripMenuItem_Click);
            // 
            // exportToPDFToolStripMenuItem
            // 
            this.exportToPDFToolStripMenuItem.Name = "exportToPDFToolStripMenuItem";
            resources.ApplyResources(this.exportToPDFToolStripMenuItem, "exportToPDFToolStripMenuItem");
            this.exportToPDFToolStripMenuItem.Click += new System.EventHandler(this.ExportToPDFToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainClassesToolStripMenuItem,
            this.locationsToolStripMenuItem1,
            this.footnotesToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.exportOptionsToolStripMenuItem,
            this.signalboxesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            resources.ApplyResources(this.editToolStripMenuItem, "editToolStripMenuItem");
            // 
            // trainClassesToolStripMenuItem
            // 
            this.trainClassesToolStripMenuItem.Name = "trainClassesToolStripMenuItem";
            resources.ApplyResources(this.trainClassesToolStripMenuItem, "trainClassesToolStripMenuItem");
            this.trainClassesToolStripMenuItem.Click += new System.EventHandler(this.TrainClassesToolStripMenuItem_Click);
            // 
            // locationsToolStripMenuItem1
            // 
            this.locationsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.openTemplateToolStripMenuItem});
            this.locationsToolStripMenuItem1.Name = "locationsToolStripMenuItem1";
            resources.ApplyResources(this.locationsToolStripMenuItem1, "locationsToolStripMenuItem1");
            // 
            // editToolStripMenuItem1
            // 
            this.editToolStripMenuItem1.Name = "editToolStripMenuItem1";
            resources.ApplyResources(this.editToolStripMenuItem1, "editToolStripMenuItem1");
            this.editToolStripMenuItem1.Click += new System.EventHandler(this.LocationEditToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            resources.ApplyResources(this.saveToolStripMenuItem1, "saveToolStripMenuItem1");
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.LocationSaveToolStripMenuItem_Click);
            // 
            // openTemplateToolStripMenuItem
            // 
            this.openTemplateToolStripMenuItem.Name = "openTemplateToolStripMenuItem";
            resources.ApplyResources(this.openTemplateToolStripMenuItem, "openTemplateToolStripMenuItem");
            this.openTemplateToolStripMenuItem.Click += new System.EventHandler(this.OpenTemplateToolStripMenuItem_Click);
            // 
            // footnotesToolStripMenuItem
            // 
            this.footnotesToolStripMenuItem.Name = "footnotesToolStripMenuItem";
            resources.ApplyResources(this.footnotesToolStripMenuItem, "footnotesToolStripMenuItem");
            this.footnotesToolStripMenuItem.Click += new System.EventHandler(this.EditFootnotesToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.EditOptionsToolStripMenuItem_Click);
            // 
            // exportOptionsToolStripMenuItem
            // 
            this.exportOptionsToolStripMenuItem.Name = "exportOptionsToolStripMenuItem";
            resources.ApplyResources(this.exportOptionsToolStripMenuItem, "exportOptionsToolStripMenuItem");
            this.exportOptionsToolStripMenuItem.Click += new System.EventHandler(this.ExportOptionsToolStripMenuItem_Click);
            // 
            // signalboxesToolStripMenuItem
            // 
            this.signalboxesToolStripMenuItem.Name = "signalboxesToolStripMenuItem";
            resources.ApplyResources(this.signalboxesToolStripMenuItem, "signalboxesToolStripMenuItem");
            this.signalboxesToolStripMenuItem.Click += new System.EventHandler(this.SignalboxesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supportSettingsToolStripMenuItem,
            this.toolStripSeparator1,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // supportSettingsToolStripMenuItem
            // 
            this.supportSettingsToolStripMenuItem.Name = "supportSettingsToolStripMenuItem";
            resources.ApplyResources(this.supportSettingsToolStripMenuItem, "supportSettingsToolStripMenuItem");
            this.supportSettingsToolStripMenuItem.Click += new System.EventHandler(this.SupportSettingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(this.aboutToolStripMenuItem, "aboutToolStripMenuItem");
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // ofdDocument
            // 
            this.ofdDocument.DefaultExt = "wtt";
            resources.ApplyResources(this.ofdDocument, "ofdDocument");
            // 
            // sfdDocument
            // 
            this.sfdDocument.DefaultExt = "wtt";
            resources.ApplyResources(this.sfdDocument, "sfdDocument");
            this.sfdDocument.RestoreDirectory = true;
            // 
            // btnAdd
            // 
            resources.ApplyResources(this.btnAdd, "btnAdd");
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // tcMain
            // 
            resources.ApplyResources(this.tcMain, "tcMain");
            this.tcMain.Controls.Add(this.tabDown);
            this.tcMain.Controls.Add(this.tabUp);
            this.tcMain.Controls.Add(this.tabGraph);
            this.tcMain.Controls.Add(this.tabHours);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.TcMain_SelectedIndexChanged);
            // 
            // tabDown
            // 
            this.tabDown.Controls.Add(this.dgvDown);
            resources.ApplyResources(this.tabDown, "tabDown");
            this.tabDown.Name = "tabDown";
            this.tabDown.UseVisualStyleBackColor = true;
            // 
            // dgvDown
            // 
            this.dgvDown.AllowUserToAddRows = false;
            this.dgvDown.AllowUserToDeleteRows = false;
            this.dgvDown.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDown.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDown.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDown.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDown.ColumnHeadersVisible = false;
            this.dgvDown.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLocationIdDown,
            this.colLocationDown,
            this.colArrDepDown});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDown.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dgvDown, "dgvDown");
            this.dgvDown.Name = "dgvDown";
            this.dgvDown.ReadOnly = true;
            this.dgvDown.RowHeadersVisible = false;
            this.dgvDown.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDown_CellContentDoubleClick);
            this.dgvDown.SelectionChanged += new System.EventHandler(this.DgvDown_SelectionChanged);
            // 
            // colLocationIdDown
            // 
            this.colLocationIdDown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.colLocationIdDown, "colLocationIdDown");
            this.colLocationIdDown.Name = "colLocationIdDown";
            this.colLocationIdDown.ReadOnly = true;
            // 
            // colLocationDown
            // 
            this.colLocationDown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.colLocationDown, "colLocationDown");
            this.colLocationDown.Name = "colLocationDown";
            this.colLocationDown.ReadOnly = true;
            // 
            // colArrDepDown
            // 
            this.colArrDepDown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.colArrDepDown, "colArrDepDown");
            this.colArrDepDown.Name = "colArrDepDown";
            this.colArrDepDown.ReadOnly = true;
            // 
            // tabUp
            // 
            this.tabUp.Controls.Add(this.dgvUp);
            resources.ApplyResources(this.tabUp, "tabUp");
            this.tabUp.Name = "tabUp";
            this.tabUp.UseVisualStyleBackColor = true;
            // 
            // dgvUp
            // 
            this.dgvUp.AllowUserToAddRows = false;
            this.dgvUp.AllowUserToDeleteRows = false;
            this.dgvUp.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvUp.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUp.ColumnHeadersVisible = false;
            this.dgvUp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colLocationIdUp,
            this.colLocationUp,
            this.colArrDepUp});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUp.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.dgvUp, "dgvUp");
            this.dgvUp.Name = "dgvUp";
            this.dgvUp.ReadOnly = true;
            this.dgvUp.RowHeadersVisible = false;
            this.dgvUp.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvUp_CellContentDoubleClick);
            this.dgvUp.SelectionChanged += new System.EventHandler(this.DgvUp_SelectionChanged);
            // 
            // colLocationIdUp
            // 
            this.colLocationIdUp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.colLocationIdUp, "colLocationIdUp");
            this.colLocationIdUp.Name = "colLocationIdUp";
            this.colLocationIdUp.ReadOnly = true;
            // 
            // colLocationUp
            // 
            this.colLocationUp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.colLocationUp, "colLocationUp");
            this.colLocationUp.Name = "colLocationUp";
            this.colLocationUp.ReadOnly = true;
            // 
            // colArrDepUp
            // 
            this.colArrDepUp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            resources.ApplyResources(this.colArrDepUp, "colArrDepUp");
            this.colArrDepUp.Name = "colArrDepUp";
            this.colArrDepUp.ReadOnly = true;
            // 
            // tabGraph
            // 
            this.tabGraph.Controls.Add(this.trainGraph);
            resources.ApplyResources(this.tabGraph, "tabGraph");
            this.tabGraph.Name = "tabGraph";
            this.tabGraph.UseVisualStyleBackColor = true;
            // 
            // trainGraph
            // 
            this.trainGraph.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.trainGraph, "trainGraph");
            this.trainGraph.LocationAxisFont = new System.Drawing.Font("Cambria", 8F);
            this.trainGraph.Model = null;
            this.trainGraph.Name = "trainGraph";
            this.trainGraph.ShowVerticalGridLines = true;
            this.trainGraph.TimeAxisFont = new System.Drawing.Font("Cambria", 8F);
            this.trainGraph.TrainLabelFont = new System.Drawing.Font("Cambria", 8F);
            // 
            // tabHours
            // 
            this.tabHours.Controls.Add(this.dgvHours);
            resources.ApplyResources(this.tabHours, "tabHours");
            this.tabHours.Name = "tabHours";
            this.tabHours.UseVisualStyleBackColor = true;
            // 
            // dgvHours
            // 
            this.dgvHours.AllowUserToAddRows = false;
            this.dgvHours.AllowUserToDeleteRows = false;
            this.dgvHours.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvHours.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvHours.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHours.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHours.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colCategory});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Cambria", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHours.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.dgvHours, "dgvHours");
            this.dgvHours.Name = "dgvHours";
            this.dgvHours.RowHeadersVisible = false;
            // 
            // colId
            // 
            resources.ApplyResources(this.colId, "colId");
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colCategory
            // 
            resources.ApplyResources(this.colCategory, "colCategory");
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // btnEdit
            // 
            resources.ApplyResources(this.btnEdit, "btnEdit");
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // sfdLocations
            // 
            this.sfdLocations.DefaultExt = "wtl";
            resources.ApplyResources(this.sfdLocations, "sfdLocations");
            // 
            // ofdLocations
            // 
            this.ofdLocations.DefaultExt = "wtl";
            resources.ApplyResources(this.ofdLocations, "ofdLocations");
            // 
            // tbTitle
            // 
            resources.ApplyResources(this.tbTitle, "tbTitle");
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.TextChanged += new System.EventHandler(this.TbTitle_TextChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tbSubtitle
            // 
            resources.ApplyResources(this.tbSubtitle, "tbSubtitle");
            this.tbSubtitle.Name = "tbSubtitle";
            this.tbSubtitle.TextChanged += new System.EventHandler(this.TbSubtitle_TextChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tbDateDescription
            // 
            resources.ApplyResources(this.tbDateDescription, "tbDateDescription");
            this.tbDateDescription.Name = "tbDateDescription";
            this.tbDateDescription.TextChanged += new System.EventHandler(this.TbDateDescription_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // sfdExport
            // 
            this.sfdExport.DefaultExt = "pdf";
            resources.ApplyResources(this.sfdExport, "sfdExport");
            // 
            // btnDel
            // 
            resources.ApplyResources(this.btnDel, "btnDel");
            this.btnDel.Name = "btnDel";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.BtnDel_Click);
            // 
            // tbWrittenBy
            // 
            resources.ApplyResources(this.tbWrittenBy, "tbWrittenBy");
            this.tbWrittenBy.Name = "tbWrittenBy";
            this.tbWrittenBy.TextChanged += new System.EventHandler(this.TbWrittenBy_TextChanged);
            // 
            // tbCheckedBy
            // 
            resources.ApplyResources(this.tbCheckedBy, "tbCheckedBy");
            this.tbCheckedBy.Name = "tbCheckedBy";
            this.tbCheckedBy.TextChanged += new System.EventHandler(this.TbCheckedBy_TextChanged);
            // 
            // tbTimetableVersion
            // 
            resources.ApplyResources(this.tbTimetableVersion, "tbTimetableVersion");
            this.tbTimetableVersion.Name = "tbTimetableVersion";
            this.tbTimetableVersion.TextChanged += new System.EventHandler(this.TbTimetableVersion_TextChanged);
            // 
            // tbPublishedDate
            // 
            resources.ApplyResources(this.tbPublishedDate, "tbPublishedDate");
            this.tbPublishedDate.Name = "tbPublishedDate";
            this.tbPublishedDate.TextChanged += new System.EventHandler(this.TbPublishedDate_TextChanged);
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
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 3, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.tbWrittenBy);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Name = "panel1";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.tbCheckedBy);
            this.panel2.Name = "panel2";
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.tbTimetableVersion);
            this.panel3.Name = "panel3";
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.tbPublishedDate);
            this.panel4.Name = "panel4";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.panel5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // panel5
            // 
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.tbSubtitle);
            this.panel5.Name = "panel5";
            // 
            // panel6
            // 
            resources.ApplyResources(this.panel6, "panel6");
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.tbDateDescription);
            this.panel6.Name = "panel6";
            // 
            // sfdTemplate
            // 
            this.sfdTemplate.DefaultExt = "wtm";
            resources.ApplyResources(this.sfdTemplate, "sfdTemplate");
            this.sfdTemplate.RestoreDirectory = true;
            // 
            // ofdTemplate
            // 
            this.ofdTemplate.DefaultExt = "wtm";
            resources.ApplyResources(this.ofdTemplate, "ofdTemplate");
            this.ofdTemplate.RestoreDirectory = true;
            // 
            // btnCopy
            // 
            resources.ApplyResources(this.btnCopy, "btnCopy");
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // btnReverse
            // 
            resources.ApplyResources(this.btnReverse, "btnReverse");
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.BtnReverse_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tabDown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDown)).EndInit();
            this.tabUp.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUp)).EndInit();
            this.tabGraph.ResumeLayout(false);
            this.tabHours.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHours)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdDocument;
        private System.Windows.Forms.SaveFileDialog sfdDocument;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tabDown;
        private System.Windows.Forms.TabPage tabUp;
        private System.Windows.Forms.TabPage tabGraph;
        private System.Windows.Forms.DataGridView dgvDown;
        private System.Windows.Forms.DataGridView dgvUp;
        private Controls.TrainGraph trainGraph;
        private System.Windows.Forms.ToolStripMenuItem trainClassesToolStripMenuItem;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ToolStripMenuItem locationsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openTemplateToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdLocations;
        private System.Windows.Forms.OpenFileDialog ofdLocations;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem footnotesToolStripMenuItem;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSubtitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDateDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem exportToPDFToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdExport;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox tbWrittenBy;
        private System.Windows.Forms.TextBox tbCheckedBy;
        private System.Windows.Forms.TextBox tbTimetableVersion;
        private System.Windows.Forms.TextBox tbPublishedDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.ToolStripMenuItem exportOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsTemplateToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfdTemplate;
        private System.Windows.Forms.ToolStripMenuItem newEmptyFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFromTemplateToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofdTemplate;
        private System.Windows.Forms.ToolStripMenuItem signalboxesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabPage tabHours;
        private System.Windows.Forms.DataGridView dgvHours;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.ToolStripMenuItem supportSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocationIdDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocationDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrDepDown;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocationIdUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocationUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArrDepUp;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnReverse;
    }
}

