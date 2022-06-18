using Aquarium.Model;
using System;

namespace Aquarium.Controller
{
    public class KorgieFishController : FishController
    {
        public KorgieFishController() : base (           
            new SpriteImageModel (Properties.Resources.Korgie, 3, 
                new ImageBounds(0, 230, 48, 50), new ImageBounds(0, 280, 48, 50), new ImageBounds(0, 330, 48, 50), new ImageBounds(0, 180, 48, 50)),
            new TimeSpan(0, 0, 30), FishTypes.Korgie)
        {
            Fish.Speed = 10;
            ScoreRate = 0;
            Cost = 10;
            SellRate = 0;
            Description = "Useless Korgie";
        }
    }
}
