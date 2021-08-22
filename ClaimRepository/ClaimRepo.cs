using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimRepository
{
    public class ClaimRepo
    {
        private readonly Queue<Claim> _ClaimQueue = new Queue<Claim>();
        public bool AddQueue(Claim model)
        {
            int count = 0;
            int IdCount = 100;
            model.ClaimID = IdCount;
            IdCount = IdCount + 1;
            _ClaimQueue.Enqueue(model);
           return  (_ClaimQueue.Count > count) ? true : false;

        }
        //==============================List of Claim======================//
        public Queue<Claim> GetAllClaim()
        {
            return _ClaimQueue;
        }
        //==============================Get Next Claim=====================//  
        public Claim DisplayNextClaim()
        {
            var claim = _ClaimQueue.Peek();
            return claim;
        }
        //=================================Treat next Claim====================//
        public Claim ProccessNextClaim()
        {
           return  _ClaimQueue.Dequeue();
        }

    }
}
