using Aquarium.Controller;

namespace Aquarium.View
{
    public partial class PandaSellFishControl : SellFishControl
    {
        public PandaSellFishControl() : base(new PandaFishController())
        {
            
        }
    }
}
