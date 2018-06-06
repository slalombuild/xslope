using System;
using ReactiveUI;

namespace XSlope.Core.Converters
{
    public abstract class BaseConverter<TFrom, TTo> : IBindingTypeConverter
    {
        protected abstract TTo Convert(TFrom fromValue);

        #region IBindingTypeConverter

        public int GetAffinityForObjects(Type fromType, Type toType)
        {
            return 100;
        }

        public bool TryConvert(object from, Type toType, object conversionHint, out object result)
        {
            result = Convert((TFrom)from);
            return true;
        }

        #endregion
    }
}
