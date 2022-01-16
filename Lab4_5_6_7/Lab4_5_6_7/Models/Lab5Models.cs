using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Lab4_5_6_7.Models
{

    public class MinNumber : ValidationAttribute
    {
        private static int Min;

        public MinNumber(int min)
        {
            Min = min;
        }
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                if((int)value > Min)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class Validation
    {
        [Required(ErrorMessage = "Кількість має бути введена")]
        [MinNumber(0, ErrorMessage = "Кількість повинна бути більше нуля")]
        public int Count { get; set; }
        [Required(ErrorMessage = "Ім'я повинно бути введено")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Прізвище повинно бути введено")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "По батькові повинно бути введено")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Адреса повинна бути введена")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Номер має бути введений")]
        public string Phone { get; set; }
    }
}