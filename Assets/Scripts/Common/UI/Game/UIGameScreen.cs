using TDS.Game.UI;
using TDS.Service.UI;
using UnityEngine;

namespace TDS.Common.UI.Game
{
    public class UIGameScreen : UIScreen
    {
        #region Variables

        [SerializeField] private HpBar _playerHpBar;

        #endregion

        #region Properties

        public HpBar PlayerHpBar => _playerHpBar;

        #endregion
    }
}