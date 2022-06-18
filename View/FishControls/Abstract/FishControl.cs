using Aquarium.Controller;
using System;
using System.Windows.Forms;

namespace Aquarium.View
{
    public abstract partial class FishControl : UserControl
    {
        public int Cost { get; private set; }

        public event Action<FishControl> ButtonClicked;

        public FishTypes Type { get; }

        public string ButtonText
        {
            get => button.Text;

            set
            {
                button.Text = value;
            }
        }

        public void SetCost(int cost)
        {
            Cost = cost;
            this.costValue.Text = cost.ToString();
        }

        #region Constructors
        public FishControl()
        {
            InitializeComponent();
        }

        public FishControl(FishController controller) : this()
        {
            this.descriptionLabel.Text = controller.Description;
            this.liveValue.Text = controller.Fish.LiveWithoutFood.TotalSeconds.ToString();
            this.scoreRateValue.Text = controller.ScoreRate.ToString();
            this.costValue.Text = controller.Cost.ToString();

            this.pictureBox.Image = controller.Fish.Image.Clone(controller.SpriteImage.MovingRightImageBounds.Rectangle, controller.Fish.Image.PixelFormat);

            Cost = controller.Cost;
            Type = controller.FishType;
        } 
        #endregion

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (ButtonClicked != null)
                ButtonClicked(this);
        }

        public void EnableButton() => this.button.Enabled = true;

        public void DisableButton() => this.button.Enabled = false;
    }
}
