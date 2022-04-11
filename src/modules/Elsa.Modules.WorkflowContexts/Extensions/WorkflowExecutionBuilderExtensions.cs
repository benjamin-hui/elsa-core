using Elsa.Contracts;
using Elsa.Modules.WorkflowContexts.Middleware;
using Elsa.Pipelines.ActivityExecution;
using Elsa.Pipelines.WorkflowExecution;

namespace Elsa.Modules.WorkflowContexts.Extensions;

public static class WorkflowExecutionBuilderExtensions
{
    /// <summary>
    /// Installs middleware that enables the use of workflow context.
    /// </summary>
    public static IWorkflowExecutionBuilder UseWorkflowContexts(this IWorkflowExecutionBuilder builder) => builder.UseMiddleware<WorkflowContextWorkflowExecutionMiddleware>();
    
    /// <summary>
    /// Installs middleware that enables the use of workflow context.
    /// </summary>
    public static IActivityExecutionBuilder UseWorkflowContexts(this IActivityExecutionBuilder builder) => builder.UseMiddleware<WorkflowContextActivityExecutionMiddleware>();
}