using UnityEngine;
using Zenject;

namespace TDS.Service.Input
{
    public class InputServiceInstaller : Installer<InputServiceInstaller>
    {
        #region Public methods

        public override void InstallBindings()
        {
            if (Application.isEditor || !Application.isMobilePlatform)
            {
                Container.Bind<IInputService>().To<PCInputService>().FromNewComponentOnNewGameObject().AsSingle();
            }
            else
            {
                Container.Bind<IInputService>().To<MobileInputService>().AsSingle();
            }
        }

        #endregion
    }
}