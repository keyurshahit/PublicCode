using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberBuilder
{
    public class NumberCombinationCounter
    {
        public int Count(Dictionary<int, List<int>> possibleMoves, int startNumber, int remainingCount, StringBuilder sb = null)
        {
            // if the "sb" object (optional) is supplied we will populate it with all the combination numbers 
            // and print it to a log source (Console here)
            bool printNumbers = sb != null;

            if (remainingCount >= 0)
            {
                if (printNumbers)
                    sb.Append(startNumber);
            }

            if (remainingCount == 0)
            {
                if (printNumbers)
                {
                    Console.WriteLine(sb.ToString());
                    sb.Clear();
                }

                return 1;
            }
            else if (!possibleMoves.ContainsKey(startNumber))
                return 0;
            else
            {
                int count = 0;
                foreach (int move in possibleMoves[startNumber])
                    count += Count(possibleMoves, move, remainingCount - 1, sb);

                return count;
            }
        }
    }
}