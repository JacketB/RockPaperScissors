using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace game
{
    class Validator
    {
        private bool isValid = true;
        public bool Validation(string[] args)
        {
            if (args.Length == 1)
            {
                isValid = false;
                Console.WriteLine("The number of parameters must be more than one");
            }
            if (!CheckNotEmpty(args))
            {
                isValid = false;
                Console.WriteLine("Parameters must not be empty");
            }
            if (!CheckOdd(args))
            {
                isValid = false;
                Console.WriteLine("The number of parameters must be odd");
            }
            if (!CheckNotRepeat(args))
            {
                isValid = false;
                Console.WriteLine("The entered parameters must not match");
            }
            return isValid;
        }
        
        private bool CheckNotEmpty(string[] args)
        {
            return args.Length > 0 ? true : false;
        }

        private bool CheckOdd(string[] args)
        {
            return args.Length % 2 != 0 ? true : false;
        }

        private bool CheckNotRepeat(string[] args)
        {
            return args.Distinct().ToList().Count == args.Length ? true : false;
        }
    }
}
