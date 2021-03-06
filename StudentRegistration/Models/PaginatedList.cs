using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRegistration.Models
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; set; }
        public PaginatedList(List<T> items,int count,int pageIndex,int pageSize)
        {
           PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);

        }
        public bool PreviousPage
        {
            get { return (PageIndex > 1); }
        }
        public bool NextPage
        {
            get { return (PageIndex < TotalPages); }
        }
        public static PaginatedList<T> Create(IQueryable<T> src,int pageIndex,int pazeSize)
        {
            var count = src.Count();
            var items = src.Skip((pageIndex - 1) * pazeSize).Take(pazeSize).ToList();
            return new PaginatedList<T>(items, count, pageIndex, pazeSize);
        }
    }
}
