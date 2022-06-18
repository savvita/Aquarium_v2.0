using Aquarium.Model;
using System;

namespace Aquarium.Controller
{
    public class MonsterFishController : FishController
    {
        public MonsterFishController() : base (
            new SpriteImageModel (Properties.Resources.Something, 4,
            new ImageBounds(0, 90, 90, 60), new ImageBounds(0, 164, 90, 60), new ImageBounds(0, 230, 90, 90), new ImageBounds(0, 0, 90, 80)),
            new TimeSpan(0, 0, 10), FishTypes.Monster)
        {
            Fish.Speed = 15;
            ScoreRate = 2;
            Cost = 5000;
            SellRate = 0.3;
            Description = "Cutie";
        }
    }
}
