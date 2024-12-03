using Zenject;

namespace TDS.Service.Coroutine
{
    public class CoroutineRunnerInstaller : Installer<CoroutineRunnerInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container.Bind<CoroutineRunner>().FromNewComponentOnNewGameObject().AsSingle();
        }

        #endregion
    }
}