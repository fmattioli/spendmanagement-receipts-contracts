using Contracts.Web.Http.Common;
using Flurl;
using System.Net.Http.Json;
using System.Text;

namespace Contracts.Web.Http.Client
{
    public class BaseClient(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        protected async Task<TResponse> GetAsync<TResponse, TRequest>(
            string path,
            TRequest request)
            where TResponse : class
            where TRequest : class
        {
            var queryParams = BuildFilters(request);

            var url = _httpClient.BaseAddress
                .AppendPathSegment(path)
                .AppendQueryParam(queryParams);

            var result = await _httpClient.GetFromJsonAsync<TResponse>(url);
            return result!;
        }

        private static IEnumerable<string> BuildFilters<T>(T queryFilters) where T : class
        {
            return queryFilters
                .GetType()
                .GetProperties()
                .Select(
                    propertyValue =>
                    {
                        var builder = new StringBuilder();
                        var value = propertyValue.GetValue(queryFilters);

                        if (value is PageFilterRequest pageFilter)
                        {
                            builder.Append($"&PageFilter.PageSize={pageFilter.PageSize}");
                        }

                        if (value is IEnumerable<Guid> enumerableGuid)
                        {
                            builder.AppendJoin("&", enumerableGuid.Select(item => $"{propertyValue.Name}=" + item.ToString()));
                        }

                        if (value is IEnumerable<string> enumerableString)
                        {
                            builder.AppendJoin("&", enumerableString.Select(item => $"{propertyValue.Name}=" + item));
                        }

                        if (value is DateTime dateTime && dateTime != DateTime.MinValue)
                        {
                            builder
                            .Append(propertyValue.Name)
                            .Append('=')
                            .Append(dateTime.Year)
                            .Append('-')
                            .Append(dateTime.Month)
                            .Append('-')
                            .Append(dateTime.Day);
                        }


                        return builder.ToString();
                    });
        }
    }
}
