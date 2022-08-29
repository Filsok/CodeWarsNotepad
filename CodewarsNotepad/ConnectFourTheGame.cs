using System;
using System.Collections.Generic;
using System.Linq;

namespace CodewarsNotepad
{
    public class ConnectFourTheGame
    {
        public static string WhoIsWinner(List<string> piecesPositionList)
        {
            var board = new Winner[6, 7];
            Winner result=Winner.DRAWOREMPTY;

            foreach (var move in from item in piecesPositionList
                                 let move = item.Split('_')
                                 select move)
            {
                var moveColumn = ConvertColumnToNumber(move);
                Winner moveCoin = CheckCoinColor(move);

                for (int i = 0; i < 6; i++)
                {
                    if (board[i, moveColumn] == 0)
                    {
                        board[i, moveColumn] = moveCoin;
                        if (IsWinner(board, moveColumn, moveCoin, i)) result = moveCoin;

                        break;
                    }
                }

                if (result==Winner.RED||result==Winner.YELLOW) break;
            }

            return ResultToString(result);
        }

        private static string ResultToString(Winner result)
        {
            string ret;
            switch (result)
            {
                case Winner.DRAWOREMPTY:
                    ret = "Draw";
                    break;
                case Winner.RED:
                    ret = "Red";
                    break;
                case Winner.YELLOW:
                    ret = "Yellow";
                    break;
                default:
                    ret = "Something went wrong";
                    break;
            }
            return ret;
        }

        private static bool IsWinner(Winner[,] board, int moveColumn, Winner moveCoin, int i)
        {
            if (IsWinnerVertical(board, moveColumn, moveCoin, i)) return true;
            if (IsWinnerHorizontal(board, moveColumn, moveCoin, i)) return true;
            if (IsWinnerDiagonal(board, moveColumn, moveCoin, i)) return true;
            return false;
        }

        private static bool IsWinnerDiagonal(Winner[,] board, int moveColumn, Winner moveCoin, int i)
        {
            //diagonal /
            int count = 0;
            for (int j = 1; j <= 3; j++)
            {
                if (0 <= moveColumn - j && moveColumn - j <= 6 && 0 <= i - j && i - j <= 5)
                {
                    if (board[i - j, moveColumn - j] == moveCoin) count++;
                    else break;
                }
            }
            for (int j = 1; j <= 3; j++)
            {
                if (0 <= moveColumn + j && moveColumn + j <= 6 && 0 <= i + j && i + j <= 5)
                {
                    if (board[i + j, moveColumn + j] == moveCoin) count++;
                    else break;
                }
            }
            if (count >= 3) return true;

            //diagonal \
            count = 0;
            for (int j = 1; j <= 3; j++)
            {
                if (0 <= moveColumn - j && moveColumn - j <= 6 && 0 <= i + j && i + j <= 5)
                {
                    if (board[i + j, moveColumn - j] == moveCoin) count++;
                    else break;
                }
            }
            for (int j = 1; j <= 3; j++)
            {
                if (0 <= moveColumn + j && moveColumn + j <= 6 && 0 <= i - j && i - j <= 5)
                {
                    if (board[i - j, moveColumn + j] == moveCoin) count++;
                    else break;
                }
            }
            if (count >= 3) return true;
            return false;
        }

        private static bool IsWinnerHorizontal(Winner[,] board, int moveColumn, Winner moveCoin, int i)
        {
            int count = 0;
            for (int j = 1; j <= 3; j++)
            {
                if (0 <= moveColumn - j && moveColumn - j <= 6)
                {
                    if (board[i, moveColumn - j] == moveCoin) count++;
                    else break;
                }
            }
            for (int j = 1; j <= 3; j++)
            {
                if (0 <= moveColumn + j && moveColumn + j <= 6)
                {
                    if (board[i, moveColumn + j] == moveCoin) count++;
                    else break;
                }
            }
            if (count >= 3) return true;
            return false;
        }

        private static bool IsWinnerVertical(Winner[,] board, int moveColumn, Winner moveCoin, int i)
        {
            int count = 0;
            for (int j = 1; j <= 3; j++)
            {
                if (i - j >= 0)
                {
                    if (board[i - j, moveColumn] == moveCoin) count++;
                }
                if (count == 3)
                    return true;
            }
            return false;
        }

        private static Winner CheckCoinColor(string[] move)
        {
            switch (move[1])
            {
                case "Red": return Winner.RED;
                case "Yellow": return Winner.YELLOW;
            }

            return Winner.DRAWOREMPTY;
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
            DRAWOREMPTY,
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