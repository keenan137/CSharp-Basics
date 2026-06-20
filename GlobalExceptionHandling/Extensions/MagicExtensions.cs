using GlobalExceptionHandling.NewWay;

namespace GlobalExceptionHandling.Extensions
{
    public static class MagicExtensions
    {
        public static void AddExceptionHandlers(this IServiceCollection services)
        {
            services.AddExceptionHandler<ProductNotFoundExceptionHandler>();
            services.AddExceptionHandler<GlobalExceptionHandler>();
            services.AddProblemDetails();
        }
    }
}
