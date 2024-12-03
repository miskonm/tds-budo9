using TDS.Service.Input;
using TDS.Utils.Log;
using UnityEngine;
using Zenject;

namespace TDS.Game
{
    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private PlayerAnimation _animation;

        [Header("Settings")]
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _speed = 10;

        private IInputService _inputService;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(IInputService inputService)
        {
            this.Error();
            _inputService = inputService;
        }

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (_inputService == null)
            {
                return;
            }

            Move();
            Rotate();
        }

        #endregion

        #region Private methods

        private void Move()
        {
            Vector2 velocity = _inputService.MoveDirection * _speed;
            _rb.velocity = velocity;
            _animation.SetMovement(velocity.magnitude);
        }

        private void Rotate()
        {
            transform.up = _inputService.LookDirection;
        }

        #endregion
    }
}