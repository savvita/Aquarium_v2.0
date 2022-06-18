using Aquarium.Model;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Aquarium.Controller
{
    public abstract class FishController
    {
        /// <summary>
        /// Current index in the sprite
        /// </summary>
        private int imageNumber = 0;

        /// <summary>
        /// Current move of the fish
        /// </summary>
        private Func<int, Rectangle> currentMove;

        /// <summary>
        /// Fish for controling
        /// </summary>
        public FishModel Fish { get; }

        /// <summary>
        /// Type of fish
        /// </summary>
        public FishTypes FishType { get; }

        /// <summary>
        /// Sum to pay for buying this fish
        /// </summary>
        public int Cost { get; protected set; }

        /// <summary>
        /// Sum to receive after selling this fish
        /// </summary>
        public double SellRate { get; protected set; }

        /// <summary>
        /// Description this fish
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Describe sprite image this fish
        /// </summary>
        public SpriteImageModel SpriteImage { get; protected set; }

        /// <summary>
        /// Bounds of the fish
        /// </summary>
        public Rectangle FishRectangle
        {
            get => new Rectangle(Fish.Location, Fish.Size);
        }

        /// <summary>
        /// Time of creation the fish
        /// </summary>
        public DateTime CreationTime { get; set; }

        /// <summary>
        /// Time of death of the fish
        /// </summary>
        private DateTime deathTime;
        public DateTime TimeOfDeath
        {
            get => deathTime;

            set
            {
                if (!IsTimeOfDeathSet)
                    deathTime = value;
            }
        }

        /// <summary>
        /// Indicates if the time of death is already set
        /// </summary>
        public bool IsTimeOfDeathSet
        {
            get => deathTime >= CreationTime;
        }

        /// <summary>
        /// Multiplier of the rate
        /// </summary>
        public double ScoreRate { get; protected set; }

        /// <summary>
        /// Total score
        /// </summary>
        public double Score
        {
            get
            {
                if (TimeOfDeath < CreationTime)
                    return ScoreRate * DateTime.Now.Subtract(CreationTime).TotalSeconds;
                else
                    return ScoreRate * TimeOfDeath.Subtract(CreationTime).TotalSeconds;
            }
        }

        /// <summary>
        /// Speed of dead fish
        /// </summary>
        private const int deadSpeed = 5;

        public FishController(SpriteImageModel spriteImage, TimeSpan liveWithoutFood, FishTypes type)
        {
            SpriteImage = spriteImage;

            FishType = type;

            Fish = new FishModel();
            Fish.Image = SpriteImage.Image;
            Fish.Image.MakeTransparent();
            Fish.Size = new Size(SpriteImage.MovingRightImageBounds.Width, SpriteImage.MovingRightImageBounds.Height);
            Fish.LastEat = DateTime.Now;
            Fish.LiveWithoutFood = liveWithoutFood;

            CreationTime = DateTime.Now;

            currentMove = MoveRight;
        }

        /// <summary>
        /// Move the fish from left to right and from right to left
        /// </summary>
        /// <param name="min">Minimum value of location X</param>
        /// <param name="max">Maximum value of location X</param>
        /// <returns>Bounds of the image in the sprite for current moving</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Rectangle Walk(int min, int max)
        {
            if (Fish == null)
                throw new ArgumentNullException(nameof(Fish));

            if (min >= max)
                throw new ArgumentException("Max cannot be less or equal min");

            if(!Fish.IsAlive)
            {
                return MoveDead();
            }

            else if(currentMove == MoveRight && (Fish.Location.X + Fish.Speed >= max - Fish.Size.Width))
            {
                currentMove = MoveLeft;
            }

            else if (currentMove == MoveLeft && (Fish.Location.X + Fish.Speed <= min))
            {
                currentMove = MoveRight;
            }

            return currentMove(Fish.Speed);
        }

        /// <summary>
        /// Move towards the food
        /// </summary>
        /// <param name="food">Food to eat</param>
        /// <returns>Bounds of the image in the sprite for moving</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Rectangle MoveTo(FoodModel food)
        {
            if (Fish == null)
                throw new ArgumentNullException(nameof(Fish));

            if (!Fish.IsAlive)
            {
                return MoveDead();
            }

            if (Fish.Location.X + Fish.Size.Width / 2 < food.Location.X)
                return MoveRight(3 * Fish.Speed);

            if (Fish.Location.X > food.Location.X)
                return MoveLeft(3 * Fish.Speed);

            if (Fish.Location.Y + Fish.Size.Height / 2 < food.Location.Y)
                return MoveDown(3 * Fish.Speed);

            if (Fish.Location.Y > food.Location.Y + food.Size.Height / 2)
                return MoveUp(3 * Fish.Speed);

            return new Rectangle(0, 0, 0, 0);
        }


        #region Moves

        /// <summary>
        /// Move location of the dead fish to the up
        /// </summary>
        /// <param name="speed">Shift on which the fish is moving</param>
        /// <returns>Bounds for the image in the sprite for current moving</returns>
        private Rectangle MoveDead()
        {
            Fish.Location = new Point(Fish.Location.X, Fish.Location.Y - deadSpeed);
            
            Rectangle rect;

            if (currentMove == MoveRight)
            {
                Fish.Size = new Size(SpriteImage.MovingRightImageBounds.Width, SpriteImage.MovingRightImageBounds.Height);
                rect = new Rectangle(SpriteImage.MovingRightImageBounds.StartX + 3 * SpriteImage.MovingRightImageBounds.Width,
                    SpriteImage.MovingRightImageBounds.StartY, SpriteImage.MovingRightImageBounds.Width, SpriteImage.MovingRightImageBounds.Height);
            }
            else
            {
                Fish.Size = new Size(SpriteImage.MovingLeftImageBounds.Width, SpriteImage.MovingLeftImageBounds.Height);

                rect = new Rectangle(SpriteImage.MovingLeftImageBounds.StartX + 3 * SpriteImage.MovingLeftImageBounds.Width,
                    SpriteImage.MovingLeftImageBounds.StartY, SpriteImage.MovingLeftImageBounds.Width, SpriteImage.MovingLeftImageBounds.Height);
            }       

            return rect;
        }

        /// <summary>
        /// Move location of the fish to the right
        /// </summary>
        /// <param name="speed">Shift on which the fish is moving</param>
        /// <returns>Bounds for the image in the sprite for current moving</returns>
        private Rectangle MoveRight(int speed)
        {
            Fish.Location = new Point(Fish.Location.X + speed, Fish.Location.Y);
            Fish.Size = new Size(SpriteImage.MovingRightImageBounds.Width, SpriteImage.MovingRightImageBounds.Height);

            Rectangle rect = new Rectangle(SpriteImage.MovingRightImageBounds.StartX + imageNumber * SpriteImage.MovingRightImageBounds.Width,
                SpriteImage.MovingRightImageBounds.StartY, SpriteImage.MovingRightImageBounds.Width, SpriteImage.MovingRightImageBounds.Height);

            imageNumber++;
            imageNumber %= SpriteImage.NumberOfImages;

            return rect;
        }

        /// <summary>
        /// Move location of the fish to the left
        /// </summary>
        /// <param name="speed">Shift on which the fish is moving</param>
        /// <returns>Bounds for the image in the sprite for current moving</returns>
        private Rectangle MoveLeft(int speed)
        {
            Fish.Location = new Point(Fish.Location.X - speed, Fish.Location.Y);
            Fish.Size = new Size(SpriteImage.MovingLeftImageBounds.Width, SpriteImage.MovingLeftImageBounds.Height);

            Rectangle rect = new Rectangle(SpriteImage.MovingLeftImageBounds.StartX + imageNumber * SpriteImage.MovingLeftImageBounds.Width,
                SpriteImage.MovingLeftImageBounds.StartY, SpriteImage.MovingLeftImageBounds.Width, SpriteImage.MovingLeftImageBounds.Height);

            imageNumber++;
            imageNumber %= SpriteImage.NumberOfImages;

            return rect;
        }

        /// <summary>
        /// Move location of the fish up
        /// </summary>
        /// <param name="speed">Shift on which the fish is moving</param>
        /// <returns>Bounds for the image in the sprite for current moving</returns>
        private Rectangle MoveUp(int speed)
        {
            Fish.Location = new Point(Fish.Location.X, Fish.Location.Y - speed);
            Fish.Size = new Size(SpriteImage.MovingUpImageBounds.Width, SpriteImage.MovingUpImageBounds.Height);

            Rectangle rect = new Rectangle(SpriteImage.MovingUpImageBounds.StartX + imageNumber * SpriteImage.MovingUpImageBounds.Width,
                SpriteImage.MovingUpImageBounds.StartY, SpriteImage.MovingUpImageBounds.Width, SpriteImage.MovingUpImageBounds.Height);

            imageNumber++;
            imageNumber %= SpriteImage.NumberOfImages;

            return rect;
        }

        /// <summary>
        /// Move location of the fish down
        /// </summary>
        /// <param name="speed">Shift on which the fish is moving</param>
        /// <returns>Bounds for the image in the sprite for current moving</returns>
        private Rectangle MoveDown(int speed)
        {
            Fish.Location = new Point(Fish.Location.X, Fish.Location.Y + speed);
            Fish.Size = new Size(SpriteImage.MovingUpImageBounds.Width, SpriteImage.MovingUpImageBounds.Height);

            Rectangle rect = new Rectangle(SpriteImage.MovingDownImageBounds.StartX + imageNumber * SpriteImage.MovingDownImageBounds.Width,
                SpriteImage.MovingDownImageBounds.StartY, SpriteImage.MovingDownImageBounds.Width, SpriteImage.MovingDownImageBounds.Height);

            imageNumber++;
            imageNumber %= SpriteImage.NumberOfImages;

            return rect;
        } 
        #endregion

        /// <summary>
        /// Eat the food
        /// </summary>
        /// <param name="food">Food to eat</param>
        /// <returns>True if food is eaten false otherwise</returns>
        public bool IsEat(FoodModel food)
        {
            if(Fish.IsAlive && this.FishRectangle.IntersectsWith(food.Bounds))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Find the nearest food to the fish
        /// </summary>
        /// <param name="food">List of food</param>
        /// <returns>Index of food</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public int FindNearestFood(List<FoodModel> food)
        {
            if (Fish == null)
                throw new ArgumentNullException(nameof(Fish));

            if (food == null)
                throw new ArgumentNullException(nameof(food));

            if (food.Count == 0)
                throw new ArgumentException("List of foo d is empty");

            double min = Distance(Fish.Location, food[0].Location);
            int index = 0;

            for (int i = 1; i < food.Count; i++)
            {
                double d = Distance(Fish.Location, food[i].Location);

                if (d < min)
                {
                    min = d;
                    index = i;
                }
            }

            return index;
        }

        /// <summary>
        /// Distance between two points
        /// </summary>
        /// <param name="a">Point A</param>
        /// <param name="b">Point B</param>
        /// <returns>Distance between two points</returns>
        private double Distance(Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
    }
}
