using Aquarium.Controller;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aquarium.View
{
    public abstract partial class FishForm : Form
    {
        public int ScoreToUse { get; set; }

        public event Action<FishTypes> ButtonClicked;

        protected List<FishControl> controls = new List<FishControl>();

        public FishForm()
        {
            InitializeComponent();
        }

        protected abstract void InitializeControls();

        protected void OnButtonClicked(FishTypes type)
        {
            if (ButtonClicked != null)
                ButtonClicked(type);
        }
    }
}
