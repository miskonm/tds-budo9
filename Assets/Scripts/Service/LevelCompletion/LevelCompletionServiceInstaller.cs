using Zenject;

namespace TDS.Service.LevelCompletion
{
    public class LevelCompletionServiceInstaller : Installer<LevelCompletionServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<LevelCompletionService>().AsSingle();
        }
    }
}