using Character.Service;
using Config;
using State;
using UnityEngine;
using UnityEngine.UI;

namespace Scene.UI
{
    public class GameScenePresenter : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private CharacterCatalog characterCatalog;

        [Header("Scene refs")]
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Button backButton;

        private CharacterSelectionService _characterSelectionService;

        private void Awake()
        {
            var repo = new CharacterRepository(characterCatalog);
            _characterSelectionService = new CharacterSelectionService(repo, GameState.Instance, new UnitySceneLoader());

            backButton.onClick.AddListener(OnBackClicked);
        }

        private void Start()
        {
            var selected = _characterSelectionService.GetSelectedCharacter();
            
            if (selected == null)
                return;
            
            Instantiate(selected.Prefab, spawnPoint.position, Quaternion.identity, spawnPoint);
        }

        private void OnBackClicked() => _characterSelectionService.BackToCharacterSelection();
    }
}