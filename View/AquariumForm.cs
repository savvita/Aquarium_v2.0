using Aquarium.Controller;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Aquarium.View
{
    public partial class AquariumForm : Form
    {
        #region Graphics
        private Bitmap bufferedImage;
        private Bitmap foodImage;
        private Graphics graphics; 
        #endregion

        #region Threading
        private Thread thread;
        private SynchronizationContext context;
        private object obj = new object(); 
        #endregion
       
        private AquariumController controller;

        private Random random = new Random();

        private AddFishForm addFishForm;
        private SellFishForm sellFishForm;

        private event Action EverythingMoved;

        private void OnEverythingMoved(object obj)
        {
            if (EverythingMoved != null)
                EverythingMoved();
        }

        #region Constructors
        public AquariumForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.BackgroundImageLayout = ImageLayout.Center;

            this.bufferedImage = new Bitmap(this.Width, this.Height);
            this.graphics = Graphics.FromImage(bufferedImage);

            this.addFishLabel.Visible = false;
            this.sellFishLabel.Visible = false;

            this.EverythingMoved += MovingAll;
        }

        public AquariumForm(AquariumController controller) : this()
        {
            this.controller = controller;

            for (int i = 0; i < controller.FishCount; i++)
            {
                this.controller.Fish(i).Location = new Point(random.Next(this.ClientRectangle.Width), random.Next(this.ClientRectangle.Height));
            }

            this.foodImage = new Bitmap(this.controller.FoodImage);
            this.foodImage.MakeTransparent();
            this.foodImage.MakeTransparent(Color.White);

            this.addFishForm = new AddFishForm();
            this.addFishForm.ButtonClicked += AddFishForm_ButtonClicked;

            this.sellFishForm = new SellFishForm(this.controller);
            this.sellFishForm.ButtonClicked += SellFishForm_ButtonClicked;
        } 
        #endregion

        private void AddFishForm_ButtonClicked(FishTypes type)
        {
            FishController fishController = FishControllerFactory.Create(type);
            this.controller.Buys += fishController.Cost;
            fishController.Fish.Location = new Point(random.Next(this.ClientRectangle.Width), random.Next(this.ClientRectangle.Height));

            this.controller.AddFish(fishController);
        }

        private void SellFishForm_ButtonClicked(FishTypes type)
        {
            FishController fishController = controller.FishControllers.Where((item) => item.FishType == type).FirstOrDefault();

            if (fishController != null)
            {
                this.controller.Buys -= (int)(fishController.Cost * fishController.SellRate);
                this.controller.RemoveFish(fishController);
            }
        }

        private void MovingAll()
        {
            this.graphics.DrawImage(Properties.Resources.Water, this.ClientRectangle);

            this.controller.MoveAll(0, this.Width, 0, this.Height);

            for (int i = 0; i < controller.FishCount; i++)
            {
                this.graphics.DrawImage(controller.Fish(i).Image, this.controller.FishBounds(i), this.controller.FishImageBounds[i], GraphicsUnit.Pixel);
            }

            this.graphics.DrawString($"Score = {this.controller.Score}", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.AliceBlue, new Point(10, 10));

            this.graphics.DrawString($"Fish Count = {this.controller.LiveFishCount}", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.AliceBlue, new Point(10, 50));

            for (int i = 0; i < this.controller.Food.Count; i++)
            {
                this.graphics.DrawImage(foodImage, this.controller.Food[i].Bounds, this.controller.FoodImageBounds, GraphicsUnit.Pixel);
            }

            this.BackgroundImage = bufferedImage;
            this.Invalidate();
        }


        #region Form events
        private void AquariumForm_SizeChanged(object sender, EventArgs e)
        {
            this.bufferedImage = new Bitmap(this.Width, this.Height);
            this.graphics = Graphics.FromImage(bufferedImage);

            for (int i = 0; i < this.controller.FishCount; i++)
            {
                this.controller.Fish(i).Location = new Point(this.controller.Fish(i).Location.X, this.Height / 2);
            }
        }

        private void AquariumForm_MouseUp(object sender, MouseEventArgs e) => this.controller.CreateFood(new Point(e.X, e.Y));
        #endregion

        #region Button click events
        private void StartButton_Click(object sender, EventArgs e)
        {
            this.startButton.Visible = false;
            this.addFishLabel.Visible = true;
            this.sellFishLabel.Visible = true;

            controller.SetTheLastEatTime();

            this.Start();
        }

        private void AddFish_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;

            lock (obj)
            {
                addFishForm.ScoreToUse = controller.Score;
                addFishForm.RefreshControls();

                addFishForm.ShowDialog();
            }

            controller.UpdateTimeProperty(DateTime.Now.Subtract(start));
        }

        private void SellFish_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;

            lock (obj)
            {
                sellFishForm.UpdateControls();

                sellFishForm.ShowDialog();
            }

            controller.UpdateTimeProperty(DateTime.Now.Subtract(start));
        }
        #endregion

        private void Start()
        {
            context = SynchronizationContext.Current;

            thread = new Thread(MoveAllThreadStart);
            thread.IsBackground = true;
            thread.Start();
        }

        private void MoveAllThreadStart()
        {
            while (true)
            {
                lock (obj)
                {
                    context.Send(OnEverythingMoved, null);

                    Thread.Sleep(100); 
                }
            }
        }
    }
}
