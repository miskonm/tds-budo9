using TDS.Utils.Log;
using Zenject;

namespace TDS.Infrastructure.State
{
    public class StateMachineInstaller : Installer<StateMachineInstaller>
    {
        public override void InstallBindings()
        {
            this.Error();
            Container.Bind<StateMachine>().AsSingle();
            Container.Bind<StateFactory>().AsSingle();
        }
    }
}