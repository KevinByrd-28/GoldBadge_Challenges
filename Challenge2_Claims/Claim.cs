using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Claims
{
    public enum ClaimType { CarAccident, CarTheft, HomeFire, HomeInjury}
    public class Claim
    {
        public string ClaimID { get; set; }
        public ClaimType Type { get; set; }
        public string Description { get; set; }
        public decimal ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim()
        {

        }

        public Claim(string aClaimID, ClaimType aType, string aDescription, decimal aClaimAmount, DateTime aDateOfIncident, DateTime aDateOfClaim, bool aIsValid)
        {
            ClaimID = aClaimID;
            Type = aType;
            Description = aDescription;
            ClaimAmount = aClaimAmount;
            DateOfIncident = aDateOfIncident;
            DateOfClaim = aDateOfClaim;
            IsValid = aIsValid;

        }

        
    }
}
