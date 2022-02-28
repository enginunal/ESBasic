using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountEvents
{
    public record Created
    {
        public readonly Guid AccountId;
        public Created(Guid accountId)
        {
            AccountId = accountId;
        }
    }
    public record Deposited
    {
        public readonly Guid AccountId;
        public readonly int Amount;
        public Deposited(Guid accountId, int amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
    public record Withdrawn
    {
        public readonly Guid AccountId;
        public readonly int Amount;
        public Withdrawn(Guid accountId, int amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }

}
