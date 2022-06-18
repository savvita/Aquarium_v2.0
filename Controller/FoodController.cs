using Aquarium.Model;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Aquarium.Controller
{
    public class FoodController
    {
        private Random random = new Random();
        public List<FoodModel> Food { get; }

        /// <summary>
        /// Image of the food
        /// </summary>
        public Bitmap Image { get; set; }

        /// <summary>
        /// Bounds for the image in the sprite
        /// </summary>
        public ImageBounds ImageBounds { get; set; }

        public FoodController(Bitmap image, ImageBounds imageBounds)
        {
            Image = image;
            ImageBounds = imageBounds;

            Food = new List<FoodModel>();
        }

        /// <summary>
        /// Create new food
        /// </summary>
        /// <param name="location">Location of food</param>
        /// <returns>Foodmodel</returns>
        public FoodModel CreateFood(Point location)
        {
            FoodModel food = new FoodModel { Location = location, Size = new Size(20, 20), Speed = random.Next(2, 15) };

            this.Food.Add(food);

            return food;
        }

        /// <summary>
        /// Move the food down
        /// </summary>
        /// <param name="min">Minimum value of loaction Y</param>
        /// <param name="max">Maximum value of loaction Y</param>
        /// <returns>Bounds of the image in the sprite for current food</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Rectangle Fall(int min, int max)
        {
            if (Food == null)
                throw new ArgumentNullException(nameof(Food));

            if (min >= max)
                throw new ArgumentException("Max cannot be less or equal min");

            for (int i = 0; i < Food.Count; i++)
            {
                Food[i].Location = new Point(Food[i].Location.X, Food[i].Location.Y + Food[i].Speed);

                if (Food[i].Location.Y >= max)
                {
                    Food.Remove(Food[i]);
                }
            }

            Rectangle rect = new Rectangle(ImageBounds.StartX, ImageBounds.StartY, ImageBounds.Width, ImageBounds.Height);

            return rect;
        }
    }
}
