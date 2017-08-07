namespace YLibrary
{
    partial class JieShuJL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JieShuJL));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.借书号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.书号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.书名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.借书时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.还书时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.操作 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.借书号,
            this.书号,
            this.书名,
            this.借书时间,
            this.还书时间,
            this.操作});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(661, 175);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // 借书号
            // 
            this.借书号.DataPropertyName = "Jid";
            this.借书号.HeaderText = "借书号";
            this.借书号.Name = "借书号";
            this.借书号.ReadOnly = true;
            // 
            // 书号
            // 
            this.书号.DataPropertyName = "Bid";
            this.书号.HeaderText = "书号";
            this.书号.Name = "书号";
            this.书号.ReadOnly = true;
            // 
            // 书名
            // 
            this.书名.DataPropertyName = "BName";
            this.书名.HeaderText = "书名";
            this.书名.Name = "书名";
            this.书名.ReadOnly = true;
            // 
            // 借书时间
            // 
            this.借书时间.DataPropertyName = "JTime";
            this.借书时间.HeaderText = "借书时间";
            this.借书时间.Name = "借书时间";
            this.借书时间.ReadOnly = true;
            // 
            // 还书时间
            // 
            this.还书时间.DataPropertyName = "HTime";
            this.还书时间.HeaderText = "还书时间";
            this.还书时间.Name = "还书时间";
            this.还书时间.ReadOnly = true;
            // 
            // 操作
            // 
            this.操作.HeaderText = "操作";
            this.操作.Name = "操作";
            this.操作.ReadOnly = true;
            this.操作.Text = "还书";
            this.操作.UseColumnTextForButtonValue = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("幼圆", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(480, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "返回";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // JieShuJL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 270);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(701, 308);
            this.MinimumSize = new System.Drawing.Size(701, 308);
            this.Name = "JieShuJL";
            this.Text = "借书记录";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.JieShuJL_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        public string uname;
        private System.Windows.Forms.DataGridViewTextBoxColumn 借书号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 书号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 书名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 借书时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 还书时间;
        private System.Windows.Forms.DataGridViewButtonColumn 操作;
        private bool guanbi = true;
    }
}