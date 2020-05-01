namespace TA
{
    partial class TaDate
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.taDateBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tADataSet = new TA.TADataSet();
            this.taDateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taDateTableAdapter = new TA.TADataSetTableAdapters.TaDateTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.taDateBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.taDateBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tADataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taDateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taDateBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "От:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "До:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(216, 75);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(254, 33);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(216, 125);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(254, 33);
            this.dateTimePicker2.TabIndex = 3;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PT Root UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(47, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(392, 41);
            this.label3.TabIndex = 4;
            this.label3.Text = "ДТП в указанный период";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // taDateBindingSource1
            // 
            this.taDateBindingSource1.DataMember = "TaDate";
            this.taDateBindingSource1.DataSource = this.tADataSet;
            // 
            // tADataSet
            // 
            this.tADataSet.DataSetName = "TADataSet";
            this.tADataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taDateBindingSource
            // 
            this.taDateBindingSource.DataMember = "TaDate";
            this.taDateBindingSource.DataSource = this.tADataSet;
            // 
            // taDateTableAdapter
            // 
            this.taDateTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(46, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 128;
            this.dataGridView1.Size = new System.Drawing.Size(793, 291);
            this.dataGridView1.TabIndex = 5;
            // 
            // taDateBindingSource2
            // 
            this.taDateBindingSource2.DataMember = "TaDate";
            this.taDateBindingSource2.DataSource = this.tADataSet;
            // 
            // TaDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(882, 504);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("PT Root UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TaDate";
            this.Text = "TaDate";
            this.Load += new System.EventHandler(this.TaDate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.taDateBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tADataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taDateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taDateBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource taDateBindingSource;
        private TADataSet tADataSet;
        private TADataSetTableAdapters.TaDateTableAdapter taDateTableAdapter;
        private System.Windows.Forms.BindingSource taDateBindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource taDateBindingSource2;
    }
}