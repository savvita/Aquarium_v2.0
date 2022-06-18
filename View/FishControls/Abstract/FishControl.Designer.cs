namespace Aquarium.View
{
    partial class FishControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.scoreRateLabel = new System.Windows.Forms.Label();
            this.scoreRateValue = new System.Windows.Forms.Label();
            this.liveLabel = new System.Windows.Forms.Label();
            this.liveValue = new System.Windows.Forms.Label();
            this.costLabel = new System.Windows.Forms.Label();
            this.costValue = new System.Windows.Forms.Label();
            this.button = new System.Windows.Forms.Button();
            this.descriptionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Lavender;
            this.pictureBox.Location = new System.Drawing.Point(34, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(98, 71);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // scoreRateLabel
            // 
            this.scoreRateLabel.AutoSize = true;
            this.scoreRateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreRateLabel.ForeColor = System.Drawing.Color.Lavender;
            this.scoreRateLabel.Location = new System.Drawing.Point(11, 109);
            this.scoreRateLabel.Name = "scoreRateLabel";
            this.scoreRateLabel.Size = new System.Drawing.Size(66, 15);
            this.scoreRateLabel.TabIndex = 1;
            this.scoreRateLabel.Text = "Score rate:";
            // 
            // scoreRateValue
            // 
            this.scoreRateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreRateValue.ForeColor = System.Drawing.Color.Lavender;
            this.scoreRateValue.Location = new System.Drawing.Point(110, 107);
            this.scoreRateValue.Name = "scoreRateValue";
            this.scoreRateValue.Size = new System.Drawing.Size(36, 23);
            this.scoreRateValue.TabIndex = 2;
            this.scoreRateValue.Text = "0";
            // 
            // liveLabel
            // 
            this.liveLabel.AutoSize = true;
            this.liveLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.liveLabel.ForeColor = System.Drawing.Color.Lavender;
            this.liveLabel.Location = new System.Drawing.Point(11, 134);
            this.liveLabel.Name = "liveLabel";
            this.liveLabel.Size = new System.Drawing.Size(101, 15);
            this.liveLabel.TabIndex = 3;
            this.liveLabel.Text = "Live without food:";
            // 
            // liveValue
            // 
            this.liveValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.liveValue.ForeColor = System.Drawing.Color.Lavender;
            this.liveValue.Location = new System.Drawing.Point(110, 134);
            this.liveValue.Name = "liveValue";
            this.liveValue.Size = new System.Drawing.Size(36, 23);
            this.liveValue.TabIndex = 4;
            this.liveValue.Text = "0";
            // 
            // costLabel
            // 
            this.costLabel.AutoSize = true;
            this.costLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.costLabel.ForeColor = System.Drawing.Color.Lavender;
            this.costLabel.Location = new System.Drawing.Point(11, 159);
            this.costLabel.Name = "costLabel";
            this.costLabel.Size = new System.Drawing.Size(34, 15);
            this.costLabel.TabIndex = 5;
            this.costLabel.Text = "Cost:";
            // 
            // costValue
            // 
            this.costValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.costValue.ForeColor = System.Drawing.Color.Lavender;
            this.costValue.Location = new System.Drawing.Point(110, 159);
            this.costValue.Name = "costValue";
            this.costValue.Size = new System.Drawing.Size(36, 23);
            this.costValue.TabIndex = 6;
            this.costValue.Text = "0";
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.Color.LightSteelBlue;
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button.ForeColor = System.Drawing.Color.Navy;
            this.button.Location = new System.Drawing.Point(71, 185);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 23);
            this.button.TabIndex = 8;
            this.button.Text = "Button";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.Button_Clicked);
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.descriptionLabel.ForeColor = System.Drawing.Color.Lavender;
            this.descriptionLabel.Location = new System.Drawing.Point(11, 86);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(152, 23);
            this.descriptionLabel.TabIndex = 9;
            this.descriptionLabel.Text = "Description";
            // 
            // FishControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.button);
            this.Controls.Add(this.costValue);
            this.Controls.Add(this.costLabel);
            this.Controls.Add(this.liveValue);
            this.Controls.Add(this.liveLabel);
            this.Controls.Add(this.scoreRateValue);
            this.Controls.Add(this.scoreRateLabel);
            this.Controls.Add(this.pictureBox);
            this.Name = "FishControl";
            this.Size = new System.Drawing.Size(156, 218);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label scoreRateLabel;
        private System.Windows.Forms.Label scoreRateValue;
        private System.Windows.Forms.Label liveLabel;
        private System.Windows.Forms.Label liveValue;
        private System.Windows.Forms.Label costLabel;
        private System.Windows.Forms.Label costValue;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.Label descriptionLabel;
    }
}
