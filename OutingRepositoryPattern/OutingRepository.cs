using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingRepositoryPattern
{
    public class OutingRepository
    {
        private readonly List<Outing> _outingRepo = new List<Outing>();

        //Add outing 
        public void AddOuting(Outing model)
        {
            _outingRepo.Add(model);
        }

        //Get All Outing
        
        public List<Outing> GetAllOuting()
        {
            return _outingRepo;
        }

        // Display Each Outing
        public Outing GetOutingById(int id)
        {
            return _outingRepo.SingleOrDefault(o => o.EventId == id);

                                    
        }
        //Edit Outing
        public bool EditOuting(int Id, Outing model)
        {
            var outing = GetOutingById(Id);
            if (outing is null) return false;
            else
            {
                outing.CostPerPerson = model.CostPerPerson;
                outing.NumberOfPeople = model.NumberOfPeople;
                outing.DateOfEvent = model.DateOfEvent;
                outing.EventType = model.EventType;

                return true;
            }
        }

    }
}
