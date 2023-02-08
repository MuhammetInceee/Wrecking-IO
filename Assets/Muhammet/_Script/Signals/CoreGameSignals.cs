using System;
using UnityEngine;

namespace WreckingOI.Signals
{
    public static class CoreGameSignals
    {
        public static Action OnLevelCheck;
        public static Action<GameObject> OnDeath;
    }
}
