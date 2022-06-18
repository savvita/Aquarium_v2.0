using Aquarium.Controller;

namespace Aquarium.View
{
    public partial class AddFishControl : FishControl
    {
        public AddFishControl(FishController controller) : base (controller)
        {
            ButtonText = "Buy";
        }
    }
}
