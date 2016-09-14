using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public string ClaimText { get; set; }
        public string Subject { get; set; }
        public Nullable<int> ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
