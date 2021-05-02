namespace Base.Game.UI
{
    using Base.Game.Signal;
    public class BasePanel : MyUI
    {
        [Signal(typeof(SignalGameOver), typeof(bool))]
        public void OnGameOver(bool isWon)
        {
            if (isWon)
            {
                if (this is PanelWin)
                    Activate();
                else
                    Deactivate();
            }
            else
            {
                if (this is PanelLose)
                    Activate();
                else
                    Deactivate();
            }
        }
        [Signal(typeof(SignalStartGame))]
        public void OnStartGame()
        {
            if (this is PanelInGame)
                Activate();
            else
                Deactivate();
        }
        [Signal(typeof(SignalRestartGame))]
        public void OnRestartGame()
        {
            if (this is PanelInGame)
                Activate();
            else
                Deactivate();
        }
    }
}
