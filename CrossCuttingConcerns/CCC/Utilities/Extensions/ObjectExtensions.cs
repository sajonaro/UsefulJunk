namespace Utilities.Extensions
{
    public static class ObjectExtensions
    {
        public static T As<T>(this object instance)
            where T : class
        {
            return instance as T;
        }

        public static bool Is<T>(this object instance)
            where T : class
        {
            return instance is T;
        }
    }
}
