namespace ATP.TestForm
{
    partial class Form2
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mESDBDataSet = new ATP.TestForm.MESDBDataSet();
            this.utilstateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.util_stateTableAdapter = new ATP.TestForm.MESDBDataSetTableAdapters.util_stateTableAdapter();
            this.statedescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lasteditcommentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lasteditbyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lasteditatDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statecdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mESDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilstateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Testbutton";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(211, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statedescDataGridViewTextBoxColumn,
            this.colorDataGridViewTextBoxColumn,
            this.lasteditcommentDataGridViewTextBoxColumn,
            this.lasteditbyDataGridViewTextBoxColumn,
            this.lasteditatDataGridViewTextBoxColumn,
            this.statecdDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.utilstateBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(24, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(670, 52);
            this.dataGridView1.TabIndex = 2;
            // 
            // mESDBDataSet
            // 
            this.mESDBDataSet.DataSetName = "MESDBDataSet";
            this.mESDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // utilstateBindingSource
            // 
            this.utilstateBindingSource.DataMember = "util_state";
            this.utilstateBindingSource.DataSource = this.mESDBDataSet;
            // 
            // util_stateTableAdapter
            // 
            this.util_stateTableAdapter.ClearBeforeFill = true;
            // 
            // statedescDataGridViewTextBoxColumn
            // 
            this.statedescDataGridViewTextBoxColumn.DataPropertyName = "state_desc";
            this.statedescDataGridViewTextBoxColumn.HeaderText = "state_desc";
            this.statedescDataGridViewTextBoxColumn.Name = "statedescDataGridViewTextBoxColumn";
            // 
            // colorDataGridViewTextBoxColumn
            // 
            this.colorDataGridViewTextBoxColumn.DataPropertyName = "color";
            this.colorDataGridViewTextBoxColumn.HeaderText = "color";
            this.colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            // 
            // lasteditcommentDataGridViewTextBoxColumn
            // 
            this.lasteditcommentDataGridViewTextBoxColumn.DataPropertyName = "last_edit_comment";
            this.lasteditcommentDataGridViewTextBoxColumn.HeaderText = "last_edit_comment";
            this.lasteditcommentDataGridViewTextBoxColumn.Name = "lasteditcommentDataGridViewTextBoxColumn";
            // 
            // lasteditbyDataGridViewTextBoxColumn
            // 
            this.lasteditbyDataGridViewTextBoxColumn.DataPropertyName = "last_edit_by";
            this.lasteditbyDataGridViewTextBoxColumn.HeaderText = "last_edit_by";
            this.lasteditbyDataGridViewTextBoxColumn.Name = "lasteditbyDataGridViewTextBoxColumn";
            // 
            // lasteditatDataGridViewTextBoxColumn
            // 
            this.lasteditatDataGridViewTextBoxColumn.DataPropertyName = "last_edit_at";
            this.lasteditatDataGridViewTextBoxColumn.HeaderText = "last_edit_at";
            this.lasteditatDataGridViewTextBoxColumn.Name = "lasteditatDataGridViewTextBoxColumn";
            // 
            // statecdDataGridViewTextBoxColumn
            // 
            this.statecdDataGridViewTextBoxColumn.DataPropertyName = "state_cd";
            this.statecdDataGridViewTextBoxColumn.HeaderText = "state_cd";
            this.statecdDataGridViewTextBoxColumn.Name = "statecdDataGridViewTextBoxColumn";
            this.statecdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 412);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mESDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utilstateBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MESDBDataSet mESDBDataSet;
        private System.Windows.Forms.BindingSource utilstateBindingSource;
        private ATP.TestForm.MESDBDataSetTableAdapters.util_stateTableAdapter util_stateTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn statedescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lasteditcommentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lasteditbyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lasteditatDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statecdDataGridViewTextBoxColumn;
    }
}