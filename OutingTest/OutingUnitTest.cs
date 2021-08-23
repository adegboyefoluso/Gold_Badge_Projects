using Microsoft.VisualStudio.TestTools.UnitTesting;
using OutingRepositoryPattern;
using System;

namespace OutingTest
{
    [TestClass]
    public class OutingUnitTest
    {
        private OutingRepository _OutingRepo = new OutingRepository();
        [TestInitialize]
        public void Arrange()
        {
            var outing1 = new Outing(1, 10, new DateTime(2015, 08, 01), 12, TypeOfEvent.Golf);
            var outing2 = new Outing(2, 10, new DateTime(2018, 08, 01), 14, TypeOfEvent.Bowling);
            var outing3 = new Outing(3, 10, new DateTime(2020, 04, 18), 40, TypeOfEvent.Concert);
            var outing4 = new Outing(4, 10, new DateTime(2015, 08, 01), 70, TypeOfEvent.Golf);
            var outing5 = new Outing(4, 10, new DateTime(2018, 08, 01), 80, TypeOfEvent.Bowling);
            var outing6 = new Outing(6, 10, new DateTime(2020, 04, 18), 90, TypeOfEvent.Concert);
            _OutingRepo.AddOuting(outing1);
            _OutingRepo.AddOuting(outing2);
            _OutingRepo.AddOuting(outing3);
            _OutingRepo.AddOuting(outing4);
            _OutingRepo.AddOuting(outing5);
            _OutingRepo.AddOuting(outing6);
        }

        [TestMethod]
        public void AddMethod()
        {
            Assert.AreEqual(6, _OutingRepo.GetAllOuting().Count);  //Test Add Method
            Assert.AreEqual(3060, _OutingRepo.TotalcostOFAllEvent());// Total Cost of All Event
            Console.WriteLine(_OutingRepo.GetOutingById(1).TotalCost); // Total cost of each event
            Console.WriteLine(_OutingRepo.TotalcostOFAllEvent());   //Total Cost  of all event
            Assert.AreEqual(940, _OutingRepo.TotalCostByEventType(TypeOfEvent.Bowling)); // test total cpst of event for Bowling
            Assert.AreEqual(820, _OutingRepo.TotalCostByEventType(TypeOfEvent.Golf));// test for total cost of Golf Event
            Assert.AreEqual(1300, _OutingRepo.TotalCostByEventType(TypeOfEvent.Concert));//Test for total cost of Concert event

            
        }
    }
}
