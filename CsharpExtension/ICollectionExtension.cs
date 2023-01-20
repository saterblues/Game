using System.Collections.Generic;

namespace Game.CsharpExtension
{
    public static partial class ICollectionExtension
    {
        public static bool IsEmpty<T>(this ICollection<T> collection) {
            return collection.Count == 0;
        }
    }
}
