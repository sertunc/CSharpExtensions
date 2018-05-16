using System;
using System.ComponentModel;
 
public static class EnumExt {
 
    /// <summary>
    /// Enum değerini belirttiğiniz türde alabilirsiniz.
    /// </summary>
    /// <typeparam name="T">
    /// Enum value'sunu hangi türde almak istiyorsanız o türü belirtmelisiniz.
    /// </typeparam>
    /// <example>
    /// var code = HttpStatusCode.Accepted.GetValue<int>()
    /// </example>
    /// <param name="enumVal"></param>
    /// <returns></returns>
    public static T GetValue<T>(this Enum enumVal)
        => (T)Convert.ChangeType(enumVal, typeof(T));
 
    /// <summary>
    /// Enum elemanının değerini <see cref="int"/> tipinde alabilirsiniz.
    /// </summary>
    /// <param name="enumVal">Enum türü</param>
    /// <returns>Geriye <see cref="int"/> tipinde bir sayı döner.</returns>
    public static int GetInt( this Enum enumVal )
        => enumVal.GetValue<int>();
 
    /// <summary>
    /// Enum elemanının değerini <see cref="short"/> tipinde alabilirsiniz.
    /// </summary>
    /// <param name="enumVal">Enum türü</param>
    /// <returns>Geriye <see cref="short"/> tipinde bir sayı döner.</returns>
    public static short GetShort( this Enum enumVal ) 
        => enumVal.GetValue<short>();
        
    /// <summary>
    /// Enum elemanına tanımlanmış attribute varsa belirttiğiniz türe göre attribute'ü elde etmeyi sağlayabilirsiniz.
    /// </summary>
    /// <typeparam name="T">Enum elemanına tanımlanmış attribute türünü belirtiniz.</typeparam>
    /// <param name="enumVal">Enum türü</param>
    /// <returns>Eğer <see cref="T"/> türündeki attribute enum elemanında varsa <see cref="T"/> türü geri dönderilir.</returns>
    /// <example>string desc = myEnumVariable.GetAttributeOfType<DescriptionAttribute>().Description;</example>
    public static T GetAttributeOfType<T>( this Enum enumVal ) where T : System.Attribute {
        var type = enumVal.GetType();
        var memInfo = type.GetMember( enumVal.ToString() );
        var attributes = memInfo[0].GetCustomAttributes( typeof( T ), false );
        return ( attributes.Length > 0 ) ? (T)attributes[0] : null;
    }
 
    /// <summary>
    /// Enum elemanınızda <see cref="DescriptionAttribute"/> tanımlı ise bu attribut'un Description değeri geri dönderilir.
    /// </summary>
    /// <param name="value">Enum türü</param>
    /// <returns>Geriye <see cref="DescriptionAttribute"/> türünün Description özelliği değeri dönderilir.</returns>
    public static string GetDescription(this Enum value)
    {
        var desc = value.GetAttributeOfType<DescriptionAttribute>();
        if (desc != null)
            return desc.Description;
        return value.ToString();
    }
}
