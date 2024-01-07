using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Testes.domain.Validators
{
    public static partial class PhoneValidator
    {
        public static bool Validate( string phone )
        {

            string digitsOnly = new( phone.Where( char.IsDigit ).ToArray() );

            Regex regex = MyRegex();

            return regex.IsMatch( digitsOnly );


        }

        [GeneratedRegex( @"^(\d{2}|\(\d{2}\))\s?\d{9}$" )]
        private static partial Regex MyRegex();
    }
}
