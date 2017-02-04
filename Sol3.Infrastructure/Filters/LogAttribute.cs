using Hangfire.Client;
using Hangfire.Common;
using Hangfire.Logging;
using Hangfire.Server;
using Hangfire.States;
using Hangfire.Storage;

namespace Sol3.Infrastructure.Filters
{
    /// <summary>
    /// Class LogAttribute.
    /// </summary>
    /// <seealso cref="Hangfire.Common.JobFilterAttribute" />
    /// <seealso cref="Hangfire.Client.IClientFilter" />
    /// <seealso cref="Hangfire.Server.IServerFilter" />
    /// <seealso cref="Hangfire.States.IElectStateFilter" />
    /// <seealso cref="Hangfire.States.IApplyStateFilter" />
    public class LogAttribute : JobFilterAttribute, IClientFilter, IServerFilter, IElectStateFilter, IApplyStateFilter
    {
        /// <summary>
        /// The logger
        /// </summary>
        private static readonly ILog Logger = LogProvider.GetCurrentClassLogger();

        /// <summary>
        /// Called when [creating].
        /// </summary>
        /// <param name="context">The context.</param>
        public void OnCreating(CreatingContext context) => Serilog.Log.Logger.Information("Creating a job based on method {JobMethodName}...", context.Job.Method.Name);
        /// <summary>
        /// Called when [created].
        /// </summary>
        /// <param name="context">The context.</param>
        public void OnCreated(CreatedContext context) => Serilog.Log.Logger.Information(
                "Job that is based on method `{JobMethodName}` has been created with id `{BackgroundJobId}`",
                context.Job.Method.Name,
                context.BackgroundJob?.Id);
        /// <summary>
        /// Called when [performing].
        /// </summary>
        /// <param name="context">The context.</param>
        public void OnPerforming(PerformingContext context) => Serilog.Log.Logger.Information("Starting to perform job `{BackgroundJobId}`", context.BackgroundJob.Id);
        /// <summary>
        /// Called when [performed].
        /// </summary>
        /// <param name="context">The context.</param>
        public void OnPerformed(PerformedContext context) => Serilog.Log.Logger.Information("Job `{BackgroundJobId}` has been performed", context.BackgroundJob.Id);
        /// <summary>
        /// Called when the current state of the job is being changed to the
        /// specified candidate state.
        /// This state change could be intercepted and the final state could
        /// be changed through setting the different state in the context
        /// in an implementation of this method.
        /// </summary>
        /// <param name="context">The context.</param>
        public void OnStateElection(ElectStateContext context)
        {
            var failedState = context.CandidateState as FailedState;
            if (failedState != null)
            {
                Serilog.Log.Logger.Warning("Job `{BackgroundJobId}` has been failed due to an exception `{Exception}`", context.BackgroundJob.Id, failedState.Exception);
            }
        }
        /// <summary>
        /// Called after the specified state was applied
        /// to the job within the given transaction.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="transaction">The transaction.</param>
        public void OnStateApplied(ApplyStateContext context, IWriteOnlyTransaction transaction) => Serilog.Log.Logger.Information(
                    "Job `{BackgroundJobId}` state was changed from `{OldStateName}` to `{NewStateName}`",
                    context.BackgroundJob.Id,
                    context.OldStateName,
                    context.NewState.Name);
        /// <summary>
        /// Called when the state with specified state was
        /// unapplied from the job within the given transaction.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="transaction">The transaction.</param>
        public void OnStateUnapplied(ApplyStateContext context, IWriteOnlyTransaction transaction) => Serilog.Log.Logger.Information(
                "Job `{BackgroundJobId}` state `{OldStateName}` was unapplied.",
                context.BackgroundJob.Id,
                context.OldStateName);
    }
}