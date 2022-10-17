using Model;
using Database;

namespace Service;

public class ServiceClass{

    //login function
    public static void login(User loginUser){

        User returnUser = DatabaseUser.getUsers(loginUser);

        try{

            Console.WriteLine("Login successfully : " + returnUser.userName + " " + returnUser.userRole);
            Console.WriteLine("---------------------------");

            TicketAction(returnUser);
            
              
        }catch(NullReferenceException e){

            Console.WriteLine("---------------------------");
            Console.WriteLine("Username or password is NOT correct");
        }
        
        
    }

    // register function
    public static void register(User registerUser){

        
        DatabaseUser.setUser(registerUser);

    }


    //After login successful
    public static void TicketAction(User returnUser){
        
        while(true){
            
            Console.WriteLine("--------------------------");
            Console.WriteLine("What does you want to do next?");
            Console.WriteLine("[1]: Submit a Expense Reimbursement Ticket");
            Console.WriteLine("[2]: Review Expense Reimbursement Tickets history");

            if(returnUser.userRole == "manager"){

                Console.WriteLine("[3]: To Approve or Deny Employee Expense Reimburse Tickets");
            }

            Console.WriteLine("[x]: Exit" + "\n--------------------------");

            string Action = Console.ReadLine();

            if(Action == "1"){
                
                try{

                    Console.WriteLine("Please provide a description about ticket: ");
                    string description = Console.ReadLine();
                    Console.WriteLine("Please enter amount of your expensive: ");
                    double amountExpense = double.Parse(Console.ReadLine());

                    // sumbit ticket to DB
                    Ticket ticketToSubmit = new Ticket(returnUser.userName, description, amountExpense);
                    DatabaseTicket.submitTicket(ticketToSubmit);

                }catch(System.FormatException e){
                    
                    Console.WriteLine("Please enter A number for the amount of your expensive");
                }
                

            }
            else if(Action == "2"){

                List<Ticket> returnTicketArr = DatabaseTicket.getTicket(returnUser);
                
                Console.WriteLine("ID| User | Description | AmountExpense  | AprovalStatus | Date");
                
                foreach(Ticket ticket in returnTicketArr){
                    

                    Console.WriteLine(ticket.ID + "   " + ticket.userName + "   " + ticket.description + "    " + ticket.amountExpense + "    " + Ticket.ApprovalStatusToString(ticket.approvalStatus) + "    " + ticket.date);
                }
            }
            else if(Action == "3" && returnUser.userRole == "manager"){
                
                List<int> ticketIDArr = new List<int>();
                List<Ticket> returnTicketArr = DatabaseTicket.managerGetTicket(returnUser);
                
                Console.WriteLine("ID| User | Description | AmountExpense  | AprovalStatus | Date");
                foreach(Ticket ticket in returnTicketArr){
                    Console.WriteLine(ticket.ID + " " + ticket.userName + " " + ticket.description + " " + ticket.amountExpense + " " + Ticket.ApprovalStatusToString(ticket.approvalStatus) + " " + ticket.date);
                    ticketIDArr.Add(ticket.ID);
                }


                Console.WriteLine("What do you want to do with pending ticket?");
                Console.WriteLine("[1]:To approve a ticket");
                Console.WriteLine("[2]:To deny a ticket");
                string pendingTicketAction = Console.ReadLine();

                if(pendingTicketAction == "1" || pendingTicketAction == "2"){

                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Please enter the Ticket ID you want to " + ( (pendingTicketAction == "1")? "approve":"deny" ) );
                    int ticketIDPending = int.Parse(Console.ReadLine());

                    if(ticketIDArr.Contains(ticketIDPending)){

                        DatabaseTicket.ApproveORDenyTicket(ticketIDPending, pendingTicketAction);
                        ticketIDArr.Remove(ticketIDPending);
                    }
                    else{

                        Console.WriteLine("Please enter a VALID ticket ID");
                    }

                }
                else{
                    
                    Console.WriteLine("Please enter a VALID choice");
                }

                
            }
            else if(Action == "x"){
                break;
            }
            else{
                
                Console.WriteLine("Please enter a VALID input");
            }

        }
    }
}