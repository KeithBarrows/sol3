namespace Sol3.Infrastructure.Hangfire
{
    public enum ChannelName
    {
        /// <summary>
        /// Critical channel
        /// </summary>
        Critical = 0,
        /// <summary>
        /// Serial channel
        /// </summary>
        Serial = 1,
        /// <summary>
        /// Job queue channel
        /// </summary>
        JobQueue = 2,
        /// <summary>
        /// Ad hoc channel
        /// </summary>
        AdHoc = 3,
        /// <summary>
        /// Default channel
        /// </summary>
        Default = 4
    }

}
