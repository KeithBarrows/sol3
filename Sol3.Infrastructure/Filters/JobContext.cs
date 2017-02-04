using System;
using Hangfire.Server;

namespace Sol3.Infrastructure.Filters
{
    /// <summary>
    /// Class JobContext.
    /// </summary>
    /// <seealso cref="Hangfire.Server.IServerFilter" />
    public class JobContext : IServerFilter
    {
        /// <summary>
        /// The job identifier
        /// </summary>
        [ThreadStatic]
        private static string _jobId;

        /// <summary>
        /// Gets or sets the job identifier.
        /// </summary>
        /// <value>The job identifier.</value>
        public static string JobId { get { return _jobId; } set { _jobId = value; } }

        /// <summary>
        /// Called when [performing].
        /// </summary>
        /// <param name="context">The context.</param>
        public void OnPerforming(PerformingContext context)
        {
            JobId = context.BackgroundJob.Id;
        }

        /// <summary>
        /// Called after the performance of the job.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnPerformed(PerformedContext filterContext)
        {
            //TODO: Fix OnPerformed(PerformedContext filterContext) method...
            if (filterContext.Canceled) { }
            if (filterContext.ExceptionHandled) { }
            if (filterContext.Exception != null && !filterContext.ExceptionHandled)
            {
                Serilog.Log.Logger.Error(filterContext.Exception, "The error was not handled!");
            }
        }
    }
}
