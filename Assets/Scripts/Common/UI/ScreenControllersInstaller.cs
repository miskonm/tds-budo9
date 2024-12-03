using TDS.Common.UI.Game;
using Zenject;

namespace TDS.Common.UI
{
    public class ScreenControllersInstaller : Installer<ScreenControllersInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<GameScreenController>().AsSingle();
        }
    }
}