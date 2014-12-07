using System;
using System.Linq;
using LF.MVC.Helpers.Extensions;

namespace LF.MVC.Helpers.Models
{
    public class Validator
    {
        private static readonly Int16[] cnpjMultipliers = {2, 3, 4, 5, 6, 7, 8, 9, 2, 3, 4, 5, 6};
        private static readonly Int16[] cpfMultipliers = {2, 3, 4, 5, 6, 7, 8, 9, 10, 11};

        public static Boolean CNPJ(String document)
        {
            return brazilDocument(document, cnpjMultipliers);
        }

        public static Boolean CPF(String document)
        {
            return brazilDocument(document, cpfMultipliers);
        }

        private static Boolean brazilDocument(String document, Int16[] multipliers)
        {
            if (document == null)
                return false;

            document = document.JustNumbers();

            if (document == String.Empty)
                return false;

            var numbers = Int64.Parse(document);

            var verifier = numbers%100;
            var toVerify = numbers/100;

            var digit1 = calculateDigit(toVerify, multipliers);
            toVerify = toVerify*10 + digit1;

            var digit2 = calculateDigit(toVerify, multipliers);

            return verifier == digit1*10 + digit2;
        }



        private static Int64 calculateDigit(Int64 toVerify, Int16[] multipliers)
        {
            var factorsSum = calculateFactorsSum(toVerify, multipliers);
            var digit = factorsSum % 11;

            return digit < 2 ? 0 : 11 - digit;
        }

        private static Int64 calculateFactorsSum(Int64 toVerify, Int16[] multipliers)
        {
            if (toVerify == 0 || !multipliers.Any())
                return 0;

            var currentNumber = toVerify % 10;
            var currentMultiplier = multipliers.First();

            var otherNumbers = toVerify / 10;
            var otherMultipliers = multipliers.Skip(1).ToArray();

            return currentNumber * currentMultiplier
                   + calculateFactorsSum(otherNumbers, otherMultipliers);
        }


    }
}