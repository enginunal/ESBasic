using AccountDomain;


//Create an account 
var accountId = Guid.NewGuid();
var account = new AccountEntity(accountId);
//Some transactions
account.Deposit(15);
account.Deposit(5);
account.Withdraw(10);
//Account balance :
Console.WriteLine($"Balance:{account.Balance}");

//Now we have all necessary data to generate account from the ground up
var @events = account.TakeEvents();
var accountProjected = new AccountEntity(@events);
Console.WriteLine($"Balance:{accountProjected.Balance}");


