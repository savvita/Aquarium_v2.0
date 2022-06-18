using System.Drawing;

namespace Aquarium.View
{
    public partial class AddFishForm : FishForm
    {
        public AddFishForm() : base()
        {
            this.Text = "Buy new fish";
            InitializeControls();
            RefreshControls();
        }

        protected override void InitializeControls()
        {
            controls.Add(new MonsterAddFishControl());
            controls.Add(new PandaAddFishControl());
            controls.Add(new BearAddFishControl());
            controls.Add(new KorgieAddFishControl());

            SetLocations();

            controls.ForEach((control) => control.ButtonClicked += Control_AddButtonClicked);

            this.Controls.AddRange(controls.ToArray());
        }

        private void SetLocations()
        {
            int margin = 20;

            int width = margin;
            int height = margin;

            foreach (FishControl control in controls)
            {
                control.Location = new Point(width, height);

                height += control.Height + margin;

                if (height + control.Height >= this.ClientRectangle.Height)
                {
                    height = margin;
                    width += control.Width + margin;
                }
            }
        }

        private void Control_AddButtonClicked(FishControl control)
        {
            OnButtonClicked(control.Type);

            this.Close();
        }

        public void RefreshControls()
        {
            controls.ForEach((item) =>
            {
                if (item.Cost <= ScoreToUse)
                    item.EnableButton();
                else
                    item.DisableButton();
            });
        }
    }
}
