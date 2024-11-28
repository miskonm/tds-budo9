using System;
using TDS.Service.Input.UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TDS.Service.Input
{
    public class MobileInputService : IInputService
    {
        #region Variables

        private const string PrefabPath = "UI/Game/JoystikView";

        private JoystickView _joystickView;
        private JoystickView _joystickViewPrefab;

        #endregion

        #region Events

        public event Action OnAttacked;

        #endregion

        #region Properties

        public Vector3 LookDirection => _joystickView == null ? Vector2.zero : _joystickView.LookDirection.normalized;
        public Vector2 MoveDirection => _joystickView == null ? Vector2.zero : _joystickView.MoveDirection.normalized;

        #endregion

        #region IInputService

        public void Dispose()
        {
            _joystickView.OnFireButtonClicked -= FireButtonClickedCallback;
            Object.Destroy(_joystickView);
            _joystickView = null;
        }

        public void Initialize(Camera mainCamera, Transform playerTransform)
        {
            LoadPrefabIfNeeded();
            InstantiateView();

            _joystickView.OnFireButtonClicked += FireButtonClickedCallback;
        }

        #endregion

        #region Private methods

        private void FireButtonClickedCallback()
        {
            OnAttacked?.Invoke();
        }

        private void InstantiateView()
        {
            _joystickView = Object.Instantiate(_joystickViewPrefab);
        }

        private void LoadPrefabIfNeeded()
        {
            if (_joystickViewPrefab == null)
            {
                _joystickViewPrefab = Resources.Load<JoystickView>(PrefabPath);
            }
        }

        #endregion
    }
}