namespace MultiUserBlogEngine.Domain.Base;

internal abstract class ActionBase<TParameter>
{
    private List<ActionError> _errors = new(3);

    protected abstract void InvokeCore(TParameter parameter);

    protected bool HasErrors => _errors.Count > 0;

    protected void AddError(ActionError error) => _errors.Add(error);

    public ActionResult Invoke(TParameter parameter)
    {
        InvokeCore(parameter);

        return !HasErrors ? ActionResult.SuccessResult : new ActionResult(_errors);
    }
}
