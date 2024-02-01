using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Class_Model_Validation.Core.Validation.CoreDataAnnotations;

namespace Class_Model_Validation.Models
{
    public class ExampleModels
    {
        [Required(ErrorMessage = "Adın girilmesi gerekli!")]
        [StringLength(50,ErrorMessage ="Tanım elli karakterden uzun olamaz!")]
        public string Name { get; set; }
        [TurkishPhoneNumber(ErrorMessage = "Telefon Numarası yanlış girilmiş!")]
        public string PhoneNumber { get; set; }
    }

    public class Product
    {
        [Range(1, 100)]
        public int Quantity { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }

    public class Customer
    {
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$")]
        public string Name { get; set; }
    }
    public class Contact
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
