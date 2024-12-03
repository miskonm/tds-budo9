using Zenject;

namespace TDS.Service.UI
{
    public class UIServiceInstaller : Installer<UIServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            Container
                .Bind<UIService>()
                .FromSubContainerResolve()
                .ByMethod(InstallService)
                .AsSingle();
        }

        #endregion

        #region Private methods

        private void InstallService(DiContainer subContainer)
        {
            subContainer.Bind<UIService>().AsSingle();
            subContainer.Bind<UILayersController>().AsSingle().WithArguments(Container.DefaultParent);
            subContainer.Bind<UIScreenProvider>().AsSingle();
        }

        #endregion
    }
}