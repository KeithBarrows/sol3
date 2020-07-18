namespace Sol3.Infrastructure.Extensions
{
    public static class BoolExtensions
    {
        public static int ToInt(this bool src) => src ? 1 : 0;
        public static int ToInt(this bool? src) => src?.ToInt() ?? 0;
    }
}
