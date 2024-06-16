using Contracts.Web.Exceptions;
using Contracts.Web.Http.Category.Requests;
using Contracts.Web.Http.Category.Responses;
using Contracts.Web.Http.Common;
using Contracts.Web.Http.Receipt.Requests;
using Contracts.Web.Http.Receipt.Responses;
using Microsoft.Extensions.Logging;

namespace Contracts.Web.Http.Client.QueryHandler
{
    public class QueryHandlerClient(HttpClient httpClient, ILogger logger) : BaseClient(httpClient), IQueryHandlerClient
    {
        private readonly ILogger _logger = logger;

        public async Task<PagedResult<CategoryResponse>> GetCategoriesAsync(GetCategoriesRequest categoriesRequest)
        {
            var category = await GetAsync<PagedResult<CategoryResponse>, GetCategoriesRequest>("getCategories", categoriesRequest)
                .HandleExceptions("GetCategories");

            if (category.TotalResults == 0 || categoriesRequest.CategoryIds == null)
            {
                throw new BadRequestException($"Invalid categoryId provided, the category does not exists {category}");
            }

            return category;
        }

        public async Task<PagedResult<GetVariableReceiptResponse>> GetVariableReceiptsAsync(GetVariableReceiptsRequest variableReceiptsRequest)
        {
            var receipt = await GetAsync<PagedResult<GetVariableReceiptResponse>, GetVariableReceiptsRequest>("getVariableReceipts", variableReceiptsRequest)
                .HandleExceptions("GetReceipt");
            
            return receipt;
        }

        public async Task<PagedResult<GetRecurringReceiptResponse>> GetRecurringReceiptsAsync(GetRecurringReceiptsRequest recurringReceiptsRequest)
        {
            var receipt = await GetAsync<PagedResult<GetRecurringReceiptResponse>, GetRecurringReceiptsRequest>("getRecurringReceipts", recurringReceiptsRequest)
                .HandleExceptions("GetRecurringReceipt");

            return receipt;
        }
    }
}
