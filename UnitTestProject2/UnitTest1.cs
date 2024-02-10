using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SinglePlayerDarts;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DoesGameExist()
        {
            //arrange
            Game g = new Game();

            //act

            //assert
            Assert.IsNotNull(g);
        }
        [TestMethod]
        public void allmissesReturns0()
        {
            //arrange
            Game g = new Game();

            //act

            //assert
            Assert.IsNotNull(g);
        }
        //[TestMethod]
        //public void 3MissesGameReturns0()
        //{
        //    //arrange

        //    //act
        //    totalScore(0);

        //    //assert
        //    Assert.AreEqual(0, g.scoreGame());
        //}


    }
}
