using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordChecker.Classes
{
    internal class Checker
    {
        private const int minLength = 8,
            maxLength=25;

        private char[] alphabetUpper = Enumerable.Range('A', 'Z' - 'A' + 1).Select(symb => (char)symb).ToArray();
        private char[] alphabetLower = Enumerable.Range('a', 'z' - 'a' + 1).Select(symb => (char)symb).ToArray();
        private char[] correctSymbols = {'_', '-', '.'};

        public string Check(string input)
        {
            string result=string.Empty;

            if (string.IsNullOrEmpty(input))
                return "Поле не заполнено\n";

            if (!IsContainUpperSymbol(input))
                result += "Пароль не содержит символов верхнего регистра.\n";

            if (!IsContainLowerSymbol(input))
                result += "Пароль не содержит символов нижнего регистра.\n";

            if (!IsCorrectLength(input))
                result += $"Длина пароля должна быть в промежутке от {minLength} до {maxLength} символов.\n";

            if (!IsCorrectSymbols(input))
                result += "Пароль должен состоять только из цифр, букв латинского алфавита, нижнего подчеркивания, тире, точки.\n";

            if (!IsCorrectOutsideSymbols(input))
                result += "В начале и в конце пароля должны находиться латинские символы.\n";

            if (string.IsNullOrEmpty(result))
                result += "Пароль подобран корректно";

            return result;
        }

        private bool IsContainUpperSymbol(string input)
        {
            foreach (var x in input)
                if(char.IsUpper(x))
                    return true;

            return false;
        }

        private bool IsContainLowerSymbol(string input)
        {
            foreach (var x in input)
                if (char.IsLower(x))
                    return true;
            
            return false;
        }

        private bool IsCorrectLength(string input)
        { 
            if(input.Length>=minLength &&
                input.Length<=maxLength)
                return true; 
            
            return false;
        }

        private bool IsCorrectSymbols(string input)
        {
            foreach (var x in input)
                if (char.IsNumber(x) ||
                    alphabetUpper.Contains(x) ||
                    alphabetLower.Contains(x) ||
                    correctSymbols.Contains(x))
                    continue;
                else
                    return false;

            return true;
        }

        private bool IsCorrectOutsideSymbols(string input)
        {
            if (!(alphabetLower.Contains(input[0]) || alphabetUpper.Contains(input[0])))
                return false;

            if (!(alphabetLower.Contains(input[input.Length - 1]) || alphabetUpper.Contains(input[input.Length - 1])))
                return false;

            return true;
        }
    }
}
