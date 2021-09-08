using System;
using System.Collections.Generic;
using System.Text;
using ConsoleTableExt;
namespace game
{
    
    class HelpTable
    {
        private string[] moves;

        public HelpTable(string[] moves)
        {
            this.moves = moves;
        }

        public void MakeTable()
        {
            var winnersTable = new List<List<object>>();
            var titleline = new List<object>();
            titleline.Add("user\\pc");
            titleline.AddRange(moves);
            winnersTable.Add(titleline);
            for (int i = 0; i < moves.Length; i++)
            {
                var line = new List<object>();
                line.Add(moves[i]);
                for (int j = 0; j < moves.Length; j++)
                {
                    line.Add( WinCondition.CheckWinner(i,j,moves.Length));
                }
                winnersTable.Add(line);
            }

            ConsoleTableBuilder.From(winnersTable).WithFormat(ConsoleTableBuilderFormat.Alternative).ExportAndWriteLine();
            Console.ReadKey();
            Console.Clear();
            
        }
    }
}
