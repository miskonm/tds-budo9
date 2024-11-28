using System;
using UnityEngine;

namespace TDS.Service.Input
{
    public class PCInputService : MonoBehaviour, IInputService
    {
        #region Variables

        private Camera _camera;
        private bool _isInitialized;
        private Transform _playerTransform;

        #endregion

        #region Events

        public event Action OnAttacked;

        #endregion

        #region Properties

        public Vector3 LookDirection => !_isInitialized ? Vector3.zero : GetLookDirection();
        public Vector2 MoveDirection =>
            !_isInitialized
                ? Vector2.zero
                : new Vector2(UnityEngine.Input.GetAxis("Horizontal"), UnityEngine.Input.GetAxis("Vertical"));

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (!_isInitialized)
            {
                return;
            }
            
            if (UnityEngine.Input.GetButtonDown("Fire1"))
            {
                OnAttacked?.Invoke();
            }
        }

        #endregion

        #region IInputService

        public void Dispose()
        {
            _camera = null;
            _playerTransform = null;
            _isInitialized = false;
        }

        public void Initialize(Camera mainCamera, Transform playerTransform)
        {
            _isInitialized = true;
            _camera = mainCamera;
            _playerTransform = playerTransform;
        }

        #endregion

        #region Private methods

        private Vector3 GetLookDirection()
        {
            Vector3 mousePosition = UnityEngine.Input.mousePosition;
            Vector3 mouseWorldPoint = _camera.ScreenToWorldPoint(mousePosition);
            mouseWorldPoint.z = _playerTransform.position.z;
            return mouseWorldPoint - _playerTransform.position;
        }

        #endregion
    }
}