using System.ComponentModel;
using System.Reflection;

namespace Models.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            if (value == null) return string.Empty;

            FieldInfo? field = value.GetType().GetField(value.ToString());

            if (field == null) return string.Empty;

            object[] attribs = field.GetCustomAttributes(typeof(DescriptionAttribute), true);

            if (attribs.Length > 0)
            {
                return ((DescriptionAttribute)attribs[0]).Description;
            }

            return string.Empty;
        }
    }
}
