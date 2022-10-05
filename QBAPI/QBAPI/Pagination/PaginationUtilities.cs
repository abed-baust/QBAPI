using System;
using System.Collections.Generic;
using System.Linq;

namespace CB.Utility.Pagination
{
    public static class PaginationUtilities
    {

        private static PaginationUtilitiesOptions _utilitiesOptions;

        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, IPagingOptions options)
        {
            if (options?.Limit == -1) return query;

            if (options != null && options.Limit != null && options.Offset != null)
            {
                if (_utilitiesOptions == null)
                {
                    _utilitiesOptions = PaginationUtilitiesOptions.DefaultOptions;
                }
                options.Offset = options.Offset ?? _utilitiesOptions.PagingOptions.Offset;
                options.Limit = options.Limit ?? _utilitiesOptions.PagingOptions.Limit;
                query = query.Skip(options.Offset.Value).Take(options.Limit.Value);
            }
            return query;
        }

        public static IEnumerable<T> ApplyPagination<T>(this IEnumerable<T> data, IPagingOptions options)
        {
            var result = Enumerable.Empty<T>();
            //var result = new List<T>();
            //var result = new List<T>().AsEnumerable();

            if (options != null && options.Limit != null && options.Offset != null)
            {
                if (_utilitiesOptions == null)
                {
                    _utilitiesOptions = PaginationUtilitiesOptions.DefaultOptions;
                }

                options.Offset = options.Offset ?? _utilitiesOptions.PagingOptions.Offset;
                options.Limit = options.Limit ?? _utilitiesOptions.PagingOptions.Limit;
                result = data.Skip(options.Offset.Value).Take(options.Limit.Value);
                return result;
            }
            return data;
        }

        public static void Configure(Action<PaginationUtilitiesOptions> options)
        {
            _utilitiesOptions = new PaginationUtilitiesOptions();
            options.Invoke(_utilitiesOptions);
        }


    }
}
