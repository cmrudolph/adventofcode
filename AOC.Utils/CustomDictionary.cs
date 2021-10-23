using System;
using System.Collections.Generic;

namespace AOC.Utils
{
    public sealed class CustomDictionary<TKey, TValue>
    {
        private readonly TValue _defaultValue;
        private readonly Dictionary<TKey, TValue> _dict = new();

        public CustomDictionary(TValue defaultValue)
        {
            _defaultValue = defaultValue;
        }

        public void Set(TKey key, TValue value)
        {
            _dict[key] = value;
        }

        public TValue Get(TKey key)
        {
            return _dict.TryGetValue(key, out TValue existing) ? existing : _defaultValue;
        }

        public void Transform(TKey key, Func<TValue, TValue> transformer)
        {
            TValue existing = Get(key);
            TValue transformed = transformer(existing);
            Set(key, transformed);
        }
    }
}
