using TDS.Service.Input;
using UnityEngine;

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

        #region Unity lifecycle

        private void Start()
        {
            // TODO: Nikita fix it
            // _inputService.OnAttacked += AttackedCallback;
        }

        private void OnDestroy()
        {
            if (_inputService != null)
            {
                _inputService.OnAttacked -= AttackedCallback;
            }
        }

        #endregion

        #region Public methods

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            // TODO: Nikita this is kostil
            _inputService.OnAttacked += AttackedCallback;
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