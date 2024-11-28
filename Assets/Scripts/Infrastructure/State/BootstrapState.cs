using TDS.Service.Coroutine;
using TDS.Service.Input;
using TDS.Service.LevelCompletion;
using TDS.Service.LevelLoading;
using TDS.Service.Mission;
using TDS.Utils.Log;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class BootstrapState : AppState
    {
        #region Variables

        private readonly LevelLoadingService _levelLoadingService;

        #endregion

        #region Setup/Teardown

        public BootstrapState(LevelLoadingService levelLoadingService)
        {
            this.Error($"levelLoadingService '{levelLoadingService}'");
            _levelLoadingService = levelLoadingService;
        }

        #endregion

        #region Public methods

        public override void Enter()
        {
            this.Error($"_levelLoadingService '{_levelLoadingService}'");

            MissionService missionService = ServicesLocator.RegisterMono<MissionService>();
            ServicesLocator.Register(new LevelCompletionService(missionService, _levelLoadingService));
            ServicesLocator.RegisterMono<CoroutineRunner>();

            if (Application.isEditor || !Application.isMobilePlatform)
            {
                ServicesLocator.RegisterMono<IInputService, PCInputService>();
            }
            else
            {
                ServicesLocator.Register<IInputService>(new MobileInputService());
            }

            _levelLoadingService.Initialize();
            _levelLoadingService.EnterFirstLevel();
        }

        public override void Exit() { }

        #endregion
    }
}