namespace Base.Game.UI
{
    using Base.Game.Signal;
    public class TxtScore : BaseText
    {
        [Signal(typeof(SignalScoreChanged), typeof(int))]
        public void OnScoreChanged(int score)
        {
            _txt.text = score.ToString();
        }
    }
}
