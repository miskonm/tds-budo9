using System.IO;
using TDS.Utils.Log;
using UnityEngine;

namespace TDS.Service.UI
{
    public class UIScreenProvider
    {
        #region Variables

        private const string FolderPath = "UI/Screens";

        #endregion

        #region Public methods

        public T GetPrefab<T>() where T : UIScreen
        {
            string fullPath = Path.Combine(FolderPath, typeof(T).Name);
            return Resources.Load<T>(fullPath);
        }

        #endregion
    }
}