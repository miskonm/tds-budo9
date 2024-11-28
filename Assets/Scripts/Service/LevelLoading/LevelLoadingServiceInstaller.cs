using TDS.Utils.Log;
using Zenject;

namespace TDS.Service.LevelLoading
{
    public class LevelLoadingServiceInstaller : Installer<LevelLoadingServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            this.Error();
            Container.Bind<LevelLoadingService>().AsSingle();
        }

        #endregion
    }
}