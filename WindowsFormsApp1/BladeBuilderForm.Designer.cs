namespace WindowsFormsApp1
{
    partial class BladeBuilderForm
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
            this.buildButton = new System.Windows.Forms.Button();
            this.bladeLenght = new System.Windows.Forms.MaskedTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.handleLength = new System.Windows.Forms.MaskedTextBox();
            this.handleBoreDiameter = new System.Windows.Forms.MaskedTextBox();
            this.buttWidth = new System.Windows.Forms.MaskedTextBox();
            this.bladeHeight = new System.Windows.Forms.MaskedTextBox();
            this.grindHeight = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.gripHeight = new System.Windows.Forms.MaskedTextBox();
            this.gripWidth = new System.Windows.Forms.MaskedTextBox();
            this.gripLength = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(9, 291);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(203, 23);
            this.buildButton.TabIndex = 0;
            this.buildButton.Text = "Построить";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // bladeLenght
            // 
            this.bladeLenght.Location = new System.Drawing.Point(164, 8);
            this.bladeLenght.Mask = "000 мм";
            this.bladeLenght.Name = "bladeLenght";
            this.bladeLenght.ShortcutsEnabled = false;
            this.bladeLenght.Size = new System.Drawing.Size(49, 20);
            this.bladeLenght.TabIndex = 1;
            this.bladeLenght.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bladeLenght.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // handleLength
            // 
            this.handleLength.Location = new System.Drawing.Point(164, 34);
            this.handleLength.Mask = "000 мм";
            this.handleLength.Name = "handleLength";
            this.handleLength.Size = new System.Drawing.Size(49, 20);
            this.handleLength.TabIndex = 2;
            this.handleLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.handleLength.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // handleBoreDiameter
            // 
            this.handleBoreDiameter.Location = new System.Drawing.Point(164, 60);
            this.handleBoreDiameter.Mask = "0 мм";
            this.handleBoreDiameter.Name = "handleBoreDiameter";
            this.handleBoreDiameter.Size = new System.Drawing.Size(49, 20);
            this.handleBoreDiameter.TabIndex = 3;
            this.handleBoreDiameter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.handleBoreDiameter.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // buttWidth
            // 
            this.buttWidth.Location = new System.Drawing.Point(164, 86);
            this.buttWidth.Mask = "0 мм";
            this.buttWidth.Name = "buttWidth";
            this.buttWidth.Size = new System.Drawing.Size(49, 20);
            this.buttWidth.TabIndex = 4;
            this.buttWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.buttWidth.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // bladeHeight
            // 
            this.bladeHeight.Location = new System.Drawing.Point(164, 112);
            this.bladeHeight.Mask = "00 мм";
            this.bladeHeight.Name = "bladeHeight";
            this.bladeHeight.Size = new System.Drawing.Size(49, 20);
            this.bladeHeight.TabIndex = 5;
            this.bladeHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bladeHeight.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // grindHeight
            // 
            this.grindHeight.Location = new System.Drawing.Point(164, 138);
            this.grindHeight.Mask = "00 мм";
            this.grindHeight.Name = "grindHeight";
            this.grindHeight.Size = new System.Drawing.Size(49, 20);
            this.grindHeight.TabIndex = 6;
            this.grindHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.grindHeight.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Длина клинка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Длина рукояти";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Диаметр отверстия рукояти";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Ширина обуха";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Высота клинка";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(74, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Высота спуска";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(60, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ручка ножа:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(82, 263);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Высота ручки";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(81, 237);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Ширина ручки";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(87, 211);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Длина ручки";
            // 
            // gripHeight
            // 
            this.gripHeight.Location = new System.Drawing.Point(164, 260);
            this.gripHeight.Mask = "00 мм";
            this.gripHeight.Name = "gripHeight";
            this.gripHeight.Size = new System.Drawing.Size(49, 20);
            this.gripHeight.TabIndex = 16;
            this.gripHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gripHeight.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // gripWidth
            // 
            this.gripWidth.Location = new System.Drawing.Point(164, 234);
            this.gripWidth.Mask = "00 мм";
            this.gripWidth.Name = "gripWidth";
            this.gripWidth.Size = new System.Drawing.Size(49, 20);
            this.gripWidth.TabIndex = 15;
            this.gripWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gripWidth.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // gripLength
            // 
            this.gripLength.Location = new System.Drawing.Point(164, 208);
            this.gripLength.Mask = "000 мм";
            this.gripLength.Name = "gripLength";
            this.gripLength.Size = new System.Drawing.Size(49, 20);
            this.gripLength.TabIndex = 14;
            this.gripLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gripLength.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // BladeBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(224, 326);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gripHeight);
            this.Controls.Add(this.gripWidth);
            this.Controls.Add(this.gripLength);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grindHeight);
            this.Controls.Add(this.bladeHeight);
            this.Controls.Add(this.buttWidth);
            this.Controls.Add(this.handleBoreDiameter);
            this.Controls.Add(this.handleLength);
            this.Controls.Add(this.bladeLenght);
            this.Controls.Add(this.buildButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "BladeBuilderForm";
            this.Text = "BladeBuilder";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BladeBuilderForm_FormClosed);
            this.Load += new System.EventHandler(this.BladeBuilderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.MaskedTextBox bladeLenght;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MaskedTextBox handleLength;
        private System.Windows.Forms.MaskedTextBox handleBoreDiameter;
        private System.Windows.Forms.MaskedTextBox buttWidth;
        private System.Windows.Forms.MaskedTextBox bladeHeight;
        private System.Windows.Forms.MaskedTextBox grindHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox gripHeight;
        private System.Windows.Forms.MaskedTextBox gripWidth;
        private System.Windows.Forms.MaskedTextBox gripLength;
    }
}

