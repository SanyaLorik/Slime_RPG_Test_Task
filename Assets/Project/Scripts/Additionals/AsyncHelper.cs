namespace SlimeRPG.Additionals
{
    public static class AsyncHelper
    {
        public static int Millisecond(this float value)
        {
            return (int)(value * 1000);
        }
    }
}
