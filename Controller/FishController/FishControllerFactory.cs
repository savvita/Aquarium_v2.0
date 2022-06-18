
namespace Aquarium.Controller
{
    public static class FishControllerFactory
    {
        public static FishController Create (FishTypes type)
        {
            FishController controller = null;

            switch(type)
            {
                case FishTypes.Bear:
                    controller = new BearFishController();
                    break;

                case FishTypes.Panda:
                    controller = new PandaFishController();
                    break;

                case FishTypes.Korgie:
                    controller = new KorgieFishController();
                    break;

                case FishTypes.Monster:
                    controller = new MonsterFishController();
                    break;
            }

            return controller;
        }
    }

    public enum FishTypes
    {
        Monster,
        Bear,
        Panda,
        Korgie
    }
}
