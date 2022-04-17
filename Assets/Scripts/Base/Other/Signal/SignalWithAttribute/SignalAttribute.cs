namespace Base.Other.Signal
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public class SignalAttribute : Attribute
    {
        public Type Tag { get; set; }
        public Type[] Params { get; set; }

        public SignalAttribute(Type tag, params Type[] prms)
        {
            Tag = tag;
            Params = prms;
        }
    }
}