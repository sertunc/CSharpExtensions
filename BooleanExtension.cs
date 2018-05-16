public static class BooleanExtension
{
	/// <summary>
	/// C# Boolean değeri javascript boolean değerine çeviren metod.
	/// </summary>
	/// <param name="value"></param>
	/// <returns></returns>
	public static string ToJavascript(this bool value)
		=> value ? "true" : "false";
 
	/// <summary>
    /// 
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool Not(this bool value)
    {
        return value != true;
    }
 
    /// <summary>
    /// Converts the value of this instance to its equivalent string representation (either "Yes" or "No").
    /// </summary>
    /// <param name="boolean"></param>
    /// <returns>string</returns>
    public static string ToYesNo(this bool boolean)
    {
        return boolean ? "Yes" : "No";
    }
 
    /// <summary>
    /// Converts the value in number format {1 , 0}.
    /// </summary>
    /// <param name="boolean"></param>
    /// <returns>int</returns>
    /// <example>
    /// 	<code>
    /// 		int result= default(bool).ToBinaryTypeNumber()
    /// 	</code>
    /// </example>
    public static int ToBinaryTypeNumber(this Boolean boolean)
    {
        return boolean ? 1 : 0;
    }
}
