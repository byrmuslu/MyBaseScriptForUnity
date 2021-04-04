using System;
using System.Collections.Generic;

namespace Base.Game.Signal
{
    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class SignalAttribute : System.Attribute
    {
        public string Tag { get; set; }
        public Type[] Params { get; set; }

        public SignalAttribute(string tag, params Type[] prms)
        {
            Tag = tag;
            Params = prms;
        }
    }
}
