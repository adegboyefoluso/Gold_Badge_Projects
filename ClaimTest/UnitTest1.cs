using ClaimRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ClaimTest
{
    [TestClass]
    public class UnitTest1
    {
        public ClaimRepo _claimRepo = new ClaimRepo();

        [TestInitialize]
       public void Arrange()
        {
            var claim1 = new Claim(100, "tjni", 250, new DateTime(12 / 01 / 2021), new DateTime(12 / 08 / 2021), TyPeOfClaim.Car);
            var claim2 = new Claim(200, "nioni", 250, new DateTime(12 / 01 / 2021), new DateTime(12 / 08 / 2021), TyPeOfClaim.Car);
            _claimRepo.AddQueue(claim1);
            _claimRepo.AddQueue(claim2);

        }

        [TestMethod]
        public void TestMethod1()
        {
            //Test Add Method and display the next Claim
            Assert.AreEqual("tjni", _claimRepo.DisplayNextClaim().Description);

            //Test Get All Claim
            Assert.AreEqual(2, _claimRepo.GetAllClaim().Count);

            //Test for process the next claim
            _claimRepo.ProccessNextClaim();
            Assert.AreNotEqual("tjni", _claimRepo.DisplayNextClaim().Description);
            Assert.AreEqual(1, _claimRepo.GetAllClaim().Count);
        }
    }
}
