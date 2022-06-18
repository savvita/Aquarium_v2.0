using Aquarium.Controller;

namespace Aquarium.View
{
    public partial class PandaAddFishControl : AddFishControl
    {
        public PandaAddFishControl() : base(new PandaFishController())
        {
        }
    }
}
