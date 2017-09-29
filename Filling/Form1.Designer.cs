namespace Filling
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.select_image_button = new System.Windows.Forms.Button();
            this.select_border_button = new System.Windows.Forms.Button();
            this.chose_start_dot_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dot_status_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1200, 675);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // select_image_button
            // 
            this.select_image_button.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.select_image_button.FlatAppearance.BorderSize = 0;
            this.select_image_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_image_button.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.select_image_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.select_image_button.Location = new System.Drawing.Point(12, 22);
            this.select_image_button.Name = "select_image_button";
            this.select_image_button.Size = new System.Drawing.Size(262, 55);
            this.select_image_button.TabIndex = 1;
            this.select_image_button.Text = "Выбрать изображение";
            this.select_image_button.UseVisualStyleBackColor = false;
            this.select_image_button.Click += new System.EventHandler(this.select_image_button_Click);
            // 
            // select_border_button
            // 
            this.select_border_button.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.select_border_button.FlatAppearance.BorderSize = 0;
            this.select_border_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.select_border_button.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.select_border_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.select_border_button.Location = new System.Drawing.Point(926, 22);
            this.select_border_button.Name = "select_border_button";
            this.select_border_button.Size = new System.Drawing.Size(262, 55);
            this.select_border_button.TabIndex = 2;
            this.select_border_button.Text = "Выделить границу";
            this.select_border_button.UseVisualStyleBackColor = false;
            this.select_border_button.Click += new System.EventHandler(this.select_border_button_Click);
            // 
            // chose_start_dot_button
            // 
            this.chose_start_dot_button.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.chose_start_dot_button.FlatAppearance.BorderSize = 0;
            this.chose_start_dot_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chose_start_dot_button.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chose_start_dot_button.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chose_start_dot_button.Location = new System.Drawing.Point(280, 22);
            this.chose_start_dot_button.Name = "chose_start_dot_button";
            this.chose_start_dot_button.Size = new System.Drawing.Size(262, 55);
            this.chose_start_dot_button.TabIndex = 3;
            this.chose_start_dot_button.Text = "Выбрать начальную точку";
            this.chose_start_dot_button.UseVisualStyleBackColor = false;
            this.chose_start_dot_button.Click += new System.EventHandler(this.chose_start_dot_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(571, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Координаты выбранной точки:";
            // 
            // dot_status_label
            // 
            this.dot_status_label.AutoSize = true;
            this.dot_status_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dot_status_label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dot_status_label.Location = new System.Drawing.Point(571, 55);
            this.dot_status_label.Name = "dot_status_label";
            this.dot_status_label.Size = new System.Drawing.Size(120, 22);
            this.dot_status_label.TabIndex = 5;
            this.dot_status_label.Text = "{не выбрано}";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 771);
            this.Controls.Add(this.dot_status_label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chose_start_dot_button);
            this.Controls.Add(this.select_border_button);
            this.Controls.Add(this.select_image_button);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1216, 812);
            this.MinimumSize = new System.Drawing.Size(1216, 812);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Select Border";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button select_image_button;
        private System.Windows.Forms.Button select_border_button;
        private System.Windows.Forms.Button chose_start_dot_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dot_status_label;
    }
}

