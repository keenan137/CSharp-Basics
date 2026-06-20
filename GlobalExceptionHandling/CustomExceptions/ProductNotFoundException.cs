using System.Net;

namespace GlobalExceptionHandling.CustomExceptions
{
    public class ProductNotFoundException : BaseException
    {
        public ProductNotFoundException(Guid id) : base($"Product with ID {id} not found.", HttpStatusCode.NotFound)
        {
        }
    }
}
