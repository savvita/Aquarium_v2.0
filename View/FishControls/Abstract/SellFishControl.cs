using Aquarium.Controller;

namespace Aquarium.View
{
    public partial class SellFishControl : FishControl
    {
        public SellFishControl(FishController controller) : base(controller)
        {
            ButtonText = "Sell";
            SetCost((int)(controller.Cost * controller.SellRate));
        }
    }
}
