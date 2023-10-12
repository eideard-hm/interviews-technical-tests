namespace UserManagement.Api.Errors
{
    public class GraphQLErrorFilter : IErrorFilter
    {
        public IError OnError(IError error)
        {
            return error.WithMessage(error?.Exception?.Message ?? "Unexpected Execution Error");
        }
    }
}
