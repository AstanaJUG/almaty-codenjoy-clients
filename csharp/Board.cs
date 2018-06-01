using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeClient
{
    internal class Board
    {
        public string RawBoard { get; private set; }

        public string Source { get; private set; }

        public void Parse(string input)
        {
            if (input.StartsWith("board="))
                input = input.Substring(6);

            Source = input;

            RawBoard = input
                .Replace('☼', '#')  // wall
                .Replace('▲', '0').Replace('◄', '0').Replace('►', '0').Replace('▼', '0')  // head
                .Replace('║', 'o').Replace('═', 'o').Replace('╙', 'o').Replace('╘', 'o')  // body
                .Replace('╓', 'o').Replace('╕', 'o')
                .Replace('╗', 'o').Replace('╝', 'o').Replace('╔', 'o').Replace('╚', 'o')  // body
                .Replace('☻', 'X')  // bad apple
                .Replace('☺', '$'); // good apple
        }

        public string GetDisplay()
        {
            return RawBoard;
        }
    }

    internal enum BoardCell
    {
        HBAD_APPLE = '☻',
        GOOD_APPLE = '☺',

        BREAK = '☼',

        HEAD_DOWN = '▼',
        HEAD_LEFT = '◄',
        HEAD_RIGHT = '►',
        HEAD_UP = '▲',

        TAIL_END_DOWN = '╙',
        TAIL_END_LEFT = '╘',
        TAIL_END_UP = '╓',
        TAIL_END_RIGHT = '╕',
        TAIL_HORIZONTAL = '═',
        TAIL_VERTICAL = '║',
        TAIL_LEFT_DOWN = '╗',
        TAIL_LEFT_UP = '╝',
        TAIL_RIGHT_DOWN = '╔',
        TAIL_RIGHT_UP = '╚',

        NONE = ' '

        
    }
}
