using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimRepository
{

    public enum TyPeOfClaim
    {
        Car=1,
        Home,
        Theft

    }
    public class Claim
    {
        public int ClaimID { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident{ get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool Isvalid
        {
            get
            { TimeSpan days= DateOfIncident - DateOfClaim;
                if ((int)days.TotalDays > 30||(int)days.TotalDays<=-1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
        }
        public TyPeOfClaim ClaimType { get; set; }

        public Claim() { }

        public Claim(int claimId,string description,double claimAmount,DateTime dateOfIncident,DateTime dateOfClaim,TyPeOfClaim claimType)
        {

        }

    }
   

  
}
