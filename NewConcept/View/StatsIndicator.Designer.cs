namespace ValueLens.NewConcept
{
    partial class StatsIndicator
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.NameLabel = new System.Windows.Forms.Label();
            this.Mean10Label = new System.Windows.Forms.Label();
            this.Mean30Label = new System.Windows.Forms.Label();
            this.Range10Label = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.NameLabel.Location = new System.Drawing.Point(3, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(80, 20);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "MP100Z";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Mean10Label
            // 
            this.Mean10Label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mean10Label.Location = new System.Drawing.Point(6, 38);
            this.Mean10Label.Name = "Mean10Label";
            this.Mean10Label.Size = new System.Drawing.Size(77, 15);
            this.Mean10Label.TabIndex = 1;
            this.Mean10Label.Text = "均10 -8.88";
            this.Mean10Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Mean30Label
            // 
            this.Mean30Label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mean30Label.Location = new System.Drawing.Point(6, 54);
            this.Mean30Label.Name = "Mean30Label";
            this.Mean30Label.Size = new System.Drawing.Size(77, 15);
            this.Mean30Label.TabIndex = 1;
            this.Mean30Label.Text = "均30 -8.88";
            this.Mean30Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Range10Label
            // 
            this.Range10Label.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Range10Label.Location = new System.Drawing.Point(6, 70);
            this.Range10Label.Name = "Range10Label";
            this.Range10Label.Size = new System.Drawing.Size(77, 15);
            this.Range10Label.TabIndex = 1;
            this.Range10Label.Text = "极10 -8.88";
            this.Range10Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Font = new System.Drawing.Font("Consolas", 8F);
            this.DescriptionLabel.ForeColor = System.Drawing.Color.Gray;
            this.DescriptionLabel.Location = new System.Drawing.Point(4, 20);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(79, 13);
            this.DescriptionLabel.TabIndex = 1;
            this.DescriptionLabel.Text = "后玻璃左前角";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatsIndicator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Range10Label);
            this.Controls.Add(this.Mean30Label);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.Mean10Label);
            this.Controls.Add(this.NameLabel);
            this.Name = "StatsIndicator";
            this.Size = new System.Drawing.Size(88, 88);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label Mean10Label;
        private System.Windows.Forms.Label Mean30Label;
        private System.Windows.Forms.Label Range10Label;
        private System.Windows.Forms.Label DescriptionLabel;
    }
}
