using System;

namespace Utilities.Extensions
{
	/// <summary>
	/// Maybe monads
	/// http://www.codeproject.com/Articles/109026/Chained-null-checks-and-the-Maybe-monad
	/// </summary>
    public static class Monads
    {
        public static TResult With<TSource, TResult>(this TSource source, Func<TSource, TResult> evaluator)
			where TSource : class
		{
	        return source == default(TSource) ? default(TResult) : evaluator(source);
        }

	    public static TSource Do<TSource>(this TSource source, Action<TSource> action)
			where TSource : class
        {
            if (source != default(TSource))
                action(source);

            return source;
        }

        public static TSource If<TSource>(this TSource source, Predicate<TSource> evaluator)
			where TSource : class
        {
            if (source != default(TSource) && evaluator(source))
                return source;

            return default(TSource);
        }

        public static TResult Return<TSource, TResult>(this TSource source, Func<TSource, TResult> evaluator, TResult failureValue)
			where TSource : class
		{
	        return source == default(TSource) ? failureValue : evaluator(source);
        }

	    public static bool ReturnSuccess<TSource>(this TSource source)
			where TSource: class 
        {
            return source != null;
        }

        public static TResult IfNotNull<TSource, TResult>(this TSource source, Func<TSource, TResult> evaluator)
			where TSource : class
        {
            return source.If(src => src.ReturnSuccess()).With(evaluator);
        }

        public static TSource IfNotNull<TSource>(this TSource source, Action<TSource> evaluator)
			where TSource : class
        {
            return source.If(src => src.ReturnSuccess()).Do(evaluator);
        }

        public static TResult IfNull<TSource, TResult>(this TSource source, Func<TSource, TResult> evaluator)
			where TSource : class
        {
            return source.If(src => !src.ReturnSuccess()).With(evaluator);
        }

        public static TSource IfNull<TSource>(this TSource source, Action<TSource> evaluator)
			where TSource : class
        {
            return source.If(src => !src.ReturnSuccess()).Do(evaluator);
        }
    }
}
