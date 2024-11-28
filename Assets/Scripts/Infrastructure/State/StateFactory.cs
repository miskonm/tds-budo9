using TDS.Utils.Log;
using Zenject;

namespace TDS.Infrastructure.State
{
    public class StateFactory
    {
        #region Variables

        private readonly IInstantiator _instantiator;

        #endregion

        #region Setup/Teardown

        public StateFactory(IInstantiator instantiator)
        {
            this.Error();
            _instantiator = instantiator;
        }

        #endregion

        #region Public methods

        public T Create<T>() where T : State
        {
            return _instantiator.Instantiate<T>();
        }

        #endregion
    }
}