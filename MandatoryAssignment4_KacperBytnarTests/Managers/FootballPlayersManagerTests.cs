using Microsoft.VisualStudio.TestTools.UnitTesting;
using MandatoryAssignment4_KacperBytnar.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment1_KacperBytnar;

namespace MandatoryAssignment4_KacperBytnar.Managers.Tests
{
    [TestClass()]
    public class FootballPlayersManagerTests
    {
        private FootballPlayersManager _manager;

        [TestInitialize]
        public void TestInitialize()
        {
            _manager = new FootballPlayersManager();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var footballPlayers = _manager.GetAll();
            Assert.AreEqual(4, footballPlayers.Count);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var footballPlayer = _manager.GetById(1);
            if (footballPlayer != null)
            {
                Assert.AreEqual("Dawid", footballPlayer.Name);
            }
            else
            {
                Assert.Fail("Player not found");
            }
        }

        [TestMethod()]
        public void AddTest()
        {
            var footballPlayer = new FootballPlayer(5, "Mohammed", 9, 96);

            _manager.Add(footballPlayer);
            var footballPlayers = _manager.GetAll();
            Assert.AreEqual(5, footballPlayers.Count);
        }
    }
}