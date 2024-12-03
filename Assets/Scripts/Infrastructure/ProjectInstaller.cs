using TDS.Common.UI;
using TDS.Infrastructure.State;
using TDS.Service.Coroutine;
using TDS.Service.Input;
using TDS.Service.LevelCompletion;
using TDS.Service.LevelLoading;
using TDS.Service.Mission;
using TDS.Service.SceneLoading;
using TDS.Service.UI;
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
            LevelCompletionServiceInstaller.Install(Container);
            MissionServiceInstaller.Install(Container);
            CoroutineRunnerInstaller.Install(Container);
            InputServiceInstaller.Install(Container);
            UIServiceInstaller.Install(Container);
            ScreenControllersInstaller.Install(Container);
        }
    }
}