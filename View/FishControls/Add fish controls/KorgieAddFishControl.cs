using Aquarium.Controller;

namespace Aquarium.View
{
    public partial class KorgieAddFishControl : AddFishControl
    {
        public KorgieAddFishControl() : base(new KorgieFishController())
        {
        }
    }
}
