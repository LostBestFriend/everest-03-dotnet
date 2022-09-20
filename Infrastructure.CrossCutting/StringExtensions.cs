namespace Infrastructure.CrossCutting
{
    public static class StringExtensions
    {
        public static string FormatCpf(this string str)
        {
            return str.Trim().Replace(".", "").Replace("-", "");
        }
    }
}
