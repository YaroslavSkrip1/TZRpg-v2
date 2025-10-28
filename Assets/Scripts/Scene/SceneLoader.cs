
using Scene.Impls;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class UnitySceneLoader : ISceneLoader
    {
        public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);
    }
}