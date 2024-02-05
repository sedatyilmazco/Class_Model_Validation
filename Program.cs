using Class_Model_Validation.Models;
using Class_Model_Validation.Core.CoreValidation;
using Class_Model_Validation.Core.CoreExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Model_Validation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Personel modeli kontrol ediliyor...");

            Personal model = new Personal
            {
                Name = "TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest",
                PhoneNumber = "1234567890",
            };
            
            ReturnModel data = model.Validate().ToReturnModel();
            if (!data.Result)
            {
                Console.WriteLine("Personel validasyondan geçemedi!");
                Console.WriteLine(data.ErrorMessage);
                Console.ReadLine();
                Environment.Exit(0);
            }
            Console.WriteLine("Personel validasyondan geçti!");
            Console.ReadLine();
        }
    }
}
