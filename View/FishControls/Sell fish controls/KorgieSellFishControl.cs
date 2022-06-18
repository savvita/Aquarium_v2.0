using Aquarium.Controller;

namespace Aquarium.View
{
    public partial class KorgieSellFishControl : SellFishControl
    {
        public KorgieSellFishControl() : base(new KorgieFishController())
        {
        }
    }
}
