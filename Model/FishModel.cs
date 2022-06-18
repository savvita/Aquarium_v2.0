using System;
using System.Drawing;

namespace Aquarium.Model
{
    public class FishModel
    {
        public Bitmap Image { get; set; }

        public Point Location { get; set; }

        public Size Size { get; set; }

        public int Speed { get; set; }

        public DateTime LastEat { get; set; }

        public TimeSpan LiveWithoutFood { get; set; }

        public bool IsAlive { get => DateTime.Now.Subtract(LastEat) < LiveWithoutFood; }
    }
}
