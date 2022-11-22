using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Helpers
{
    public class PagedList<T> : List<T>
    {
        public PagedList( IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            CurrentPage = pageNumber;
            TotalPages = (int)  Math.Ceiling(count / (double) pageSize);
            PageSize = pageSize;
            TotalCount = count;

            AddRange(items);
        }

        public int  CurrentPage{ get;set; }
        public int  TotalPages{ get;set; }
        public int  PageSize{get;set;}
        public int  TotalCount{get;set;}

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize) 
        {
            Console.WriteLine("\n\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] >>> API.Helpers.PagedList-CreateAsync");
           
            Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] >>> API.Helpers.PagedList-CreateAsync-count");
            var count  = await source.CountAsync();                                                         //makes a db call.
           
            Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] >>> API.Helpers.PagedList-CreateAsync-readDB");
            var items  = await source.Skip( ( pageNumber -1 ) * pageSize).Take(pageSize).ToListAsync() ;    //makes a db call.
           
            Console.WriteLine("\n[" + DateTime.Now.ToString("hh:mm:ss.ffff") + "] >>>> API.Helpers.PagedList-CreateAsync- count: " + count.ToString() + " pageNumber: " + pageNumber.ToString() + "  pageSize: " + pageSize.ToString());
           
            return new PagedList<T>(items, count, pageNumber, pageSize) ;

        }
    }
}