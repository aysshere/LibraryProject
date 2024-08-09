using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.UnitOfWorks
{
    public interface IUniteOfWork : IDisposable
    {
        IBookRepository Book { get; }
        IBookRentDetailRepository BookRentDetail { get; }
        IBookRentRepository BookRent { get; }
        IBookStockRepository BookStock { get; }
        ICategoryRepository Category { get; }
        ICustomerRepository Customer { get; }
        ICustomerRentRepository CustomerRent { get; }
        void Save();
    }
}
