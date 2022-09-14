namespace CustomerCrudApi
{
    public static class StringFormatter
    {
        public static string Formatter(this string str)
        {
            return str.Trim().Replace(".", "").Replace("-", "");
        }
    }
}
