using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Extensions
{
    public static class Pagination
    {
        public static async Task<PagedResult<T>> GetPagination<T>(this IQueryable<T> query, int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.PageIndex = page;
            result.PageSize = pageSize;
            result.TotalResults = query.Count();
            if (pageSize == 0)
            {
                result.List = await query.AsNoTracking().ToListAsync();
                result.TotalPages = 1;
            }
            else
            {
                var pageCount = (double)result.TotalResults / pageSize;
                result.TotalPages = (int)Math.Ceiling(pageCount);
                var skip = (page - 1) * pageSize;
                result.List = await query.Skip(skip).Take(pageSize).ToListAsync();
            }
            return result;
        }
    }
    public class PagedResult<T> where T : class
    {
        public IEnumerable<T> List { get; set; }
        public int TotalResults { get; set; }
        public int TotalPages { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Query { get; set; }
    }
}
