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
        public void AddQueue(Claim model)
        {
           

            _ClaimQueue.Enqueue(model);
           

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
