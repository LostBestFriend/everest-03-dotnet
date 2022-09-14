namespace Customer.DomainModels.Formatters
{
    public static class StringExtensions
    {
        public static string Formatter(this string str)
        {
            return str.Trim().Replace(".", "").Replace("-", "");
        }
    }
}
