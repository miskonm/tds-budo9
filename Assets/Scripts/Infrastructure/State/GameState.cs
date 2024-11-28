using TDS.Game;
using TDS.Game.Common;
using TDS.Service.Input;
using TDS.Service.LevelCompletion;
using TDS.Service.Mission;
using TDS.UI;
using TDS.Utils.Log;
using UnityEngine;

namespace TDS.Infrastructure.State
{
    public class GameState : AppState
    {
        #region Public methods

        public override void Enter()
        {
            this.Log();
            ServicesLocator.Get<LevelCompletionService>().Initialize();
            ServicesLocator.Get<MissionService>().Initialize();
            ServicesLocator.Get<MissionService>().Begin();
            
            GameScreen gameScreen = Object.FindObjectOfType<GameScreen>();
            PlayerMovement playerMovement = Object.FindObjectOfType<PlayerMovement>();
            UnitHp playerHp = playerMovement.GetComponent<UnitHp>();
            gameScreen.PlayerHpBar.Construct(playerHp);

            IInputService inputService = ServicesLocator.Get<IInputService>();
            inputService.Initialize(Camera.main, playerMovement.transform);

            playerMovement.Construct(inputService);
            playerMovement.GetComponent<PlayerAttack>().Construct(inputService);
        }

        public override void Exit()
        {
            ServicesLocator.Get<MissionService>().Dispose();
            ServicesLocator.Get<LevelCompletionService>().Dispose();
            ServicesLocator.Get<IInputService>().Dispose();
        }

        #endregion
    }
}