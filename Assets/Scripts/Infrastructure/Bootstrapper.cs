using TDS.Infrastructure.State;
using TDS.Utils.Log;
using UnityEngine;
using Zenject;

namespace TDS.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        #region Variables

        private StateMachine _stateMachine;

        #endregion

        #region Setup/Teardown

        [Inject]
        public void Construct(StateMachine stateMachine)
        {
            this.Error();
            _stateMachine = stateMachine;
        }

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            this.Error($"_stateMachine '{_stateMachine}'");
            _stateMachine.Enter<BootstrapState>();
        }

        #endregion
    }
}