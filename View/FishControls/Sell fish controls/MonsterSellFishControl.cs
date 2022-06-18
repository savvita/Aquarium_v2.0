using Aquarium.Controller;

namespace Aquarium.View
{
    public partial class MonsterSellFishControl : SellFishControl
    {
        public MonsterSellFishControl() : base(new MonsterFishController())
        {
        }
    }
}
