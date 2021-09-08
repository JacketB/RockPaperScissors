using System;

namespace game
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var Validator = new Validator();
            if (Validator.Validation(args))
            {
                
                new Game(args).StartGame();
            }
            else return;
        }
    }
}
