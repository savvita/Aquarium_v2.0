using Aquarium.Controller;

namespace Aquarium.View
{
    public partial class BearSellFishControl : SellFishControl
    {
        public BearSellFishControl() : base(new BearFishController())
        {
        }
    }
}
