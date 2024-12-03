using TDS.Service.Input;
using UnityEngine;
using Zenject;

namespace TDS.Game
{
    public class PlayerAttack : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;

        [Header("Settings")]
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPointTransform;

        private IInputService _inputService;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _inputService.OnAttacked += AttackedCallback;
        }

        private void OnDestroy()
        {
            _inputService.OnAttacked -= AttackedCallback;
        }

        #endregion

        #region Private methods

        private void AttackedCallback()
        {
            Fire();
        }

        private void Fire()
        {
            _animation.TriggerAttack();
            GamePool.Spawn(_bulletPrefab, _spawnPointTransform.position, _spawnPointTransform.rotation);
        }

        #endregion
    }
}