using Castle.Core.Logging;
using L9GenericsColl.Entities;
using L9GenericsColl.Interfaces;
using L9GenericsColl.Repositories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace L20Test
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ItShouldCreateAUserSuccess()
        {
            Gamer gamer = new Gamer();
            gamer.Id = 0;
            gamer.Name = "JAKE";
            var stat = gamer.ShowResults();



            Assert.AreEqual("JAKE", gamer.Name);
           // Assert.AreEqual("0", stat);

        }
        [Test]
        public void ItShouldAddNewUserToReposWithSuccess()
        {
            Gamer gamer = new Gamer();
            gamer.Id = 1;
            gamer.Name = "Alex";

            BaseRepository<Gamer> st = new BaseRepository<Gamer>();

            st.Add(gamer);
            var user = st.GetById(1);

            Assert.IsTrue(st.GetById(1) == user);


        }
        [TestCase("oldName", "newName", 0)]

        public void ItShouldEditAUserWithoutSuccess(string oldName, string newName, int id)
        {
            Gamer gamer = new Gamer();
            gamer.Id = id;
            gamer.Name = oldName;
            BaseRepository<Gamer> st = new BaseRepository<Gamer>();

            st.Add(gamer);
            var gm = st.GetById(id);


            gamer.Name = newName;

          
            var gm2 = st.GetById(id);
            st.Add(gm2);

            Assert.IsFalse(gm == gm2);
        }
        [Test]
        public void ItShouldCheckIfReposWillWorkWithLogger()
        {
           
            var mockLogger = new Mock<ILogger>();
            var repos = new BaseRepository<Gamer>(mockLogger.Object);
            Gamer gamer = new Gamer();
            repos.Add(gamer);
            mockLogger.Verify(lw=>lw.Debug(It.IsAny<string>()));

          
        }

    }
}