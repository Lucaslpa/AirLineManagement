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
        public static bool IsValid( string phone )
        {
            Regex regex = MyRegex();
            return regex.IsMatch( phone );
        }

        private static Regex MyRegex()
        {
            // Aceita padrões como: (XX) 1234-5678 ou (XX) 91234-5678 ou XX 1234-5678 ou XX 91234-5678
            return MyRegex1();
        }

        [GeneratedRegex( @"^(\(\d{2}\)|\d{2})\s?\d{4,5}-\d{4}$" )]
        private static partial Regex MyRegex1();
    }
}
