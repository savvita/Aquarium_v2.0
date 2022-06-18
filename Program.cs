using Aquarium.Controller;
using Aquarium.Model;
using Aquarium.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aquarium
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FoodController foodController = new FoodController (Properties.Resources.Apple, new ImageBounds(370, 200, 200, 200));

            AquariumController controller = new AquariumController(
                new List<FishController> 
                { 
                    new MonsterFishController(), 
                }, 
                foodController);

            Application.Run(new AquariumForm(controller));
        }
    }
}
