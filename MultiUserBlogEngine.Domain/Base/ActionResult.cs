using System.Collections.Immutable;

namespace MultiUserBlogEngine.Domain.Base;

readonly struct ActionResult
{
    public ActionResult() { }

    public ActionResult(List<ActionError> errors) => Errors = errors.ToImmutableList();

    public static ActionResult SuccessResult { get; } = new ActionResult();

    public bool Success { get; } = true;

    public ImmutableList<ActionError> Errors { get; } = ImmutableList<ActionError>.Empty;
}
