using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodewarsNotepad.Tests
{
    [TestClass()]
    public class ConwayLifeTests
    {
        [TestMethod()]
        public void GetCellValueAtNextGenerationTest()
        {
            Assert.AreEqual(1, ConwayLife.GetCellValueAtNextGeneration(1, 2));
            Assert.AreEqual(1, ConwayLife.GetCellValueAtNextGeneration(1, 3));
            Assert.AreEqual(1, ConwayLife.GetCellValueAtNextGeneration(0, 3));
            Assert.AreEqual(0, ConwayLife.GetCellValueAtNextGeneration(1, 1));
            Assert.AreEqual(0, ConwayLife.GetCellValueAtNextGeneration(1, 0));
            Assert.AreEqual(0, ConwayLife.GetCellValueAtNextGeneration(0, 2));
            Assert.AreEqual(0, ConwayLife.GetCellValueAtNextGeneration(0, 1));
            Assert.AreEqual(0, ConwayLife.GetCellValueAtNextGeneration(0, 0));
        }

        [TestMethod()]
        public void GetGenerationTest()
        {
            int[][,] gliders ={new int[,] {{1,0,0},{0,1,1},{1,1,0}},
                new int[,] {{0,1,0},{0,0,1},{1,1,1}}};

            int[][,] glidersSecond ={new int[,]
                {{ 1, 0, 0 }
                ,{ 0, 1, 1 }
                ,{ 1, 1, 0 }},
                new int[,]
                {{0,0,0}
                ,{0,0,1}
                ,{0,1,1}}};

            int[][,] glidersThird ={new int[,]
                {{ 1, 1, 1, 0, 0, 0, 1, 0 }
                ,{ 1, 0, 0, 0, 0, 0, 0, 1 }
                ,{ 0, 1, 0, 0, 0, 1, 1, 1 }},
                new int[,]
                {{ 1, 1, 0, 0, 0, 0, 0, 0 }
                ,{ 1, 1, 0, 0, 0, 0, 1, 1 }
                ,{ 0, 0, 0, 0, 0, 0, 1, 1 }}};

            Console.WriteLine("\n\nGlider");
            var res = ConwayLife.GetGeneration(gliders[0], 1);
            CollectionAssert.AreEqual(gliders[1], res, "Output doesn't match expected");

            Console.WriteLine("\n\nGliderSecond");
            res = ConwayLife.GetGeneration(glidersSecond[0], 2);
            CollectionAssert.AreEqual(glidersSecond[1], res, "Output doesn't match expected");

            Console.WriteLine("\n\nGliderThird");
            res = ConwayLife.GetGeneration(glidersThird[0], 16);
            CollectionAssert.AreEqual(glidersThird[1], res, "Output doesn't match expected");
        }

        [TestMethod()]
        public void CountNeighboursTest()
        {
            int[,] glider = { { 1, 0, 0 }, { 0, 1, 1 }, { 1, 1, 0 } };

            #region gliderAsserts

            Assert.AreEqual(1, ConwayLife.CountNeighbours(0, 0, glider));
            Console.WriteLine($"Assert for {0},{0} == {1} done.");
            Assert.AreEqual(3, ConwayLife.CountNeighbours(0, 1, glider));
            Console.WriteLine($"Assert for {0},{1} == {3} done.");
            Assert.AreEqual(2, ConwayLife.CountNeighbours(0, 2, glider));
            Console.WriteLine($"Assert for {0},{2} == {2} done.");

            Assert.AreEqual(4, ConwayLife.CountNeighbours(1, 0, glider));
            Console.WriteLine($"Assert for {1},{0} == {4} done.");
            Assert.AreEqual(4, ConwayLife.CountNeighbours(1, 1, glider));
            Console.WriteLine($"Assert for {1},{1} == {4} done.");
            Assert.AreEqual(2, ConwayLife.CountNeighbours(1, 2, glider));
            Console.WriteLine($"Assert for {1},{2} == {2} done.");

            Assert.AreEqual(2, ConwayLife.CountNeighbours(2, 0, glider));
            Console.WriteLine($"Assert for {2},{0} == {2} done.");
            Assert.AreEqual(3, ConwayLife.CountNeighbours(2, 1, glider));
            Console.WriteLine($"Assert for {2},{1} == {3} done.");
            Assert.AreEqual(3, ConwayLife.CountNeighbours(2, 2, glider));
            Console.WriteLine($"Assert for {2},{2} == {3} done.");

            #endregion gliderAsserts
        }
    }
}