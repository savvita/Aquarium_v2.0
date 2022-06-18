using System.Drawing;

namespace Aquarium.Model
{
    public class SpriteImageModel
    {
        /// <summary>
        /// Sprite image
        /// </summary>
        public Bitmap Image { get; set; }

        /// <summary>
        /// Number of images in the row for the one direction of moving
        /// </summary>
        public int NumberOfImages { get; set; }

        /// <summary>
        /// Bounds for the image in the sprite for moving left
        /// </summary>
        public ImageBounds MovingLeftImageBounds { get; set; }

        /// <summary>
        /// Bounds for the image in the sprite for moving right
        /// </summary>
        public ImageBounds MovingRightImageBounds { get; set; }

        /// <summary>
        /// Bounds for the image in the sprite for moving up
        /// </summary>
        public ImageBounds MovingUpImageBounds { get; set; }

        /// <summary>
        /// Bounds for the image in the sprite for moving down
        /// </summary>
        public ImageBounds MovingDownImageBounds { get; set; }

        public SpriteImageModel(
            Bitmap image, 
            int numberOfImages, 
            ImageBounds movingLeftImageBounds, 
            ImageBounds movingRightImageBounds, 
            ImageBounds movingUpImageBounds, 
            ImageBounds movingDownImageBounds)
        {
            Image = image;
            NumberOfImages = numberOfImages;
            MovingLeftImageBounds = movingLeftImageBounds;
            MovingRightImageBounds = movingRightImageBounds;
            MovingUpImageBounds = movingUpImageBounds;
            MovingDownImageBounds = movingDownImageBounds;
        }
    }
}
