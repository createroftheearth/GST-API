using GST_API_DAL;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace GST_API.Middlewares
{
    public class DbTransactionMiddleware
    {
        private readonly RequestDelegate _next;

        public DbTransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ApplicationDbContext dbContext)
        {
            // For HTTP GET opening transaction is not required
            if (httpContext.Request.Method.Equals("GET", StringComparison.CurrentCultureIgnoreCase))
            {
                await _next(httpContext);
                return;
            }

            // If action is not decorated with TransactionAttribute then skip opening transaction
            var endpoint = httpContext.Features.Get<IEndpointFeature>()?.Endpoint;
            IDbContextTransaction transaction = null;
            var executionStrategy = dbContext.Database.CreateExecutionStrategy();
            await executionStrategy.ExecuteAsync(async () => {
                try
                {
                    transaction = await dbContext.Database.BeginTransactionAsync();

                    await _next(httpContext);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    if (transaction != null)
                        await transaction.RollbackAsync();

                    throw;
                }
                finally
                {
                    if (transaction != null)
                        await transaction.DisposeAsync();
                }
            });
        }
    }
}
