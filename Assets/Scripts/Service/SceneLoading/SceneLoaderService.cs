using UnityEngine.SceneManagement;

namespace TDS.Service.SceneLoading
{
    public class SceneLoaderService
    {
        #region Public methods

        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadAsync(string sceneName) { }

        #endregion
    }
}