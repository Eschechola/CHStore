namespace CHStore.Application.Core.ExtensionMethods
{
    public static class StringFilter
    {
        public static string FormatToSearchParammeter(this string param)
        {
            param = param.ToLower();
            param = param.TrimStart();
            param = param.TrimEnd();

            return param;
        }
    }
}
