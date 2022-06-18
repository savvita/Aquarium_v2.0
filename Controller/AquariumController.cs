using Aquarium.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Aquarium.Controller
{
    public class AquariumController
    {
        #region Controllers
        public List<FishController> FishControllers { get; }
        private FoodController foodController;
        #endregion

        #region Score
        private double score = 0;

        /// <summary>
        /// Sum of scores of dead fish
        /// </summary>
        private double deadScore = 0;

        /// <summary>
        /// Current score
        /// </summary>
        public int Score
        {
            get => (int)score - Buys;
            private set { }
        }

        /// <summary>
        /// Sum of buyings and sellings
        /// </summary>
        public int Buys { get; set; } 
        #endregion

        /// <summary>
        /// Bounds of the fish
        /// </summary>
        /// <param name="index">Index of the fish</param>
        /// <returns></returns>
        public Rectangle FishBounds(int index) => FishControllers[index].FishRectangle;

        #region Fish
        public List<Rectangle> FishImageBounds { get; private set; }

        public Rectangle FoodImageBounds
        {
            get => new Rectangle(foodController.ImageBounds.StartX, foodController.ImageBounds.StartY,
                foodController.ImageBounds.Width, foodController.ImageBounds.Height);
        }


        public FishModel Fish(int index)
        {
            return FishControllers[index].Fish;
        }

        public int FishCount
        {
            get => FishControllers.Count;
        }

        public int LiveFishCount { get => FishControllers.Where((item) => item.Fish.IsAlive).Count(); } 
        #endregion

        #region Food
        /// <summary>
        /// List of food at the aquarium
        /// </summary>
        public List<FoodModel> Food
        {
            get => foodController.Food;
        }

        /// <summary>
        /// Image of one item of food
        /// </summary>
        public Bitmap FoodImage
        {
            get => foodController.Image;
        } 
        #endregion

        public AquariumController(List<FishController> fishController, FoodController foodController)
        {
            this.FishControllers = fishController;
            this.foodController = foodController;
            FishImageBounds = new List<Rectangle>(this.FishControllers.Count);

            for (int i = 0; i < this.FishControllers.Count; i++)
            {
                FishImageBounds.Add(new Rectangle());
            }
        }

        /// <summary>
        /// Create new food
        /// </summary>
        /// <param name="location">Location of the new food</param>
        /// <returns></returns>
        public FoodModel CreateFood(Point location) => foodController.CreateFood(location);

        /// <summary>
        /// Add new fish
        /// </summary>
        /// <param name="controller">Fish to add</param>
        public void AddFish(FishController controller)
        {
            this.FishControllers.Add(controller);
            FishImageBounds.Add(new Rectangle());
        }

        /// <summary>
        /// Remove fish and save its score
        /// </summary>
        /// <param name="controller">Fish to remove</param>
        public void RemoveFish(FishController controller)
        {
            controller.TimeOfDeath = DateTime.Now;
            deadScore += controller.Score;
            this.FishControllers.Remove(controller);
        }

        #region Edit last time eat and creation time properties
        
        /// <summary>
        /// Set the property at the beginning of the game
        /// </summary>
        public void SetTheLastEatTime() => FishControllers.ForEach((item) => item.Fish.LastEat = DateTime.Now);

        /// <summary>
        /// Update timing, excluding time of the pause
        /// </summary>
        /// <param name="interval">Pause time</param>
        public void UpdateTimeProperty(TimeSpan interval)
        { 
            FishControllers.ForEach((item) =>
            {
                item.Fish.LastEat = item.Fish.LastEat.Add(interval);
                item.CreationTime = item.CreationTime.Add(interval);
            }); 
        }

        #endregion

        #region Move fish

        /// <summary>
        /// Move all fish, all food. Handle dead fish. Set score
        /// </summary>
        /// <param name="minWidth">Left bound of the aquarium<</param>
        /// <param name="maxWidth">Right bound of the aquarium<</param>
        /// <param name="minHeight">Top bound of the aquarium<</param>
        /// <param name="maxHeight">Bottom bound of the aquarium<</param>
        public void MoveAll(int minWidth, int maxWidth, int minHeight, int maxHeight)
        {
            FindDeadFish();

            MoveFish(minWidth, maxWidth);

            foodController.Fall(minHeight, maxHeight);

            EatFood();

            SetScore();
        }

        /// <summary>
        /// Find dead fish, save its score and remove if it is out of bounds
        /// </summary>
        private void FindDeadFish()
        {
            for (int i = 0; i < FishControllers.Count; i++)
            {
                if (!FishControllers[i].Fish.IsAlive && !FishControllers[i].IsTimeOfDeathSet)
                {
                    FishControllers[i].TimeOfDeath = DateTime.Now;
                    deadScore += FishControllers[i].Score;
                }

                if (FishControllers[i].Fish.Location.Y + FishControllers[i].Fish.Size.Height < 0)
                {
                    FishControllers.Remove(FishControllers[i]);
                    FishImageBounds.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Move the fish depending of presence the food
        /// </summary>
        /// <param name="minWidth">Left bound of the aquarium</param>
        /// <param name="maxWidth">Right bound of the aquarium</param>
        private void MoveFish(int minWidth, int maxWidth)
        {
            if (foodController.Food.Count > 0)
            {
                for (int i = 0; i < FishControllers.Count; i++)
                {
                    int idx = FishControllers[i].FindNearestFood(foodController.Food);
                    FishImageBounds[i] = FishControllers[i].MoveTo(foodController.Food[idx]);
                }
            }
            else
            {
                for (int i = 0; i < FishControllers.Count; i++)
                    FishImageBounds[i] = FishControllers[i].Walk(minWidth, maxWidth);
            }
        }

        /// <summary>
        /// Eat food, checking each fish and each food
        /// </summary>
        private void EatFood()
        {
            for (int i = 0; i < foodController.Food.Count; i++)
            {
                for (int j = 0; j < FishControllers.Count; j++)
                {
                    if (FishControllers[j].IsEat(this.foodController.Food[i]))
                    {
                        FishControllers[j].Fish.LastEat = DateTime.Now;
                        foodController.Food.Remove(this.foodController.Food[i]);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Evaluate current score
        /// </summary>
        private void SetScore()
        {
            score = deadScore;
            foreach (FishController controller in FishControllers)
            {
                if (controller.Fish.IsAlive)
                {
                    score += controller.Score;
                }
            }
        } 
        #endregion
    }
}
