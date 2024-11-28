using System;
using UnityEngine;
using UnityEngine.UI;

namespace TDS.Service.Input.UI
{
    public class JoystickView : MonoBehaviour
    {
        #region Variables

        [SerializeField] private bl_Joystick _moveJoystick;
        [SerializeField] private bl_Joystick _lookJoystick;
        [SerializeField] private Button _fireButton;

        #endregion

        #region Events

        public event Action OnFireButtonClicked;

        #endregion

        #region Properties

        public Vector2 LookDirection => new(_lookJoystick.Horizontal, _lookJoystick.Vertical);
        public Vector2 MoveDirection => new(_moveJoystick.Horizontal, _moveJoystick.Vertical);

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _fireButton.onClick.AddListener(FireButtonClickedCallback);
        }

        #endregion

        #region Private methods

        private void FireButtonClickedCallback()
        {
            OnFireButtonClicked?.Invoke();
        }

        #endregion
    }
}