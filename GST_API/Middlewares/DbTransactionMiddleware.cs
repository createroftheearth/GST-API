using GST_API.Controllers;
using GST_API_DAL;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace GST_API.Middlewares
{
    public class DbTransactionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<DbTransactionMiddleware> _logger;

        public DbTransactionMiddleware(RequestDelegate next, ILogger<DbTransactionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext, ApplicationDbContext dbContext)
        {
            // For HTTP GET opening transaction is not required
            if (httpContext.Request.Method.Equals("GET", StringComparison.CurrentCultureIgnoreCase))
            {
                await _next(httpContext);
                return;
            }

            if (await dbContext.Database.CanConnectAsync())
            {

                // If action is not decorated with TransactionAttribute then skip opening transaction
                var executionStrategy = dbContext.Database.CreateExecutionStrategy();
                await executionStrategy.ExecuteAsync(async () =>
                {
                    await using var transaction = await dbContext.Database.BeginTransactionAsync();
                    try
                    {

                        await _next(httpContext);

                        await transaction.CommitAsync();
                    }
                    catch (Exception ex)
                    {
                        if (transaction != null)
                        {
                            await transaction.RollbackAsync();
                            _logger.LogError("Transaction rolled back due to an error: {Message}", ex.Message);
                        }
                        throw;
                    }
                    finally
                    {
                        if (transaction != null)
                        {
                            await transaction.DisposeAsync();
                            _logger.LogDebug("Transaction disposed.");
                        }
                    }
                });
            }
            else
            {
                await _next(httpContext);
            }

        }
    }
}
