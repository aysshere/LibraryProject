using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; } = 1;
        [Required(ErrorMessage = "İsim boş geçilemez")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Yazar boş geçilemez")]

        public string Author { get; set; }
        public string Publisher { get; set; }
        public int PageNumber { get; set; }
        public int StockNumber { get; set; }

        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Açıklama boş geçilemez")]

        public string Description { get; set; }
        public decimal Price { get; set; }

    }
}
