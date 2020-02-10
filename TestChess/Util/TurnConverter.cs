using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestChess.Util
{
    class TurnConverter
    {
        private static readonly string _regex = "[A-Ha-h][1-8]";
        private static readonly int _boardSize = 8;
        private static readonly int _letterValue = 96;

        protected TurnConverter()
        {
        }

        private static List<string> Match(string message)
        {
            var matched = Regex.Matches(message, _regex).Cast<Match>().Select(m=> m.Value.ToLower()).ToList();
            return matched.Count == 2 ? matched : null;
        }

        public static int[] Convert(string message)
        {
            var matched = Match(message);
            return matched == null ? null : TransformToIntArray(matched);
        }

        private static int[] TransformToIntArray(List<string> matched) => 
            matched.Select(x => (x.ElementAt(0) - _letterValue) + (_boardSize - int.Parse(x.Substring(1))) * _boardSize).ToArray();

    }
}
