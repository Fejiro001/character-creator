namespace CharacterCreator
{
    public class GameWorld
    {
        private static GameWorld _gameWorldInstance;
        private static readonly object _lock = new object();

        public string Difficulty { get; set; } = "Normal";
        public int WorldTime { get; private set; } = 1; // Track days
        public string CurrentRegion { get; set; } = "Whispering Woods";
        public string Weather { get; private set; } = "Clear Skies";

        private GameWorld() { }

        public static GameWorld GetInstance()
        {
            if (_gameWorldInstance == null)
            {
                lock (_lock)
                {
                    if (_gameWorldInstance == null)
                    {
                        _gameWorldInstance = new GameWorld();
                    }
                }
            }
            return _gameWorldInstance;
        }

        public void AdvanceTime()
        {
            WorldTime++;
            Console.WriteLine($"[GameWorld]: The sun shifts. World Time advances to Day {WorldTime}.");

            UpdateWeather();
        }

        private void UpdateWeather()
        {
            Weather = (WorldTime % 2 == 0) ? "Heavy Rain" : "Clear Skies";
            Console.WriteLine($"[GameWorld]: Current weather in {CurrentRegion}: {Weather}");
        }

        public void DisplayWorldStatus()
        {
            Console.WriteLine("\n================== WORLD STATUS ==================");
            Console.WriteLine($" Region: {CurrentRegion}");
            Console.WriteLine($" Day: {WorldTime}");
            Console.WriteLine($" Difficulty: {Difficulty}");
            Console.WriteLine($" Weather: {Weather}");
            Console.WriteLine("==================================================\n");
        }
    }
}
