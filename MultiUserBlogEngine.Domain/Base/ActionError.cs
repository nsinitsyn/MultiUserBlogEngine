namespace MultiUserBlogEngine.Domain.Base;

readonly struct ActionError
{
    public ActionError(string error) => Error = error;

    public string Error { get; }
}
