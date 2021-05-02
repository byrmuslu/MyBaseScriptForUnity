namespace Base.Util
{
    public class Util
    {
        public static Util Instance { get; private set; } = new Util();
        private Util() { }
    }
}