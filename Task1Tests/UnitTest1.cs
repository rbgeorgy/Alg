using System;
using ConsoleApp1;
using NUnit.Framework;

namespace Task1Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var solver = new GraphSolver
            (
                5,
                8,
                new int[] {0, 3, 6, 1, 7, 6},
                new (int, int)[]
                {
                    (0, 0),
                    (1, 2),
                    (5, 4),
                    (5, 1),
                    (3, 4),
                    (5, 2),
                    (2, 4),
                    (2, 3),
                    (3, 1)
                }
            );
            
            Assert.AreEqual(3, solver.Solve());
            
            solver = new GraphSolver
            (
                5,
                4,
                new int[] {0, 3, 7, 2, 9, 4},
                new (int, int)[]
                {
                    (0, 0),
                    (1, 2),
                    (1, 3),
                    (2, 3),
                    (4, 5),
                }
            );
            
            Assert.AreEqual(-1, solver.Solve());
        }
    }
}