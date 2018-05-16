public static class IEnumerableExtension
{
    public static String Join(this IEnumerable<String> values, String separator)
        => string.Join(separator, values);
 
    /// <summary>
    /// <see cref="IEnumerable{T}"/> türündeki veri kümesini <paramref name="splitCount"/> parametresinde belirttiğiniz 
    /// değere göre parçalara ayırmak için kullanabilirsiniz.
    /// </summary>
    /// <typeparam name="T">Veri kümesinin her bir türü.</typeparam>
    /// <param name="values">Veri kümesi.</param>
    /// <param name="splitCount"><paramref name="values"/> veri kümesinin parçalanacağı sayıyı belirtmelisiniz.</param>
    /// <returns></returns>
    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> values, int splitCount)
    {
        var count = values.Count() / splitCount;
        var remainingCount = values.Count() % splitCount;
 
        for (int i = 0; i < count; i++)
            yield return values.Skip(i * splitCount).Take(splitCount);
 
        yield return values.Skip(count * splitCount).Take(remainingCount);
    } 
}
