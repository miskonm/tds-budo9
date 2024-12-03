using TDS.Common.UI.Game;
using TDS.Game;
using TDS.Game.Common;
using TDS.Service.Input;
using TDS.Service.LevelCompletion;
using TDS.Service.Mission;
using TDS.Utils.Log;
using UnityEngine;
using Object = UnityEngine.Object;

namespace TDS.Infrastructure.State
{
    public class GameState : AppState
    {
        #region Variables

        private readonly GameScreenController _gameScreenController;

        private readonly IInputService _inputService;

        private readonly LevelCompletionService _levelCompletionService;
        private readonly MissionService _missionService;

        #endregion

        #region Setup/Teardown

        public GameState(LevelCompletionService levelCompletionService, MissionService missionService,
            IInputService inputService, GameScreenController gameScreenController)
        {
            _levelCompletionService = levelCompletionService;
            _missionService = missionService;
            _inputService = inputService;
            _gameScreenController = gameScreenController;
        }

        #endregion

        #region Public methods

        public override void Enter()
        {
            this.Log();

            _levelCompletionService.Initialize();
            _missionService.Initialize();
            _missionService.Begin();

            PlayerMovement playerMovement = Object.FindObjectOfType<PlayerMovement>();
            UnitHp playerHp = playerMovement.GetComponent<UnitHp>();
            _gameScreenController.OpenScreen(playerHp);

            _inputService.Initialize(Camera.main, playerMovement.transform);
        }

        public override void Exit()
        {
            _missionService.Dispose();
            _levelCompletionService.Dispose();
            _inputService.Dispose();
            _gameScreenController.CloseScreen();
        }

        #endregion
    }
}