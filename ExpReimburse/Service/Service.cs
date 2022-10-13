using Model;
using Database;

namespace Service;

public class ServiceClass{

    //login function
    public static void login(string userName, string userPassword){

        User returnUser = DatabaseUserClass.getUsers(userName, userPassword);

        try{

            Console.WriteLine("Login successfully : " + returnUser.userName + " " + returnUser.userRole);
            Console.WriteLine("---------------------------");

            TicketAction(userName);
            
              
        }catch(NullReferenceException e){

            Console.WriteLine("Username or password is NOT correct");
        }
        
        
    }

    // register function
    public static void register(string userName, string userPassword, string userRole){

        DatabaseUserClass.setUser(userName, userPassword, userRole);

    }


    //After login successful
    public static void TicketAction(string userName){
        
        Console.WriteLine("What does you want to do next?");
        Console.WriteLine("[1]: Submit a Expense Reimbursement Ticket");
        Console.WriteLine("[2]: Review Expense Reimbursement Tickets history");
        string ticketAction = Console.ReadLine();

        if(ticketAction == "1"){

            Console.WriteLine("Please provide a description about ticket: ");
            string description = Console.ReadLine();
            Console.WriteLine("Please enter amount of your expensive: ");
            string strAmountExp = Console.ReadLine();
            double amountExp = double.Parse(strAmountExp);
            
            // sumbit ticket to DB
            DatabaseUserClass.submitTicket(userName, description, amountExp);

        }
        else if(ticketAction == "2"){

            
        }
        else{
            
            Console.WriteLine("Please enter a vaild input");
        }
    }
}