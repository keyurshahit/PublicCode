using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                throw new Exception("Empty args list: Please provide at least one or more names of the chess pieces to run the app for.");

            NumberCombinationCounter combinationCounter = new NumberCombinationCounter();
            foreach (var arg in args)
            {
                string chessPieceName = arg.ToUpper();
                Console.WriteLine($"Running phone number combination counter for chess piece: {chessPieceName}");
                if (Config.Instance.ChessPieceMovesDictionary.ContainsKey(chessPieceName))
                {                    
                    int count = 0;
                    foreach (int number in Config.Instance.ValidStartNumbers)
                        count += combinationCounter.Count(Config.Instance.ChessPieceMovesDictionary[chessPieceName], number, Config.Instance.PhoneNumberLength - 1);

                    Console.WriteLine($"Total count for phone number of length: {Config.Instance.PhoneNumberLength} for chess piece [{chessPieceName}]: {count}");
                }
                else
                    Console.Error.WriteLine($"Given chess piece [{chessPieceName}] is currently not configured. Please add the required config and restart.");
            }

            Console.Read();
        }
    }
}