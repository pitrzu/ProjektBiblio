namespace WSB.Biblioteka.Core.Extensions;

public static class EnumerableExtensions
{
    public static IEnumerable<T> SkipNulls<T>(this IEnumerable<T?> source) where T : class
        => source.Where(x => x is not null).Select(x => x!);

    public static IEnumerable<T> SkipNulls<T>(this IEnumerable<T?> source) where T : struct
        => source.Where(x => x.HasValue).Select(x => x!.Value);
    
    public static IEnumerable<T> Safe<T>(this IEnumerable<T>? source) => source ?? [];
    
    public static IReadOnlyCollection<T> AsReadOnlyCollection<T>(this IEnumerable<T> source) => source as IReadOnlyCollection<T> ?? source.ToArray();
    public static IReadOnlyCollection<T> AsSafeReadOnlyCollection<T>(this IEnumerable<T>? source) => source?.AsReadOnlyCollection() ?? [];
    public static IList<T> AsList<T>(this IEnumerable<T> source) => source as IList<T> ?? source.ToList();
    public static IList<T> AsSafeList<T>(this IEnumerable<T>? source) => source?.AsList() ?? [];
   
    public static T[] AsArray<T>(this IEnumerable<T> source) => source as T[] ?? source.ToArray();
    public static T[] AsSafeArray<T>(this IEnumerable<T>? source) => source?.AsArray() ?? [];
    
    public static ISet<T> AsSet<T>(this IEnumerable<T> source) => source as ISet<T> ?? source.ToHashSet();
    public static ISet<T> AsSafeSet<T>(this IEnumerable<T>? source) => source?.AsSet() ?? source.ToHashSet();
    
    public static IReadOnlyCollection<TResult> Project<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        => source.Select(selector).AsReadOnlyCollection();

    public static IReadOnlyCollection<TResult> SafeProject<TSource, TResult>(this IEnumerable<TSource>? source, Func<TSource, TResult> selector)
        => source.Safe().Project(selector);

    public static async Task<IReadOnlyCollection<TResult>> ProjectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, Task<TResult>> selector)
    {
        var results = new List<TResult>();
        foreach (var sourceItem in source)
            results.Add(await selector(sourceItem).ConfigureAwait(false));
        
        return results;
    }
    
    public static async Task<IReadOnlyCollection<TResult>> ProjectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, Task<TResult>> selector, CancellationToken cancellationToken = default)
    {
        var results = new List<TResult>();
        foreach (var sourceItem in source)
            results.Add(await selector(sourceItem, cancellationToken).ConfigureAwait(false));
        
        return results;
    }
    
    public static async Task<IReadOnlyCollection<TResult>> ProjectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, ValueTask<TResult>> selector)
    {
        var results = new List<TResult>();
        foreach (var sourceItem in source)
            results.Add(await selector(sourceItem).ConfigureAwait(false));
        
        return results;
    }
    
    public static async Task<IReadOnlyCollection<TResult>> ProjectAsync<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, CancellationToken, ValueTask<TResult>> selector, CancellationToken cancellationToken = default)
    {
        var results = new List<TResult>();
        foreach (var sourceItem in source)
            results.Add(await selector(sourceItem, cancellationToken).ConfigureAwait(false));
        
        return results;
    }
}
