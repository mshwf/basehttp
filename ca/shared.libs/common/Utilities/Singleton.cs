using System;

namespace GET.PKI.Common.Utilities
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        static readonly Lazy<T> _lazy = new Lazy<T>(() => new T());
        public static T Instance => _lazy.Value;
    }
}