using System;
using System.Collections.Generic;
using System.Linq;

namespace CodewarsNotepad
{
    public class ConnectFourTheGame
    {
        public static string WhoIsWinner(List<string> piecesPositionList)
        {
            //0-null; 1-Red; 2-Yellow
            var board = new int[6, 7];
            string ret = "";
            ret = MainLogic(piecesPositionList, board, ret);

            return ret;
        }

        private static string MainLogic(List<string> piecesPositionList, int[,] board, string ret)
        {
            foreach (var move in from item in piecesPositionList
                                 let move = item.Split('_')
                                 select move)
            {
                var moveColumn = ConvertColumnToNumber(move);
                Winner moveCoin = CheckCoinColor(move);

                int count = 0;
                for (int i = 0; i < 6; i++)
                {
                    if (board[i, moveColumn] == 0)
                    {
                        board[i, moveColumn] = (int)moveCoin;

                        //vertical
                        for (int j = 1; j <= 3; j++)
                        {
                            if (i - j >= 0)
                            {
                                if (board[i - j, moveColumn] == (int)moveCoin) count++;
                            }
                            if (count == 3) ret = ((int)moveCoin == 1) ? "Red" : "Yellow";
                        }
                        count = 0;
                        //horizontal
                        for (int j = 1; j <= 3; j++)
                        {
                            if (0 <= moveColumn - j && moveColumn - j <= 6)
                            {
                                if (board[i, moveColumn - j] == (int)moveCoin) count++;
                                else break;
                            }
                        }
                        for (int j = 1; j <= 3; j++)
                        {
                            if (0 <= moveColumn + j && moveColumn + j <= 6)
                            {
                                if (board[i, moveColumn + j] == (int)moveCoin) count++;
                                else break;
                            }
                        }
                        if (count >= 3) ret = ((int)moveCoin == 1) ? "Red" : "Yellow";
                        count = 0;
                        //diagonal /
                        for (int j = 1; j <= 3; j++)
                        {
                            if (0 <= moveColumn - j && moveColumn - j <= 6 && 0 <= i - j && i - j <= 5)
                            {
                                if (board[i - j, moveColumn - j] == (int)moveCoin) count++;
                                else break;
                            }
                        }
                        for (int j = 1; j <= 3; j++)
                        {
                            if (0 <= moveColumn + j && moveColumn + j <= 6 && 0 <= i + j && i + j <= 5)
                            {
                                if (board[i + j, moveColumn + j] == (int)moveCoin) count++;
                                else break;
                            }
                        }
                        if (count >= 3) ret = ((int)moveCoin == 1) ? "Red" : "Yellow";
                        count = 0;
                        //diagonal \
                        for (int j = 1; j <= 3; j++)
                        {
                            if (0 <= moveColumn - j && moveColumn - j <= 6 && 0 <= i + j && i + j <= 5)
                            {
                                if (board[i + j, moveColumn - j] == (int)moveCoin) count++;
                                else break;
                            }
                        }
                        for (int j = 1; j <= 3; j++)
                        {
                            if (0 <= moveColumn + j && moveColumn + j <= 6 && 0 <= i - j && i - j <= 5)
                            {
                                if (board[i - j, moveColumn + j] == (int)moveCoin) count++;
                                else break;
                            }
                        }
                        if (count >= 3) ret = ((int)moveCoin == 1) ? "Red" : "Yellow";
                        break;
                    }
                }

                if (!String.IsNullOrEmpty(ret)) break;

                if (String.IsNullOrEmpty(ret)) ret = "Draw";

            }

            return ret;
        }

        private static Winner CheckCoinColor(string[] move)
        {
            switch (move[1])
            {
                case "Red": return Winner.RED;
                case "Yellow": return Winner.RED;
            }

            return Winner.DRAW;
        }

        private static int ConvertColumnToNumber(string[] move)
        {
            int moveColumn;
            switch (move[0])
            {
                case "A": moveColumn = 0; break;
                case "B": moveColumn = 1; break;
                case "C": moveColumn = 2; break;
                case "D": moveColumn = 3; break;
                case "E": moveColumn = 4; break;
                case "F": moveColumn = 5; break;
                case "G": moveColumn = 6; break;
                default: moveColumn = 9; break;
            }

            return moveColumn;
        }

        private enum Winner
        {
            DRAW,
            RED,
            YELLOW
        }
    }
}

/*
/// <summary>
/// Connect Four
///Take a look at wiki description of Connect Four game.
///The grid is 6 row by 7 columns, those being named from A to G.
///You will receive a list of strings showing the order of the pieces which dropped in columns: "A_Red" , "B_Yellow",...
///The list may contain up to 42 moves and shows the order the players are playing.
///The first player who connects four items of the same color is the winner.
///You should return "Yellow", "Red" or "Draw" accordingly.
/// </summary>
/// <param name="piecesPositionList">List<string> {"A_Red",B_Yellow"....}</string></param>
/// <returns></returns>
*/