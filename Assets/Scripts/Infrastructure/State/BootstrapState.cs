using TDS.Service.LevelLoading;
using TDS.Service.UI;
using TDS.Utils.Log;

namespace TDS.Infrastructure.State
{
    public class BootstrapState : AppState
    {
        #region Variables

        private readonly LevelLoadingService _levelLoadingService;
        private readonly UIService _uiService;

        #endregion

        #region Setup/Teardown

        public BootstrapState(LevelLoadingService levelLoadingService, UIService uiService)
        {
            this.Error($"levelLoadingService '{levelLoadingService}'");
            _levelLoadingService = levelLoadingService;
            _uiService = uiService;
        }

        #endregion

        #region Public methods

        public override void Enter()
        {
            this.Error($"_levelLoadingService '{_levelLoadingService}'");

            _uiService.Initialize();
            _levelLoadingService.Initialize();
            
            
            _levelLoadingService.EnterFirstLevel();
        }

        public override void Exit() { }

        #endregion
    }
}