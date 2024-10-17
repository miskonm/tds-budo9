using UnityEngine;
using UnityEngine.SceneManagement;

namespace TDS.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        #region Unity lifecycle

        private void Start()
        {
            Debug.Log("Bootstrapper Start");
            SceneManager.LoadScene("GameScene");
        }

        #endregion
    }
}