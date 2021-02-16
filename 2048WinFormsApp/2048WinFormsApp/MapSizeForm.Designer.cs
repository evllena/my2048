namespace _2048WinFormsApp
{
    partial class MapSizeForm
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
            this.size4Button = new System.Windows.Forms.Button();
            this.size6Button = new System.Windows.Forms.Button();
            this.size5Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // size4Button
            // 
            this.size4Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.size4Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.size4Button.Location = new System.Drawing.Point(40, 76);
            this.size4Button.Name = "size4Button";
            this.size4Button.Size = new System.Drawing.Size(70, 70);
            this.size4Button.TabIndex = 0;
            this.size4Button.Text = "4 на 4";
            this.size4Button.UseVisualStyleBackColor = true;
            this.size4Button.Click += new System.EventHandler(this.size4Button_Click);
            // 
            // size6Button
            // 
            this.size6Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.size6Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.size6Button.Location = new System.Drawing.Point(260, 76);
            this.size6Button.Name = "size6Button";
            this.size6Button.Size = new System.Drawing.Size(70, 70);
            this.size6Button.TabIndex = 1;
            this.size6Button.Text = "6 на 6";
            this.size6Button.UseVisualStyleBackColor = true;
            this.size6Button.Click += new System.EventHandler(this.size6Button_Click);
            // 
            // size5Button
            // 
            this.size5Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.size5Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.size5Button.Location = new System.Drawing.Point(150, 76);
            this.size5Button.Name = "size5Button";
            this.size5Button.Size = new System.Drawing.Size(70, 70);
            this.size5Button.TabIndex = 2;
            this.size5Button.Text = "5 на 5";
            this.size5Button.UseVisualStyleBackColor = true;
            this.size5Button.Click += new System.EventHandler(this.size5Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(59, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выберите размер поля:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MapSizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(366, 189);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.size5Button);
            this.Controls.Add(this.size6Button);
            this.Controls.Add(this.size4Button);
            this.Name = "MapSizeForm";
            this.Text = "MapSizeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button size4Button;
        private System.Windows.Forms.Button size6Button;
        private System.Windows.Forms.Button size5Button;
        private System.Windows.Forms.Label label1;
    }
}