using System;
using Character.Service.Impls;
using Config.Data;
using Scene.Impls;
using State;

namespace Character.Service
{
    public class CharacterSelectionService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly GameState _gameState;
        private readonly ISceneLoader _sceneLoader;
        private readonly Random _random = new Random();

        public CharacterSelectionService(ICharacterRepository characterRepository, GameState gameState, ISceneLoader sceneLoader)
        {
            _characterRepository = characterRepository;
            _gameState = gameState;
            _sceneLoader = sceneLoader;
        }

        public CharacterEntry SelectRandomCharacter()
        {
            var all = _characterRepository.GetAll();
            if (all.Count == 0)
                throw new Exception("Character list is empty.");

            int index = _random.Next(all.Count);
            var chosen = all[index];
            _gameState.SelectedCharacter = chosen;

            return chosen;
        }

        public CharacterEntry GetSelectedCharacter() => _gameState.SelectedCharacter;

        public void StartGame() => _sceneLoader.LoadScene("Game");

        public void BackToCharacterSelection() => _sceneLoader.LoadScene("CharacterSelector");
    }
}