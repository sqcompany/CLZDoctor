namespace GrabData
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_data = new System.Windows.Forms.TextBox();
            this.btn_grab = new System.Windows.Forms.Button();
            this.tb_url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_data
            // 
            this.tb_data.Location = new System.Drawing.Point(12, 123);
            this.tb_data.Multiline = true;
            this.tb_data.Name = "tb_data";
            this.tb_data.Size = new System.Drawing.Size(738, 340);
            this.tb_data.TabIndex = 0;
            // 
            // btn_grab
            // 
            this.btn_grab.Location = new System.Drawing.Point(12, 42);
            this.btn_grab.Name = "btn_grab";
            this.btn_grab.Size = new System.Drawing.Size(75, 23);
            this.btn_grab.TabIndex = 1;
            this.btn_grab.Text = "抓去数据";
            this.btn_grab.UseVisualStyleBackColor = true;
            this.btn_grab.Click += new System.EventHandler(this.btn_grab_Click);
            // 
            // tb_url
            // 
            this.tb_url.Location = new System.Drawing.Point(196, 43);
            this.tb_url.Name = "tb_url";
            this.tb_url.Size = new System.Drawing.Size(291, 21);
            this.tb_url.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(151, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "地址：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(612, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "拆分中药";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 475);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_url);
            this.Controls.Add(this.btn_grab);
            this.Controls.Add(this.tb_data);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_data;
        private System.Windows.Forms.Button btn_grab;
        private System.Windows.Forms.TextBox tb_url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

