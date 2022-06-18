using Aquarium.Controller;

namespace Aquarium.View
{
    public partial class BearAddFishControl : AddFishControl
    {
        public BearAddFishControl() : base(new BearFishController())
        {
        }
    }
}
