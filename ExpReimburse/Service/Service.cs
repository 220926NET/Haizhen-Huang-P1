using Model;
using Database;

namespace Service;

public class ServiceClass{

    //login function
    public static void login(string userName, string userPassword){

        User returnUser = DatabaseUser.getUsers(userName, userPassword);

        try{

            Console.WriteLine("Login successfully : " + returnUser.userName + " " + returnUser.userRole);
            Console.WriteLine("---------------------------");

            TicketAction(returnUser.userName, returnUser.userRole);
            
              
        }catch(NullReferenceException e){

            Console.WriteLine("Username or password is NOT correct");
        }
        
        
    }

    // register function
    public static void register(string userName, string userPassword, string userRole){

        DatabaseUser.setUser(userName, userPassword, userRole);

    }


    //After login successful
    public static void TicketAction(string userName, string userRole){
        
        while(true){

            Console.WriteLine("What does you want to do next?");
            Console.WriteLine("[1]: Submit a Expense Reimbursement Ticket");
            Console.WriteLine("[2]: Review Expense Reimbursement Tickets history");

            if(userRole == "manager"){

                Console.WriteLine("[3]: To Approve Employee Expense Reimburse Tickets");
            }

            Console.WriteLine("[x]: Exit" + "\n--------------------------");

            string ticketAction = Console.ReadLine();

            if(ticketAction == "1"){

                Console.WriteLine("Please provide a description about ticket: ");
                string description = Console.ReadLine();
                Console.WriteLine("Please enter amount of your expensive: ");
                string strAmountExp = Console.ReadLine();
                double amountExp = double.Parse(strAmountExp);
                
                // sumbit ticket to DB
                DatabaseTicket.submitTicket(userName, description, amountExp);

            }
            else if(ticketAction == "2"){

                List<Ticket> returnTicketArr = DatabaseTicket.getTicket(userName);
                
                Console.WriteLine("ID| User | Description | AmountExpense  | AprovalStatus | Date");
                foreach(Ticket ticket in returnTicketArr){
                    Console.WriteLine(ticket.ID + "   " + ticket.userName + "   " + ticket.description + "    " + ticket.amountExpense + "    " + ticket.approved + "    " + ticket.date);
                }
            }
            else if(ticketAction == "3" && userRole == "manager"){

                List<Ticket> returnTicketArr = DatabaseTicket.getTicket(userName, userRole);
                Console.WriteLine("ID| User | Description | AmountExpense  | AprovalStatus | Date");
                foreach(Ticket ticket in returnTicketArr){
                    Console.WriteLine(ticket.ID + " " + ticket.userName + " " + ticket.description + " " + ticket.amountExpense + " " + ticket.approved + " " + ticket.date);
                }

                Console.WriteLine("-----------------------");
                Console.WriteLine("Please enter the Ticket ID you want to approve: ");
                int ticketIDToApprove = int.Parse(Console.ReadLine());

                DatabaseTicket.approveTicket(ticketIDToApprove);
                
            }
            else if(ticketAction == "x"){
                break;
            }
            else{
                
                Console.WriteLine("Please enter a vaild input");
            }

        }
    }
}