using Zenject;

namespace TDS.Service.Mission
{
    public class MissionServiceInstaller : Installer<MissionServiceInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MissionService>().FromNewComponentOnNewGameObject().AsSingle();
        }
    }
}