using System;


namespace game
{
    class Game
    {
        private int computersmove;
        private int playermove;
        private string[] moves;
        private Hmac hmac = new Hmac();

        public Game(string[] moves)
        {
            this.moves = moves;
        }

        public void StartGame()
        {
            computersmove = GetComputerMove();
            hmac.CreateHmac(moves[computersmove]);
            PrintMenu();
            playermove =  ParseMenu() - 1;
            if (playermove < 0) return;
            Console.WriteLine($"Your move: {moves[playermove]}");
            Console.WriteLine($"Computer move: {moves[computersmove]}");
            new WinCondition(computersmove, playermove, moves.Length).CheckWinner();
            hmac.PrintKey();
        }

        private void PrintMenu()
        {
            hmac.PrintHmac();
            Console.WriteLine("Available moves:");
            for(int i = 0; i < moves.Length; i++)
            Console.WriteLine(i + 1+" - "+moves[i]);
            Console.WriteLine("0 - exit\n? - help");
        }

        private int ParseMenu()
        {
            Console.Write("Enter your move: ");
            string move = Console.ReadLine();
            if (move == "0")
                return -1;
            else if (move == "?")
            {
                Console.Clear();
                new HelpTable(moves).MakeTable();
            }
            else if (int.TryParse(move, out int id) && id <= moves.Length && id > 0)
            {
                return int.Parse(move);
            }
            Console.Clear();
            PrintMenu();
            return ParseMenu();
        }

        private int GetComputerMove()
        {
            int move = new Random().Next(0, moves.Length);
            return move;
        }
    }
}
