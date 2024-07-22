﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Abstract
{
    public interface IBooksStocksService
    {
        bool Add(BooksStocks booksStocks);

        BooksStocks GetByBooksId(int bookId);
    }
}
