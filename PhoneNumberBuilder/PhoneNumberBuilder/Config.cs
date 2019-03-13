using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneNumberBuilder
{
    public class Config
    {
        // TODO: in a larger application lazy singleton should be replaced by an IOC framework e.g. MEF singleton
        private static readonly Lazy<Config> _lazy = new Lazy<Config>(() => new Config());

        public static Config Instance => _lazy.Value;
        public Dictionary<string, Dictionary<int, List<int>>> ChessPieceMovesDictionary { get; private set; }
        public int PhoneNumberLength { get; private set; }
        public IEnumerable<int> ValidStartNumbers { get; private set; }

        private Config()
        {
            BuildConfig();
        }

        private void BuildConfig()
        {
            // set the phone length
            //
            PhoneNumberLength = 7; // get it from a config source

            // set valid start numbers
            //
            ValidStartNumbers = Enumerable.Range(2, 9); // get it from config

            // populate all configured chess piece's possible moves
            //            
            PopulateChessMoves();
            //
            // the above method could be replaced with something like BuildChessMoves()
            // to dynamically build the moves for each/configured chess pieces instead of pulling in static config.
        }

        private void PopulateChessMoves()
        {
            // TODO: This should be populated from a serialized/config source in order 
            // to be able to add new pieces with different number ranges without changing code
            //
            ChessPieceMovesDictionary = new Dictionary<string, Dictionary<int, List<int>>>();
            ChessPieceMovesDictionary.Add("ROOK", new Dictionary<int, List<int>>()
            {
                { 0, new List<int> { 2,5,8 } },
                { 1,new List <int> { 2,3,4,7 } },
                { 2,new List <int> { 1,3,5,8,0 } },
                { 3,new List <int> { 1,2,6,9 } },
                { 4,new List <int> { 1,7,5,6 } },
                { 5,new List <int> { 2,8,0,4,6 } },
                { 6,new List <int> { 3,9,4,5 } },
                { 7,new List <int> { 1,4,8,9 } },
                { 8,new List <int> { 0,2,5,7,9 } },
                { 9,new List <int> { 3,6,7,8 } }
            });

            ChessPieceMovesDictionary.Add("KNIGHT", new Dictionary<int, List<int>>()
            {
                { 0, new List<int> { 6, 4 } },
                { 1,new List <int> { 6, 8 } },
                { 2,new List <int> { 9, 7 } },
                { 3,new List <int> { 8, 4 } },
                { 4,new List <int> { 9, 0, 3 } },
                { 6,new List <int> { 1, 7, 0 } },
                { 7,new List <int> { 6, 2 } },
                { 8,new List <int> { 3, 1 } },
                { 9,new List <int> { 2, 4 } }
            });

            ChessPieceMovesDictionary.Add("KING", new Dictionary<int, List<int>>()
            {
                { 0, new List<int> { 7, 8, 9 } },
                { 1,new List <int> { 2, 5, 4 } },
                { 2,new List <int> { 1, 3, 4, 5, 6 } },
                { 3,new List <int> { 2, 5, 6 } },
                { 4,new List <int> { 1, 2, 5, 8, 7 } },
                { 5,new List <int> { 1, 2, 3, 4, 6, 7, 8, 9 } },
                { 6,new List <int> { 9, 8, 5, 2, 3 } },
                { 7,new List <int> { 4, 5, 8 } },
                { 8,new List <int> { 7, 4, 5, 6, 9, 0 } },
                { 9,new List <int> { 6, 5, 8, 0 } }
            });
        }
    }
}