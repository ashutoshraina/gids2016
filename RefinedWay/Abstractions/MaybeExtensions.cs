namespace RefinedWay
{

    public static class MaybeExtensions
    {
        public static IMaybe<T> ToMaybe<T>(this T value)
        {
            if (value == null)
                return new None<T>();

            return new Just<T>(value);
        }
    }
}
