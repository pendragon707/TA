namespace TA
{
    partial class Inspector
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDinspectorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameOfTheInspectorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rankOfInspectorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inspectorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tADataSet = new TA.TADataSet();
            this.inspectorTableAdapter = new TA.TADataSetTableAdapters.InspectorTableAdapter();
            this.button7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspectorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tADataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDinspectorDataGridViewTextBoxColumn,
            this.nameOfTheInspectorDataGridViewTextBoxColumn,
            this.rankOfInspectorDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.inspectorBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(29, 25);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(379, 456);
            this.dataGridView1.TabIndex = 0;
            // 
            // iDinspectorDataGridViewTextBoxColumn
            // 
            this.iDinspectorDataGridViewTextBoxColumn.DataPropertyName = "IDinspector";
            this.iDinspectorDataGridViewTextBoxColumn.HeaderText = "IDinspector";
            this.iDinspectorDataGridViewTextBoxColumn.Name = "iDinspectorDataGridViewTextBoxColumn";
            this.iDinspectorDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDinspectorDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameOfTheInspectorDataGridViewTextBoxColumn
            // 
            this.nameOfTheInspectorDataGridViewTextBoxColumn.DataPropertyName = "NameOfTheInspector";
            this.nameOfTheInspectorDataGridViewTextBoxColumn.HeaderText = "NameOfTheInspector";
            this.nameOfTheInspectorDataGridViewTextBoxColumn.Name = "nameOfTheInspectorDataGridViewTextBoxColumn";
            this.nameOfTheInspectorDataGridViewTextBoxColumn.Width = 150;
            // 
            // rankOfInspectorDataGridViewTextBoxColumn
            // 
            this.rankOfInspectorDataGridViewTextBoxColumn.DataPropertyName = "RankOfInspector";
            this.rankOfInspectorDataGridViewTextBoxColumn.HeaderText = "RankOfInspector";
            this.rankOfInspectorDataGridViewTextBoxColumn.Name = "rankOfInspectorDataGridViewTextBoxColumn";
            this.rankOfInspectorDataGridViewTextBoxColumn.Width = 150;
            // 
            // inspectorBindingSource
            // 
            this.inspectorBindingSource.DataMember = "Inspector";
            this.inspectorBindingSource.DataSource = this.tADataSet;
            // 
            // tADataSet
            // 
            this.tADataSet.DataSetName = "TADataSet";
            this.tADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inspectorTableAdapter
            // 
            this.inspectorTableAdapter.ClearBeforeFill = true;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(58)))));
            this.button7.Font = new System.Drawing.Font("PT Root UI", 11F);
            this.button7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button7.Location = new System.Drawing.Point(631, 430);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(169, 51);
            this.button7.TabIndex = 29;
            this.button7.Text = "Возврат";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(58)))));
            this.button1.Font = new System.Drawing.Font("PT Root UI", 11F);
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(468, 174);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(332, 47);
            this.button1.TabIndex = 30;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.inspectorBindingSource, "NameOfTheInspector", true));
            this.textBox1.Font = new System.Drawing.Font("PT Root UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(468, 79);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(332, 33);
            this.textBox1.TabIndex = 31;
            // 
            // textBox2
            // 
            this.textBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.inspectorBindingSource, "RankOfInspector", true));
            this.textBox2.Font = new System.Drawing.Font("PT Root UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(468, 137);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(332, 33);
            this.textBox2.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PT Root UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(478, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 33;
            this.label1.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PT Root UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(478, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 25);
            this.label2.TabIndex = 34;
            this.label2.Text = "Звание";
            // 
            // Inspector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(824, 504);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Lucida Console", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Inspector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Inspector";
            this.Load += new System.EventHandler(this.Inspector_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inspectorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tADataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private TADataSet tADataSet;
        private System.Windows.Forms.BindingSource inspectorBindingSource;
        private TADataSetTableAdapters.InspectorTableAdapter inspectorTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDinspectorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameOfTheInspectorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn rankOfInspectorDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}