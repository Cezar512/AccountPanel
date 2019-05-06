namespace L2AccountPanel.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool Empty(this string value)
            => string.IsNullOrWhiteSpace(value);
    }
}