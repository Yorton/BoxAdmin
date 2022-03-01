using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxAdmin.Framework.Exceptions
{
    public static class EnumerationExtensions
    {
        public static TSource Add<TSource>(this TSource source, TSource value) where TSource : struct, IConvertible
        {
            if (!typeof(TSource).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return (TSource)(object)(Convert.ToInt32(source) | Convert.ToInt32(value));
        }

        public static TSource Add1<TSource>(this TSource source, TSource value) where TSource : Enum
        {
            return (TSource)(object)(Convert.ToInt32(source) | Convert.ToInt32(value));
        }

        public static bool Has<TSource>(this TSource source, TSource value) where TSource : struct, IConvertible
        {
            if (!typeof(TSource).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return (Convert.ToInt32(source) & Convert.ToInt32(value)) == Convert.ToInt32(value);
        }

        public static bool Has1<TSource>(this TSource source, TSource value) where TSource : Enum
        {
            return (Convert.ToInt32(source) & Convert.ToInt32(value)) == Convert.ToInt32(value);
        }

        public static TSource Remove<TSource>(this TSource source, TSource value) where TSource : struct, IConvertible
        {
            if (!typeof(TSource).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return (TSource)(object)(Convert.ToInt32(source) & ~Convert.ToInt32(value));
        }

        public static TSource Remove1<TSource>(this TSource source, TSource value) where TSource : Enum
        {
            return (TSource)(object)(Convert.ToInt32(source) & ~Convert.ToInt32(value));
        }
    }
}
