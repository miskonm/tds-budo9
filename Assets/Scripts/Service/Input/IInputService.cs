using System;
using UnityEngine;

namespace TDS.Service.Input
{
    public interface IInputService
    {
        #region Events

        event Action OnAttacked;

        #endregion

        #region Properties

        Vector3 LookDirection { get; }
        Vector2 MoveDirection { get; }

        #endregion

        #region Public methods

        void Dispose();
        void Initialize(Camera mainCamera, Transform playerTransform);

        #endregion
    }
}