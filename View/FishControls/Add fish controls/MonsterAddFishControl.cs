using Aquarium.Controller;

namespace Aquarium.View
{
    public partial class MonsterAddFishControl : AddFishControl
    {
        public MonsterAddFishControl() : base(new MonsterFishController())
        {
        }
    }
}
