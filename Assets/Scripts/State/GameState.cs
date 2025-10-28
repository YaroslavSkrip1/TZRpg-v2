
using Config.Data;

namespace State
{
    public sealed class GameState
    {
        private static GameState _instance;
        public static GameState Instance => _instance ?? (_instance = new GameState());
        private GameState() {}

        public CharacterEntry SelectedCharacter;
    }
}