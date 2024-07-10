using Contracts.Web.Http.Category.Requests;
using Contracts.Web.Http.Category.Responses;
using Contracts.Web.Http.Common;
using Contracts.Web.Http.Receipt.Requests;
using Contracts.Web.Http.Receipt.Responses;

namespace Contracts.Web.Http.Client.QueryHandler
{
    public interface IQueryHandlerClient
    {
        Task<PagedResult<GetVariableReceiptResponse>> GetVariableReceiptsAsync(GetVariableReceiptsRequest variableReceiptsRequest);

        Task<PagedResult<CategoryResponse>> GetCategoriesAsync(GetCategoriesRequest categoriesRequest);

        Task<PagedResult<GetRecurringReceiptResponse>> GetRecurringReceiptsAsync(GetRecurringReceiptsRequest recurringReceiptsRequest);
    }
}
