//namespace
using Model;
using Service;
using Database;


//Login and register process

Console.WriteLine("Welcome to Expense Reimbursement System!");

int ticketID = 4;
bool action = false;

Ticket ticket = DatabaseTicket.ProcessPendingTicket(ticketID,action);
Console.WriteLine(ticket.userName+"\n"+ticket.approvalStatus+"\n"+ticket.amountExpense);

Ticket ticket1 = ServiceClass.ProcessTicket(ticketID, action);
Console.WriteLine(ticket1.userName+"\n"+ticket1.approvalStatus+"\n"+ticket1.amountExpense);