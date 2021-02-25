namespace Client
{
    partial class Form_Menu
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
            this.btn_join = new System.Windows.Forms.Button();
            this.txtBx_ip = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBx_port = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_join
            // 
            this.btn_join.Location = new System.Drawing.Point(39, 115);
            this.btn_join.Name = "btn_join";
            this.btn_join.Size = new System.Drawing.Size(132, 23);
            this.btn_join.TabIndex = 0;
            this.btn_join.Text = "Beitreten";
            this.btn_join.UseVisualStyleBackColor = true;
            this.btn_join.Click += new System.EventHandler(this.btn_join_Click);
            // 
            // txtBx_ip
            // 
            this.txtBx_ip.Location = new System.Drawing.Point(39, 50);
            this.txtBx_ip.Name = "txtBx_ip";
            this.txtBx_ip.Size = new System.Drawing.Size(132, 20);
            this.txtBx_ip.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP-Adresse";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port";
            // 
            // txtBx_port
            // 
            this.txtBx_port.Location = new System.Drawing.Point(39, 89);
            this.txtBx_port.Name = "txtBx_port";
            this.txtBx_port.Size = new System.Drawing.Size(132, 20);
            this.txtBx_port.TabIndex = 3;
            // 
            // Form_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 167);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBx_port);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBx_ip);
            this.Controls.Add(this.btn_join);
            this.Name = "Form_Menu";
            this.Text = "Form_Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_join;
        private System.Windows.Forms.TextBox txtBx_ip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBx_port;
    }
}