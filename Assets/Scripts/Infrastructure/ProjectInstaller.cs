using TDS.Infrastructure.State;
using TDS.Service.LevelLoading;
using TDS.Service.SceneLoading;
using TDS.Utils.Log;
using Zenject;

namespace TDS.Infrastructure
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            this.Error();
            StateMachineInstaller.Install(Container);
            LevelLoadingServiceInstaller.Install(Container);
            SceneLoaderServiceInstaller.Install(Container);
        }
    }
}