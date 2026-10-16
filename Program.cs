using CharacterCreator.Controllers;

namespace CharacterCreator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameController controller = new GameController();
            controller.RunGame();
        }
    }
}
