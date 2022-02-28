using AccountEvents;
using System;
using System.Collections.Generic;

namespace AccountDomain
{
    public class AccountEntity
    {        
        private Guid _id;
        public decimal Balance { get; private set; }

        public AccountEntity(Guid id)
        {
            Raise(new AccountEvents.Created(id));
        }

        public void Deposit(int amount)
        {
            Raise(new AccountEvents.Deposited(_id, amount));
        }
        public void Withdraw(int amount)
        {
            Raise(new AccountEvents.Withdrawn(_id, amount));
        }

        private void Apply(AccountEvents.Created @event)
        {
            _id = @event.AccountId;
        }
        private void Apply(AccountEvents.Deposited @event)
        {
            Balance += @event.Amount;
        }
        private void Apply(AccountEvents.Withdrawn @event)
        {
            Balance -= @event.Amount;
        }
                       
        public AccountEntity(IEnumerable<object> history){
            foreach (var @event in history)
            {
                Apply(@event as dynamic); 
            }
        }

        private List<object> _eventStore = new List<object>(); 
        
        private void Raise(object @event)
        {
            _eventStore.Add(@event);
            Apply(@event as dynamic); 
        }

        public List<object> TakeEvents()
        {
            var @events = new List<object>(_eventStore);
            return @events;
        }


    }
}
