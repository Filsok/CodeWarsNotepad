using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CodewarsNotepad.Tests
{
    [TestClass()]
    public class ConnectFourTheGameTests
    {
        [TestMethod()]
        public void WhoIsWinnerTest()
        {
            var testList = new List<List<string>>()
            {
                new List<string>(){ "A_Red","B_Yellow","A_Red","B_Yellow","A_Red","B_Yellow","G_Red","B_Yellow"},
                new List<string>(){ "C_Yellow","E_Red","G_Yellow","B_Red","D_Yellow","B_Red","B_Yellow","G_Red","C_Yellow","C_Red","D_Yellow","F_Red","E_Yellow","A_Red","A_Yellow","G_Red","A_Yellow","F_Red","F_Yellow","D_Red","B_Yellow","E_Red","D_Yellow","A_Red","G_Yellow","D_Red","D_Yellow","C_Red"},
                new List<string>(){ "A_Yellow","B_Red","B_Yellow","C_Red","G_Yellow","C_Red","C_Yellow","D_Red","G_Yellow","D_Red","G_Yellow","D_Red","F_Yellow","E_Red","D_Yellow"}
            };

            Assert.AreEqual("Yellow", ConnectFourTheGame.WhoIsWinner(testList[0]));
            Assert.AreEqual("Yellow", ConnectFourTheGame.WhoIsWinner(testList[1]));
            Assert.AreEqual("Red", ConnectFourTheGame.WhoIsWinner(testList[2]));
        }
    }
}

/*
 Connect Four
Take a look at wiki description of Connect Four game:
Wiki Connect Four
The grid is 6 row by 7 columns, those being named from A to G.
You will receive a list of strings showing the order of the pieces which dropped in columns:

List<string> myList = new List<string>()
{
    "A_Red",
    "B_Yellow",
    "A_Red",
    "B_Yellow",
    "A_Red",
    "B_Yellow",
    "G_Red",
    "B_Yellow"
};

The list may contain up to 42 moves and shows the order the players are playing.
The first player who connects four items of the same color is the winner.
You should return "Yellow", "Red" or "Draw" accordingly.
 */