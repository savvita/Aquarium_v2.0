using Aquarium.Model;
using System;

namespace Aquarium.Controller
{
    public class PandaFishController : FishController
    {
        public PandaFishController() : base (
            new SpriteImageModel (Properties.Resources.Bears, 3,
            new ImageBounds(335, 68, 56, 45), new ImageBounds(335, 124, 55, 40), new ImageBounds(335, 167, 55, 60), new ImageBounds(335, 0, 55, 60)),
            new TimeSpan(1, 10, 10), FishTypes.Panda)
        {
            Fish.Speed = 3;
            ScoreRate = 1;
            Cost = 2000;
            SellRate = 0.5;
            Description = "Waterflow Panda";
        }
    }
}
