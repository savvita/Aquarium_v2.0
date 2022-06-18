using Aquarium.Controller;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Aquarium.View
{
    public partial class SellFishForm : FishForm
    {
        private Dictionary<FishTypes, int> count;

        private AquariumController controller;
        public SellFishForm(AquariumController controller) : base()
        {
            this.Text = "Sell a fish";

            this.controller = controller;

            count = new Dictionary<FishTypes, int>();


            InitializeControls();
        }

        protected override void InitializeControls()
        {
            this.controls.Clear();
            this.Controls.Clear();

            foreach (var t in Enum.GetValues(typeof(FishTypes)))
            {
                count[(FishTypes)t] = 0;
            }

            foreach (FishController controller in controller.FishControllers)
            {
                count[controller.FishType]++;
            }

            foreach(FishTypes type in count.Keys)
            {
                if (count[type] > 0)
                {
                    AddControl(type);
                }
            }

            SetLocations();

            controls.ForEach((control) => control.ButtonClicked += Control_SellButtonClicked);

            this.Controls.AddRange(controls.ToArray());
        }

        private void AddControl(FishTypes type)
        {
            switch(type)
            {
                case FishTypes.Monster:
                    controls.Add(new MonsterSellFishControl());
                    break;

                case FishTypes.Panda:
                    controls.Add(new PandaSellFishControl());
                    break;

                case FishTypes.Bear:
                    controls.Add(new BearSellFishControl());
                    break;

                case FishTypes.Korgie:
                    controls.Add(new KorgieSellFishControl());
                    break;
            }
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

        private void Control_SellButtonClicked(FishControl control)
        {
            OnButtonClicked(control.Type);

            this.Close();
        }

        public void UpdateControls()
        {
            InitializeControls();
        }
    }
}
