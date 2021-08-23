using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingRepositoryPattern
{
    public enum TypeOfEvent
    {
        Golf=1,
        Bowling,
        AmusementPark,
        Concert

    }
    public class Outing
    {
        public int  EventId { get; set; }
        public int NumberOfPeople { get; set; }
        public DateTime DateOfEvent { get; set; }
        public double CostPerPerson { get; set; }
        public TypeOfEvent EventType { get; set; }
        public double TotalCost { get
            {
                return NumberOfPeople * CostPerPerson;
            } }

        public Outing() { }
        public Outing(int eventId,int numberOfPeople, DateTime dateOfEvent, double costPerPerson, TypeOfEvent eventType)
        {
            EventId = eventId;
            NumberOfPeople = numberOfPeople;
            DateOfEvent = dateOfEvent;
            CostPerPerson = costPerPerson;
            EventType = eventType;
        }

    }
}
