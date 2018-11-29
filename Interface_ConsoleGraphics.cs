using System;
using Chess;
using NNLogic;

namespace Interface
{
    public class ConsoleGraphics
    {
        public static void DrawPosition(int[,] board)
        {
            Console.WriteLine(ConstructTopLine() + ConstructMiddlePart(board) + ConstructBottomLine());
        }
        public static void DrawPosition(Position position)
        {
            DrawPosition(position.board);
        }
        private static string ConstructTopLine()
        {
            string topLine = Constants.BORDER_GRAPHICS("top left corner");
            for (sbyte i = 0; i < 7; i++)
            {
                topLine += Constants.BORDER_GRAPHICS("horizontal") + Constants.BORDER_GRAPHICS("top split edge");
            }
            topLine += Constants.BORDER_GRAPHICS("horizontal") + Constants.BORDER_GRAPHICS("top right corner") + "\n";
            return topLine;
        }
        private static string ConstructMiddleLine()
        {
            string middleLine = Constants.BORDER_GRAPHICS("left split edge");
            for (sbyte i = 0; i < 7; i++)
            {
                middleLine += Constants.BORDER_GRAPHICS("horizontal") + Constants.BORDER_GRAPHICS("crosspoint");
            }
            middleLine += Constants.BORDER_GRAPHICS("horizontal") + Constants.BORDER_GRAPHICS("right split edge") + "\n";
            return middleLine;
        }
        private static string ConstructMiddlePart(int[,] board)
        {
            string middlePart = "";
            for (sbyte i = 0; i < 8; i++)
            {
                for (sbyte j = 0; j < 8; j++)
                {
                    middlePart += Constants.BORDER_GRAPHICS("vertical") + Constants.PIECE_REPRESENTATIONS(board[j, i]);
                }
                middlePart += Constants.BORDER_GRAPHICS("vertical") + "\n";
                if (!(i == 7))
                {
                    middlePart += ConstructMiddleLine();
                }
            }
            return middlePart;
        }
        private static string ConstructBottomLine()
        {
            string bottomLine = Constants.BORDER_GRAPHICS("bottom left corner");
            for (sbyte i = 0; i < 7; i++)
            {
                bottomLine += Constants.BORDER_GRAPHICS("horizontal") + Constants.BORDER_GRAPHICS("bottom split edge");
            }
            bottomLine += Constants.BORDER_GRAPHICS("horizontal") + Constants.BORDER_GRAPHICS("bottom right corner");
            return bottomLine;
        }
        public static void WriteResult(NeuralNetwork white, NeuralNetwork black, float result)
        {
            Console.WriteLine(string.Format("{0,-18} {1,3} - {2,-3} {3,18}",
                string.Format("Net {0} ({1})", white.ID, white.score),
                result, 1 - result,
                string.Format("Net {0} ({1})", black.ID, black.score)
            ));
        }
    }
}
