using System;
using L9GenericsColl.Entities;
using L9GenericsColl.Repositories;
using NUnit.Framework;
using Moq;
using System.Linq;
using System.Collections.Generic;
using L9GenericsColl.Interfaces;

namespace L9GenericsColl.Test
{
    [TestFixture]
    class FirstTest
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ItShouldCreateAUserSuccessAndShowHisStatWithoutSuccess()
        {
            Gamer gamer = new Gamer();
            gamer.Id = 0;
            gamer.Name = "JAKE";
            var stat=  gamer.ShowResults();



            Assert.AreEqual("JAKE", gamer.Name);
            Assert.AreEqual("0", stat);
          
        }
        [Test]
        public void ItShouldAddNewUserToReposWithSuccess()
        {
            Gamer gamer = new Gamer();
            gamer.Id = 1;
            gamer.Name = "Alex";
            
            BaseRepository<Gamer> st = new BaseRepository<Gamer>();

            st.Add(gamer);
            var user=st.GetById(1);

            Assert.IsFalse(st.GetById(1)!=user);

         
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

            // st.Add
            var gm2 = st.GetById(id);
        

            Assert.IsFalse(gm == gm2);
        }
        [Test]
        public void ItShouldCallSmth()
        {
            var mockTest = new Mock<GamerRepository>();
            mockTest.Setup(mock => mock.GetAll()).Returns(new List<Gamer>());
            


            Assert.IsNotNull(mockTest.Object);
        }


    }
}
