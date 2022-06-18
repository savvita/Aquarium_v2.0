using Aquarium.Model;
using System;

namespace Aquarium.Controller
{
    public class BearFishController : FishController
    {
        public BearFishController() : base(
            new SpriteImageModel(
            Properties.Resources.Bears, 3, new ImageBounds(0, 68, 56, 45), new ImageBounds(0, 124, 55, 40),new ImageBounds(0, 167, 55, 60), new ImageBounds(0, 0, 55, 60)),
            new TimeSpan(0, 2, 0), FishTypes.Bear)
        {
            Fish.Speed = 5;
            ScoreRate = 0.1;
            Cost = 1000;
            SellRate = 0.9;
            Description = "Crazy Vinnie";
        }
    }
}
