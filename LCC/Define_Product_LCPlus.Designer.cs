
namespace LCC
{
    partial class Define_Product_LCPlus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Define_Product_LCPlus));
            this.tabpage = new System.Windows.Forms.TabControl();
            this.Product_Cost = new System.Windows.Forms.TabPage();
            this.lblNoteProduct = new System.Windows.Forms.Label();
            this.btnClearProduct = new System.Windows.Forms.Button();
            this.btnSideProduct = new System.Windows.Forms.Button();
            this.btnAddMainProduct = new System.Windows.Forms.Button();
            this.cbbSideProduct = new System.Windows.Forms.ComboBox();
            this.cbbMainProduct = new System.Windows.Forms.ComboBox();
            this.lblSideProduct = new System.Windows.Forms.Label();
            this.lblMainProduct = new System.Windows.Forms.Label();
            this.lblProductFile = new System.Windows.Forms.Label();
            this.txtProductFile = new System.Windows.Forms.TextBox();
            this.pbDefineProduct = new System.Windows.Forms.PictureBox();
            this.btnNextProduct = new System.Windows.Forms.Button();
            this.gbSideProduct = new System.Windows.Forms.GroupBox();
            this.dgvSideProduct = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbProduct = new System.Windows.Forms.GroupBox();
            this.dgvMainProduct = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stream_Cost = new System.Windows.Forms.TabPage();
            this.DefineStreamTab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblNoteStream = new System.Windows.Forms.Label();
            this.btnClearStream = new System.Windows.Forms.Button();
            this.btnNextStreamTable = new System.Windows.Forms.Button();
            this.btnAddStreamOutput = new System.Windows.Forms.Button();
            this.cbbStreamOutput = new System.Windows.Forms.ComboBox();
            this.lblStream_Output = new System.Windows.Forms.Label();
            this.gbStreamOutput_OpC = new System.Windows.Forms.GroupBox();
            this.dgvStreamOutput_OpC = new System.Windows.Forms.DataGridView();
            this.List_StreamOutput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddStreamInput = new System.Windows.Forms.Button();
            this.cbbStreamInput = new System.Windows.Forms.ComboBox();
            this.lblStream_Input = new System.Windows.Forms.Label();
            this.gbStreamInput_OpC = new System.Windows.Forms.GroupBox();
            this.dgvStream_OpC = new System.Windows.Forms.DataGridView();
            this.List_StreamInput = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbRawStreamTable = new System.Windows.Forms.GroupBox();
            this.dgvStreamTablePreview = new System.Windows.Forms.DataGridView();
            this.pbProduct = new System.Windows.Forms.PictureBox();
            this.lblStreamFile = new System.Windows.Forms.Label();
            this.txtStreamtable = new System.Windows.Forms.TextBox();
            this.Equipment_Cost = new System.Windows.Forms.TabPage();
            this.Eqip_Control = new System.Windows.Forms.TabControl();
            this.EquipSelect = new System.Windows.Forms.TabPage();
            this.txtCPI_Index = new System.Windows.Forms.TextBox();
            this.lblCPI_Index = new System.Windows.Forms.Label();
            this.btnSave_DefineEquip = new System.Windows.Forms.Button();
            this.gbEquipmentSelection = new System.Windows.Forms.GroupBox();
            this.dgvEquipmentSummary = new System.Windows.Forms.DataGridView();
            this.EquipPreview = new System.Windows.Forms.TabPage();
            this.gbEquipmentTable = new System.Windows.Forms.GroupBox();
            this.dgvEquipmentPreview = new System.Windows.Forms.DataGridView();
            this.pbEquipment = new System.Windows.Forms.PictureBox();
            this.lblEquipmentLocation = new System.Windows.Forms.Label();
            this.txtEquipmentFile = new System.Windows.Forms.TextBox();
            this.tabpage.SuspendLayout();
            this.Product_Cost.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDefineProduct)).BeginInit();
            this.gbSideProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSideProduct)).BeginInit();
            this.gbProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainProduct)).BeginInit();
            this.Stream_Cost.SuspendLayout();
            this.DefineStreamTab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbStreamOutput_OpC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStreamOutput_OpC)).BeginInit();
            this.gbStreamInput_OpC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStream_OpC)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.gbRawStreamTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStreamTablePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProduct)).BeginInit();
            this.Equipment_Cost.SuspendLayout();
            this.Eqip_Control.SuspendLayout();
            this.EquipSelect.SuspendLayout();
            this.gbEquipmentSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipmentSummary)).BeginInit();
            this.EquipPreview.SuspendLayout();
            this.gbEquipmentTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipmentPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEquipment)).BeginInit();
            this.SuspendLayout();
            // 
            // tabpage
            // 
            this.tabpage.Controls.Add(this.Product_Cost);
            this.tabpage.Controls.Add(this.Stream_Cost);
            this.tabpage.Controls.Add(this.Equipment_Cost);
            this.tabpage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabpage.Location = new System.Drawing.Point(13, 21);
            this.tabpage.Name = "tabpage";
            this.tabpage.SelectedIndex = 0;
            this.tabpage.Size = new System.Drawing.Size(1243, 600);
            this.tabpage.TabIndex = 1;
            this.tabpage.SelectedIndexChanged += new System.EventHandler(this.tabpage_SelectedIndexChanged);
            this.tabpage.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabpage_Selected);
            // 
            // Product_Cost
            // 
            this.Product_Cost.Controls.Add(this.lblNoteProduct);
            this.Product_Cost.Controls.Add(this.btnClearProduct);
            this.Product_Cost.Controls.Add(this.btnSideProduct);
            this.Product_Cost.Controls.Add(this.btnAddMainProduct);
            this.Product_Cost.Controls.Add(this.cbbSideProduct);
            this.Product_Cost.Controls.Add(this.cbbMainProduct);
            this.Product_Cost.Controls.Add(this.lblSideProduct);
            this.Product_Cost.Controls.Add(this.lblMainProduct);
            this.Product_Cost.Controls.Add(this.lblProductFile);
            this.Product_Cost.Controls.Add(this.txtProductFile);
            this.Product_Cost.Controls.Add(this.pbDefineProduct);
            this.Product_Cost.Controls.Add(this.btnNextProduct);
            this.Product_Cost.Controls.Add(this.gbSideProduct);
            this.Product_Cost.Controls.Add(this.gbProduct);
            this.Product_Cost.Location = new System.Drawing.Point(4, 31);
            this.Product_Cost.Name = "Product_Cost";
            this.Product_Cost.Size = new System.Drawing.Size(1235, 565);
            this.Product_Cost.TabIndex = 9;
            this.Product_Cost.Text = "Defined Product";
            this.Product_Cost.UseVisualStyleBackColor = true;
            this.Product_Cost.Click += new System.EventHandler(this.Product_Cost_Click);
            // 
            // lblNoteProduct
            // 
            this.lblNoteProduct.AutoSize = true;
            this.lblNoteProduct.ForeColor = System.Drawing.Color.Blue;
            this.lblNoteProduct.Location = new System.Drawing.Point(22, 522);
            this.lblNoteProduct.Name = "lblNoteProduct";
            this.lblNoteProduct.Size = new System.Drawing.Size(643, 22);
            this.lblNoteProduct.TabIndex = 58;
            this.lblNoteProduct.Text = "***To delete a row in the table, please click the Delete button on your keyboard." +
    "";
            // 
            // btnClearProduct
            // 
            this.btnClearProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearProduct.Location = new System.Drawing.Point(920, 513);
            this.btnClearProduct.Name = "btnClearProduct";
            this.btnClearProduct.Size = new System.Drawing.Size(146, 39);
            this.btnClearProduct.TabIndex = 57;
            this.btnClearProduct.Text = "Clear All";
            this.btnClearProduct.UseVisualStyleBackColor = true;
            this.btnClearProduct.Click += new System.EventHandler(this.btnClearProduct_Click);
            // 
            // btnSideProduct
            // 
            this.btnSideProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSideProduct.Location = new System.Drawing.Point(1097, 80);
            this.btnSideProduct.Name = "btnSideProduct";
            this.btnSideProduct.Size = new System.Drawing.Size(99, 39);
            this.btnSideProduct.TabIndex = 56;
            this.btnSideProduct.Text = "Add";
            this.btnSideProduct.UseVisualStyleBackColor = true;
            this.btnSideProduct.Click += new System.EventHandler(this.btnSideProduct_Click);
            // 
            // btnAddMainProduct
            // 
            this.btnAddMainProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMainProduct.Location = new System.Drawing.Point(501, 79);
            this.btnAddMainProduct.Name = "btnAddMainProduct";
            this.btnAddMainProduct.Size = new System.Drawing.Size(99, 39);
            this.btnAddMainProduct.TabIndex = 55;
            this.btnAddMainProduct.Text = "Add";
            this.btnAddMainProduct.UseVisualStyleBackColor = true;
            this.btnAddMainProduct.Click += new System.EventHandler(this.btnAddMainProduct_Click);
            // 
            // cbbSideProduct
            // 
            this.cbbSideProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSideProduct.FormattingEnabled = true;
            this.cbbSideProduct.Location = new System.Drawing.Point(920, 85);
            this.cbbSideProduct.Name = "cbbSideProduct";
            this.cbbSideProduct.Size = new System.Drawing.Size(162, 30);
            this.cbbSideProduct.TabIndex = 54;
            // 
            // cbbMainProduct
            // 
            this.cbbMainProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMainProduct.FormattingEnabled = true;
            this.cbbMainProduct.Location = new System.Drawing.Point(310, 85);
            this.cbbMainProduct.Name = "cbbMainProduct";
            this.cbbMainProduct.Size = new System.Drawing.Size(175, 30);
            this.cbbMainProduct.TabIndex = 53;
            // 
            // lblSideProduct
            // 
            this.lblSideProduct.AutoSize = true;
            this.lblSideProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSideProduct.Location = new System.Drawing.Point(647, 86);
            this.lblSideProduct.Name = "lblSideProduct";
            this.lblSideProduct.Size = new System.Drawing.Size(251, 25);
            this.lblSideProduct.TabIndex = 52;
            this.lblSideProduct.Text = "Please select Side Product:";
            // 
            // lblMainProduct
            // 
            this.lblMainProduct.AutoSize = true;
            this.lblMainProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainProduct.Location = new System.Drawing.Point(31, 86);
            this.lblMainProduct.Name = "lblMainProduct";
            this.lblMainProduct.Size = new System.Drawing.Size(254, 25);
            this.lblMainProduct.TabIndex = 51;
            this.lblMainProduct.Text = "Please select Main Product:";
            // 
            // lblProductFile
            // 
            this.lblProductFile.AutoSize = true;
            this.lblProductFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductFile.Location = new System.Drawing.Point(106, 22);
            this.lblProductFile.Name = "lblProductFile";
            this.lblProductFile.Size = new System.Drawing.Size(193, 25);
            this.lblProductFile.TabIndex = 50;
            this.lblProductFile.Text = "Product file Location:";
            // 
            // txtProductFile
            // 
            this.txtProductFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductFile.Location = new System.Drawing.Point(317, 22);
            this.txtProductFile.Name = "txtProductFile";
            this.txtProductFile.ReadOnly = true;
            this.txtProductFile.Size = new System.Drawing.Size(899, 28);
            this.txtProductFile.TabIndex = 49;
            // 
            // pbDefineProduct
            // 
            this.pbDefineProduct.Image = ((System.Drawing.Image)(resources.GetObject("pbDefineProduct.Image")));
            this.pbDefineProduct.Location = new System.Drawing.Point(23, 13);
            this.pbDefineProduct.Name = "pbDefineProduct";
            this.pbDefineProduct.Size = new System.Drawing.Size(56, 45);
            this.pbDefineProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDefineProduct.TabIndex = 45;
            this.pbDefineProduct.TabStop = false;
            // 
            // btnNextProduct
            // 
            this.btnNextProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextProduct.Location = new System.Drawing.Point(1076, 513);
            this.btnNextProduct.Name = "btnNextProduct";
            this.btnNextProduct.Size = new System.Drawing.Size(146, 39);
            this.btnNextProduct.TabIndex = 44;
            this.btnNextProduct.Text = "Next";
            this.btnNextProduct.UseVisualStyleBackColor = true;
            this.btnNextProduct.Click += new System.EventHandler(this.btnNextProduct_Click);
            // 
            // gbSideProduct
            // 
            this.gbSideProduct.Controls.Add(this.dgvSideProduct);
            this.gbSideProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSideProduct.Location = new System.Drawing.Point(642, 144);
            this.gbSideProduct.Name = "gbSideProduct";
            this.gbSideProduct.Size = new System.Drawing.Size(580, 363);
            this.gbSideProduct.TabIndex = 25;
            this.gbSideProduct.TabStop = false;
            this.gbSideProduct.Text = "Side Product Summary:";
            // 
            // dgvSideProduct
            // 
            this.dgvSideProduct.AllowUserToAddRows = false;
            this.dgvSideProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSideProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.dgvSideProduct.Location = new System.Drawing.Point(10, 32);
            this.dgvSideProduct.Name = "dgvSideProduct";
            this.dgvSideProduct.ReadOnly = true;
            this.dgvSideProduct.RowHeadersWidth = 51;
            this.dgvSideProduct.RowTemplate.Height = 24;
            this.dgvSideProduct.Size = new System.Drawing.Size(564, 318);
            this.dgvSideProduct.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "List of Side Product";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // gbProduct
            // 
            this.gbProduct.Controls.Add(this.dgvMainProduct);
            this.gbProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbProduct.Location = new System.Drawing.Point(26, 144);
            this.gbProduct.Name = "gbProduct";
            this.gbProduct.Size = new System.Drawing.Size(580, 363);
            this.gbProduct.TabIndex = 24;
            this.gbProduct.TabStop = false;
            this.gbProduct.Text = "Main Product Summary:";
            // 
            // dgvMainProduct
            // 
            this.dgvMainProduct.AllowUserToAddRows = false;
            this.dgvMainProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMainProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dgvMainProduct.Location = new System.Drawing.Point(10, 32);
            this.dgvMainProduct.Name = "dgvMainProduct";
            this.dgvMainProduct.ReadOnly = true;
            this.dgvMainProduct.RowHeadersWidth = 51;
            this.dgvMainProduct.RowTemplate.Height = 24;
            this.dgvMainProduct.Size = new System.Drawing.Size(564, 318);
            this.dgvMainProduct.TabIndex = 4;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "List of Main Product";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // Stream_Cost
            // 
            this.Stream_Cost.Controls.Add(this.DefineStreamTab);
            this.Stream_Cost.Controls.Add(this.pbProduct);
            this.Stream_Cost.Controls.Add(this.lblStreamFile);
            this.Stream_Cost.Controls.Add(this.txtStreamtable);
            this.Stream_Cost.Location = new System.Drawing.Point(4, 31);
            this.Stream_Cost.Name = "Stream_Cost";
            this.Stream_Cost.Padding = new System.Windows.Forms.Padding(3);
            this.Stream_Cost.Size = new System.Drawing.Size(1235, 565);
            this.Stream_Cost.TabIndex = 1;
            this.Stream_Cost.Text = "Defined Stream";
            this.Stream_Cost.UseVisualStyleBackColor = true;
            // 
            // DefineStreamTab
            // 
            this.DefineStreamTab.Controls.Add(this.tabPage1);
            this.DefineStreamTab.Controls.Add(this.tabPage2);
            this.DefineStreamTab.Location = new System.Drawing.Point(3, 62);
            this.DefineStreamTab.Name = "DefineStreamTab";
            this.DefineStreamTab.SelectedIndex = 0;
            this.DefineStreamTab.Size = new System.Drawing.Size(1226, 501);
            this.DefineStreamTab.TabIndex = 49;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblNoteStream);
            this.tabPage1.Controls.Add(this.btnClearStream);
            this.tabPage1.Controls.Add(this.btnNextStreamTable);
            this.tabPage1.Controls.Add(this.btnAddStreamOutput);
            this.tabPage1.Controls.Add(this.cbbStreamOutput);
            this.tabPage1.Controls.Add(this.lblStream_Output);
            this.tabPage1.Controls.Add(this.gbStreamOutput_OpC);
            this.tabPage1.Controls.Add(this.btnAddStreamInput);
            this.tabPage1.Controls.Add(this.cbbStreamInput);
            this.tabPage1.Controls.Add(this.lblStream_Input);
            this.tabPage1.Controls.Add(this.gbStreamInput_OpC);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1218, 466);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Stream Selection";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblNoteStream
            // 
            this.lblNoteStream.AutoSize = true;
            this.lblNoteStream.ForeColor = System.Drawing.Color.Blue;
            this.lblNoteStream.Location = new System.Drawing.Point(28, 433);
            this.lblNoteStream.Name = "lblNoteStream";
            this.lblNoteStream.Size = new System.Drawing.Size(643, 22);
            this.lblNoteStream.TabIndex = 62;
            this.lblNoteStream.Text = "***To delete a row in the table, please click the Delete button on your keyboard." +
    "";
            // 
            // btnClearStream
            // 
            this.btnClearStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearStream.Location = new System.Drawing.Point(904, 424);
            this.btnClearStream.Name = "btnClearStream";
            this.btnClearStream.Size = new System.Drawing.Size(146, 39);
            this.btnClearStream.TabIndex = 61;
            this.btnClearStream.Text = "Clear All";
            this.btnClearStream.UseVisualStyleBackColor = true;
            this.btnClearStream.Click += new System.EventHandler(this.btnClearStream_Click);
            // 
            // btnNextStreamTable
            // 
            this.btnNextStreamTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextStreamTable.Location = new System.Drawing.Point(1056, 424);
            this.btnNextStreamTable.Name = "btnNextStreamTable";
            this.btnNextStreamTable.Size = new System.Drawing.Size(146, 39);
            this.btnNextStreamTable.TabIndex = 59;
            this.btnNextStreamTable.Text = "Next";
            this.btnNextStreamTable.UseVisualStyleBackColor = true;
            this.btnNextStreamTable.Click += new System.EventHandler(this.btnNextStreamTable_Click);
            // 
            // btnAddStreamOutput
            // 
            this.btnAddStreamOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStreamOutput.Location = new System.Drawing.Point(1093, 9);
            this.btnAddStreamOutput.Name = "btnAddStreamOutput";
            this.btnAddStreamOutput.Size = new System.Drawing.Size(99, 39);
            this.btnAddStreamOutput.TabIndex = 55;
            this.btnAddStreamOutput.Text = "Add";
            this.btnAddStreamOutput.UseVisualStyleBackColor = true;
            this.btnAddStreamOutput.Click += new System.EventHandler(this.btnAddStreamOutput_Click);
            // 
            // cbbStreamOutput
            // 
            this.cbbStreamOutput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStreamOutput.FormattingEnabled = true;
            this.cbbStreamOutput.Location = new System.Drawing.Point(916, 14);
            this.cbbStreamOutput.Name = "cbbStreamOutput";
            this.cbbStreamOutput.Size = new System.Drawing.Size(162, 30);
            this.cbbStreamOutput.TabIndex = 54;
            // 
            // lblStream_Output
            // 
            this.lblStream_Output.AutoSize = true;
            this.lblStream_Output.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStream_Output.Location = new System.Drawing.Point(623, 15);
            this.lblStream_Output.Name = "lblStream_Output";
            this.lblStream_Output.Size = new System.Drawing.Size(266, 25);
            this.lblStream_Output.TabIndex = 53;
            this.lblStream_Output.Text = "Please select Stream Output:";
            // 
            // gbStreamOutput_OpC
            // 
            this.gbStreamOutput_OpC.Controls.Add(this.dgvStreamOutput_OpC);
            this.gbStreamOutput_OpC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStreamOutput_OpC.Location = new System.Drawing.Point(628, 55);
            this.gbStreamOutput_OpC.Name = "gbStreamOutput_OpC";
            this.gbStreamOutput_OpC.Size = new System.Drawing.Size(580, 363);
            this.gbStreamOutput_OpC.TabIndex = 52;
            this.gbStreamOutput_OpC.TabStop = false;
            this.gbStreamOutput_OpC.Text = "Stream Output Summary:";
            // 
            // dgvStreamOutput_OpC
            // 
            this.dgvStreamOutput_OpC.AllowUserToAddRows = false;
            this.dgvStreamOutput_OpC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStreamOutput_OpC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.List_StreamOutput});
            this.dgvStreamOutput_OpC.Location = new System.Drawing.Point(10, 33);
            this.dgvStreamOutput_OpC.Name = "dgvStreamOutput_OpC";
            this.dgvStreamOutput_OpC.ReadOnly = true;
            this.dgvStreamOutput_OpC.RowHeadersWidth = 51;
            this.dgvStreamOutput_OpC.RowTemplate.Height = 24;
            this.dgvStreamOutput_OpC.Size = new System.Drawing.Size(564, 317);
            this.dgvStreamOutput_OpC.TabIndex = 4;
            // 
            // List_StreamOutput
            // 
            this.List_StreamOutput.HeaderText = "List of Stream Output";
            this.List_StreamOutput.MinimumWidth = 6;
            this.List_StreamOutput.Name = "List_StreamOutput";
            this.List_StreamOutput.ReadOnly = true;
            this.List_StreamOutput.Width = 175;
            // 
            // btnAddStreamInput
            // 
            this.btnAddStreamInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddStreamInput.Location = new System.Drawing.Point(497, 9);
            this.btnAddStreamInput.Name = "btnAddStreamInput";
            this.btnAddStreamInput.Size = new System.Drawing.Size(99, 39);
            this.btnAddStreamInput.TabIndex = 51;
            this.btnAddStreamInput.Text = "Add";
            this.btnAddStreamInput.UseVisualStyleBackColor = true;
            this.btnAddStreamInput.Click += new System.EventHandler(this.btnAddStreamInput_Click);
            // 
            // cbbStreamInput
            // 
            this.cbbStreamInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbStreamInput.FormattingEnabled = true;
            this.cbbStreamInput.Location = new System.Drawing.Point(306, 15);
            this.cbbStreamInput.Name = "cbbStreamInput";
            this.cbbStreamInput.Size = new System.Drawing.Size(175, 30);
            this.cbbStreamInput.TabIndex = 50;
            // 
            // lblStream_Input
            // 
            this.lblStream_Input.AutoSize = true;
            this.lblStream_Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStream_Input.Location = new System.Drawing.Point(27, 16);
            this.lblStream_Input.Name = "lblStream_Input";
            this.lblStream_Input.Size = new System.Drawing.Size(250, 25);
            this.lblStream_Input.TabIndex = 49;
            this.lblStream_Input.Text = "Please select Stream Input:";
            // 
            // gbStreamInput_OpC
            // 
            this.gbStreamInput_OpC.Controls.Add(this.dgvStream_OpC);
            this.gbStreamInput_OpC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbStreamInput_OpC.Location = new System.Drawing.Point(32, 55);
            this.gbStreamInput_OpC.Name = "gbStreamInput_OpC";
            this.gbStreamInput_OpC.Size = new System.Drawing.Size(580, 363);
            this.gbStreamInput_OpC.TabIndex = 48;
            this.gbStreamInput_OpC.TabStop = false;
            this.gbStreamInput_OpC.Text = "Stream Input Summary:";
            // 
            // dgvStream_OpC
            // 
            this.dgvStream_OpC.AllowUserToAddRows = false;
            this.dgvStream_OpC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStream_OpC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.List_StreamInput});
            this.dgvStream_OpC.Location = new System.Drawing.Point(10, 32);
            this.dgvStream_OpC.Name = "dgvStream_OpC";
            this.dgvStream_OpC.ReadOnly = true;
            this.dgvStream_OpC.RowHeadersWidth = 51;
            this.dgvStream_OpC.RowTemplate.Height = 24;
            this.dgvStream_OpC.Size = new System.Drawing.Size(564, 318);
            this.dgvStream_OpC.TabIndex = 4;
            // 
            // List_StreamInput
            // 
            this.List_StreamInput.HeaderText = "List of Stream Input";
            this.List_StreamInput.MinimumWidth = 6;
            this.List_StreamInput.Name = "List_StreamInput";
            this.List_StreamInput.ReadOnly = true;
            this.List_StreamInput.Width = 160;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbRawStreamTable);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1218, 466);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stream Table Preview";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gbRawStreamTable
            // 
            this.gbRawStreamTable.Controls.Add(this.dgvStreamTablePreview);
            this.gbRawStreamTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRawStreamTable.Location = new System.Drawing.Point(16, 19);
            this.gbRawStreamTable.Name = "gbRawStreamTable";
            this.gbRawStreamTable.Size = new System.Drawing.Size(1193, 441);
            this.gbRawStreamTable.TabIndex = 49;
            this.gbRawStreamTable.TabStop = false;
            this.gbRawStreamTable.Text = "Stream Table Preview:";
            // 
            // dgvStreamTablePreview
            // 
            this.dgvStreamTablePreview.AllowUserToAddRows = false;
            this.dgvStreamTablePreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStreamTablePreview.Location = new System.Drawing.Point(10, 32);
            this.dgvStreamTablePreview.Name = "dgvStreamTablePreview";
            this.dgvStreamTablePreview.ReadOnly = true;
            this.dgvStreamTablePreview.RowHeadersWidth = 51;
            this.dgvStreamTablePreview.RowTemplate.Height = 24;
            this.dgvStreamTablePreview.Size = new System.Drawing.Size(1177, 397);
            this.dgvStreamTablePreview.TabIndex = 4;
            // 
            // pbProduct
            // 
            this.pbProduct.Image = ((System.Drawing.Image)(resources.GetObject("pbProduct.Image")));
            this.pbProduct.Location = new System.Drawing.Point(23, 13);
            this.pbProduct.Name = "pbProduct";
            this.pbProduct.Size = new System.Drawing.Size(56, 45);
            this.pbProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbProduct.TabIndex = 19;
            this.pbProduct.TabStop = false;
            // 
            // lblStreamFile
            // 
            this.lblStreamFile.AutoSize = true;
            this.lblStreamFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreamFile.Location = new System.Drawing.Point(88, 23);
            this.lblStreamFile.Name = "lblStreamFile";
            this.lblStreamFile.Size = new System.Drawing.Size(238, 25);
            this.lblStreamFile.TabIndex = 18;
            this.lblStreamFile.Text = "Steam Table file Location:";
            // 
            // txtStreamtable
            // 
            this.txtStreamtable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreamtable.Location = new System.Drawing.Point(343, 19);
            this.txtStreamtable.Name = "txtStreamtable";
            this.txtStreamtable.ReadOnly = true;
            this.txtStreamtable.Size = new System.Drawing.Size(873, 28);
            this.txtStreamtable.TabIndex = 15;
            // 
            // Equipment_Cost
            // 
            this.Equipment_Cost.Controls.Add(this.Eqip_Control);
            this.Equipment_Cost.Controls.Add(this.pbEquipment);
            this.Equipment_Cost.Controls.Add(this.lblEquipmentLocation);
            this.Equipment_Cost.Controls.Add(this.txtEquipmentFile);
            this.Equipment_Cost.Location = new System.Drawing.Point(4, 31);
            this.Equipment_Cost.Name = "Equipment_Cost";
            this.Equipment_Cost.Size = new System.Drawing.Size(1235, 565);
            this.Equipment_Cost.TabIndex = 8;
            this.Equipment_Cost.Text = "Defined Equipment";
            this.Equipment_Cost.UseVisualStyleBackColor = true;
            this.Equipment_Cost.Click += new System.EventHandler(this.Equipment_Cost_Click);
            // 
            // Eqip_Control
            // 
            this.Eqip_Control.Controls.Add(this.EquipSelect);
            this.Eqip_Control.Controls.Add(this.EquipPreview);
            this.Eqip_Control.Location = new System.Drawing.Point(3, 62);
            this.Eqip_Control.Name = "Eqip_Control";
            this.Eqip_Control.SelectedIndex = 0;
            this.Eqip_Control.Size = new System.Drawing.Size(1226, 501);
            this.Eqip_Control.TabIndex = 53;
            // 
            // EquipSelect
            // 
            this.EquipSelect.Controls.Add(this.txtCPI_Index);
            this.EquipSelect.Controls.Add(this.lblCPI_Index);
            this.EquipSelect.Controls.Add(this.btnSave_DefineEquip);
            this.EquipSelect.Controls.Add(this.gbEquipmentSelection);
            this.EquipSelect.Location = new System.Drawing.Point(4, 31);
            this.EquipSelect.Name = "EquipSelect";
            this.EquipSelect.Padding = new System.Windows.Forms.Padding(3);
            this.EquipSelect.Size = new System.Drawing.Size(1218, 466);
            this.EquipSelect.TabIndex = 0;
            this.EquipSelect.Text = "Euipment Selection";
            this.EquipSelect.UseVisualStyleBackColor = true;
            // 
            // txtCPI_Index
            // 
            this.txtCPI_Index.BackColor = System.Drawing.Color.LightBlue;
            this.txtCPI_Index.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCPI_Index.Location = new System.Drawing.Point(194, 21);
            this.txtCPI_Index.Name = "txtCPI_Index";
            this.txtCPI_Index.Size = new System.Drawing.Size(152, 28);
            this.txtCPI_Index.TabIndex = 63;
            this.txtCPI_Index.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCPI_Index.TextChanged += new System.EventHandler(this.txtCPI_Index_TextChanged);
            // 
            // lblCPI_Index
            // 
            this.lblCPI_Index.AutoSize = true;
            this.lblCPI_Index.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPI_Index.Location = new System.Drawing.Point(21, 22);
            this.lblCPI_Index.Name = "lblCPI_Index";
            this.lblCPI_Index.Size = new System.Drawing.Size(158, 25);
            this.lblCPI_Index.TabIndex = 62;
            this.lblCPI_Index.Text = "CEP Cost Index:";
            // 
            // btnSave_DefineEquip
            // 
            this.btnSave_DefineEquip.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave_DefineEquip.Location = new System.Drawing.Point(1056, 424);
            this.btnSave_DefineEquip.Name = "btnSave_DefineEquip";
            this.btnSave_DefineEquip.Size = new System.Drawing.Size(146, 39);
            this.btnSave_DefineEquip.TabIndex = 59;
            this.btnSave_DefineEquip.Text = "Done";
            this.btnSave_DefineEquip.UseVisualStyleBackColor = true;
            this.btnSave_DefineEquip.Click += new System.EventHandler(this.btnSave_DefineEquip_Click);
            // 
            // gbEquipmentSelection
            // 
            this.gbEquipmentSelection.Controls.Add(this.dgvEquipmentSummary);
            this.gbEquipmentSelection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEquipmentSelection.Location = new System.Drawing.Point(16, 66);
            this.gbEquipmentSelection.Name = "gbEquipmentSelection";
            this.gbEquipmentSelection.Size = new System.Drawing.Size(1193, 347);
            this.gbEquipmentSelection.TabIndex = 48;
            this.gbEquipmentSelection.TabStop = false;
            this.gbEquipmentSelection.Text = "Equipment Summary:";
            // 
            // dgvEquipmentSummary
            // 
            this.dgvEquipmentSummary.AllowUserToAddRows = false;
            this.dgvEquipmentSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipmentSummary.Location = new System.Drawing.Point(10, 27);
            this.dgvEquipmentSummary.Name = "dgvEquipmentSummary";
            this.dgvEquipmentSummary.ReadOnly = true;
            this.dgvEquipmentSummary.RowHeadersWidth = 51;
            this.dgvEquipmentSummary.RowTemplate.Height = 24;
            this.dgvEquipmentSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipmentSummary.Size = new System.Drawing.Size(1176, 314);
            this.dgvEquipmentSummary.TabIndex = 4;
            this.dgvEquipmentSummary.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipmentSummary_CellContentClick);
            this.dgvEquipmentSummary.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEquipmentSummary_CellDoubleClick);
            // 
            // EquipPreview
            // 
            this.EquipPreview.Controls.Add(this.gbEquipmentTable);
            this.EquipPreview.Location = new System.Drawing.Point(4, 31);
            this.EquipPreview.Name = "EquipPreview";
            this.EquipPreview.Padding = new System.Windows.Forms.Padding(3);
            this.EquipPreview.Size = new System.Drawing.Size(1218, 466);
            this.EquipPreview.TabIndex = 1;
            this.EquipPreview.Text = "Equipment Table Preview";
            this.EquipPreview.UseVisualStyleBackColor = true;
            // 
            // gbEquipmentTable
            // 
            this.gbEquipmentTable.Controls.Add(this.dgvEquipmentPreview);
            this.gbEquipmentTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbEquipmentTable.Location = new System.Drawing.Point(16, 19);
            this.gbEquipmentTable.Name = "gbEquipmentTable";
            this.gbEquipmentTable.Size = new System.Drawing.Size(1193, 441);
            this.gbEquipmentTable.TabIndex = 49;
            this.gbEquipmentTable.TabStop = false;
            this.gbEquipmentTable.Text = "Equipment Table Preview:";
            // 
            // dgvEquipmentPreview
            // 
            this.dgvEquipmentPreview.AllowUserToAddRows = false;
            this.dgvEquipmentPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipmentPreview.Location = new System.Drawing.Point(10, 32);
            this.dgvEquipmentPreview.Name = "dgvEquipmentPreview";
            this.dgvEquipmentPreview.ReadOnly = true;
            this.dgvEquipmentPreview.RowHeadersWidth = 51;
            this.dgvEquipmentPreview.RowTemplate.Height = 24;
            this.dgvEquipmentPreview.Size = new System.Drawing.Size(1177, 397);
            this.dgvEquipmentPreview.TabIndex = 4;
            // 
            // pbEquipment
            // 
            this.pbEquipment.Image = ((System.Drawing.Image)(resources.GetObject("pbEquipment.Image")));
            this.pbEquipment.Location = new System.Drawing.Point(23, 13);
            this.pbEquipment.Name = "pbEquipment";
            this.pbEquipment.Size = new System.Drawing.Size(56, 45);
            this.pbEquipment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbEquipment.TabIndex = 52;
            this.pbEquipment.TabStop = false;
            // 
            // lblEquipmentLocation
            // 
            this.lblEquipmentLocation.AutoSize = true;
            this.lblEquipmentLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEquipmentLocation.Location = new System.Drawing.Point(88, 23);
            this.lblEquipmentLocation.Name = "lblEquipmentLocation";
            this.lblEquipmentLocation.Size = new System.Drawing.Size(274, 25);
            this.lblEquipmentLocation.TabIndex = 51;
            this.lblEquipmentLocation.Text = "Equipment Table file Location:";
            // 
            // txtEquipmentFile
            // 
            this.txtEquipmentFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEquipmentFile.Location = new System.Drawing.Point(382, 19);
            this.txtEquipmentFile.Name = "txtEquipmentFile";
            this.txtEquipmentFile.ReadOnly = true;
            this.txtEquipmentFile.Size = new System.Drawing.Size(834, 28);
            this.txtEquipmentFile.TabIndex = 50;
            // 
            // Define_Product_LCPlus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 643);
            this.Controls.Add(this.tabpage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Define_Product_LCPlus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Define Process and Product";
            this.Load += new System.EventHandler(this.Define_Product_LCPlus_Load);
            this.tabpage.ResumeLayout(false);
            this.Product_Cost.ResumeLayout(false);
            this.Product_Cost.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDefineProduct)).EndInit();
            this.gbSideProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSideProduct)).EndInit();
            this.gbProduct.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMainProduct)).EndInit();
            this.Stream_Cost.ResumeLayout(false);
            this.Stream_Cost.PerformLayout();
            this.DefineStreamTab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbStreamOutput_OpC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStreamOutput_OpC)).EndInit();
            this.gbStreamInput_OpC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStream_OpC)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.gbRawStreamTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStreamTablePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbProduct)).EndInit();
            this.Equipment_Cost.ResumeLayout(false);
            this.Equipment_Cost.PerformLayout();
            this.Eqip_Control.ResumeLayout(false);
            this.EquipSelect.ResumeLayout(false);
            this.EquipSelect.PerformLayout();
            this.gbEquipmentSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipmentSummary)).EndInit();
            this.EquipPreview.ResumeLayout(false);
            this.gbEquipmentTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipmentPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbEquipment)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabpage;
        private System.Windows.Forms.TabPage Product_Cost;
        private System.Windows.Forms.Button btnSideProduct;
        private System.Windows.Forms.Button btnAddMainProduct;
        private System.Windows.Forms.ComboBox cbbSideProduct;
        private System.Windows.Forms.ComboBox cbbMainProduct;
        private System.Windows.Forms.Label lblSideProduct;
        private System.Windows.Forms.Label lblMainProduct;
        private System.Windows.Forms.Label lblProductFile;
        private System.Windows.Forms.TextBox txtProductFile;
        private System.Windows.Forms.PictureBox pbDefineProduct;
        private System.Windows.Forms.Button btnNextProduct;
        private System.Windows.Forms.GroupBox gbSideProduct;
        private System.Windows.Forms.DataGridView dgvSideProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox gbProduct;
        private System.Windows.Forms.DataGridView dgvMainProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.TabPage Stream_Cost;
        private System.Windows.Forms.TabControl DefineStreamTab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnNextStreamTable;
        private System.Windows.Forms.Button btnAddStreamOutput;
        private System.Windows.Forms.ComboBox cbbStreamOutput;
        private System.Windows.Forms.Label lblStream_Output;
        private System.Windows.Forms.GroupBox gbStreamOutput_OpC;
        private System.Windows.Forms.DataGridView dgvStreamOutput_OpC;
        private System.Windows.Forms.DataGridViewTextBoxColumn List_StreamOutput;
        private System.Windows.Forms.Button btnAddStreamInput;
        private System.Windows.Forms.ComboBox cbbStreamInput;
        private System.Windows.Forms.Label lblStream_Input;
        private System.Windows.Forms.GroupBox gbStreamInput_OpC;
        private System.Windows.Forms.DataGridView dgvStream_OpC;
        private System.Windows.Forms.DataGridViewTextBoxColumn List_StreamInput;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gbRawStreamTable;
        private System.Windows.Forms.DataGridView dgvStreamTablePreview;
        private System.Windows.Forms.PictureBox pbProduct;
        private System.Windows.Forms.Label lblStreamFile;
        private System.Windows.Forms.TextBox txtStreamtable;
        private System.Windows.Forms.TabPage Equipment_Cost;
        private System.Windows.Forms.TabControl Eqip_Control;
        private System.Windows.Forms.TabPage EquipSelect;
        private System.Windows.Forms.TextBox txtCPI_Index;
        private System.Windows.Forms.Label lblCPI_Index;
        private System.Windows.Forms.Button btnSave_DefineEquip;
        private System.Windows.Forms.GroupBox gbEquipmentSelection;
        private System.Windows.Forms.DataGridView dgvEquipmentSummary;
        private System.Windows.Forms.TabPage EquipPreview;
        private System.Windows.Forms.GroupBox gbEquipmentTable;
        private System.Windows.Forms.DataGridView dgvEquipmentPreview;
        private System.Windows.Forms.PictureBox pbEquipment;
        private System.Windows.Forms.Label lblEquipmentLocation;
        private System.Windows.Forms.TextBox txtEquipmentFile;
        private System.Windows.Forms.Button btnClearProduct;
        private System.Windows.Forms.Button btnClearStream;
        private System.Windows.Forms.Label lblNoteProduct;
        private System.Windows.Forms.Label lblNoteStream;
    }
}