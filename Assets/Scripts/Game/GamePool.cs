using Lean.Pool;
using UnityEngine;

namespace TDS.Game
{
    public class GamePool
    {
        #region Public methods

        public static void Despawn(GameObject go)
        {
            LeanPool.Despawn(go);
        }

        public static void Spawn(GameObject prefab, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            LeanPool.Spawn(prefab, position, rotation, parent);
        }

        public static void Spawn<T>(T prefab, Vector3 position, Quaternion rotation, Transform parent = null)
            where T : Component
        {
            LeanPool.Spawn(prefab, position, rotation, parent);
        }

        #endregion
    }
}