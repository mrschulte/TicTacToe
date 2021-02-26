namespace Client
{
    partial class Form_Lobby
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_state1 = new System.Windows.Forms.Label();
            this.label_state2 = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Spieler 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Spieler 2:";
            // 
            // label_state1
            // 
            this.label_state1.AutoSize = true;
            this.label_state1.Location = new System.Drawing.Point(101, 33);
            this.label_state1.Name = "label_state1";
            this.label_state1.Size = new System.Drawing.Size(48, 13);
            this.label_state1.TabIndex = 2;
            this.label_state1.Text = "warten...";
            // 
            // label_state2
            // 
            this.label_state2.AutoSize = true;
            this.label_state2.Location = new System.Drawing.Point(101, 62);
            this.label_state2.Name = "label_state2";
            this.label_state2.Size = new System.Drawing.Size(48, 13);
            this.label_state2.TabIndex = 3;
            this.label_state2.Text = "warten...";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(47, 93);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(102, 23);
            this.btn_exit.TabIndex = 4;
            this.btn_exit.Text = "Spiel verlassen";
            this.btn_exit.UseVisualStyleBackColor = true;
            // 
            // Form_Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 152);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.label_state2);
            this.Controls.Add(this.label_state1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form_Lobby";
            this.Text = "Form_Lobby";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_state1;
        private System.Windows.Forms.Label label_state2;
        private System.Windows.Forms.Button btn_exit;
    }
}