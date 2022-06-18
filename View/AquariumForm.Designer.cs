namespace Aquarium.View
{
    partial class AquariumForm
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
            this.startButton = new System.Windows.Forms.Button();
            this.addFishLabel = new System.Windows.Forms.Label();
            this.sellFishLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.MenuBar;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startButton.Font = new System.Drawing.Font("Yu Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.ForeColor = System.Drawing.Color.Navy;
            this.startButton.Location = new System.Drawing.Point(235, 158);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(335, 90);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // addFishLabel
            // 
            this.addFishLabel.BackColor = System.Drawing.Color.Transparent;
            this.addFishLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addFishLabel.ForeColor = System.Drawing.Color.White;
            this.addFishLabel.Location = new System.Drawing.Point(673, 380);
            this.addFishLabel.Name = "addFishLabel";
            this.addFishLabel.Size = new System.Drawing.Size(115, 34);
            this.addFishLabel.TabIndex = 1;
            this.addFishLabel.Text = "Buy fish";
            this.addFishLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addFishLabel.Click += new System.EventHandler(this.AddFish_Click);
            // 
            // sellFishLabel
            // 
            this.sellFishLabel.BackColor = System.Drawing.Color.Transparent;
            this.sellFishLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sellFishLabel.ForeColor = System.Drawing.Color.White;
            this.sellFishLabel.Location = new System.Drawing.Point(673, 414);
            this.sellFishLabel.Name = "sellFishLabel";
            this.sellFishLabel.Size = new System.Drawing.Size(115, 34);
            this.sellFishLabel.TabIndex = 2;
            this.sellFishLabel.Text = "Sell fish";
            this.sellFishLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sellFishLabel.Click += new System.EventHandler(this.SellFish_Click);
            // 
            // AquariumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.BackgroundImage = global::Aquarium.Properties.Resources.Water;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sellFishLabel);
            this.Controls.Add(this.addFishLabel);
            this.Controls.Add(this.startButton);
            this.Name = "AquariumForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feed the fish";
            this.SizeChanged += new System.EventHandler(this.AquariumForm_SizeChanged);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AquariumForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label addFishLabel;
        private System.Windows.Forms.Label sellFishLabel;
    }
}