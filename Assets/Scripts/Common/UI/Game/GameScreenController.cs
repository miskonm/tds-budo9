using TDS.Game.Common;
using TDS.Service.UI;

namespace TDS.Common.UI.Game
{
    public class GameScreenController
    {
        #region Variables

        private readonly UIService _uiService;

        private UIGameScreen _gameScreen;

        #endregion

        #region Setup/Teardown

        public GameScreenController(UIService uiService)
        {
            _uiService = uiService;
        }

        #endregion

        #region Public methods

        public void CloseScreen()
        {
            _uiService.CloseScreen(_gameScreen);
        }

        public void OpenScreen(UnitHp playerHp)
        {
            _gameScreen = _uiService.OpenScreen<UIGameScreen>();
            _gameScreen.PlayerHpBar.Construct(playerHp);
        }

        #endregion
    }
}