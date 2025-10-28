using Character.Service;
using Config;
using Scene;
using State;
using UnityEngine;
using UnityEngine.UI;

namespace Character.UI
{
    public class CharacterSelectorPresenter : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private CharacterCatalog characterCatalog;

        [Header("UI")]
        [SerializeField] private Button generateButton;
        [SerializeField] private Button playButton;
        [SerializeField] private Transform previewRoot;

        private CharacterSelectionService _service;
        private GameObject _currentPreviewInstance;

        private void Awake()
        {
            var repo = new CharacterRepository(characterCatalog);
            _service = new CharacterSelectionService(repo, GameState.Instance, new UnitySceneLoader());

            generateButton.onClick.AddListener(OnGenerateClicked);
            playButton.onClick.AddListener(OnPlayClicked);
        }

        private void OnGenerateClicked()
        {
            var chosen = _service.SelectRandomCharacter();

            if (_currentPreviewInstance != null)
                Destroy(_currentPreviewInstance);

            _currentPreviewInstance = Instantiate(chosen.Prefab, previewRoot.position, Quaternion.identity, previewRoot);
        }

        private void OnPlayClicked() => _service.StartGame();
    }
}