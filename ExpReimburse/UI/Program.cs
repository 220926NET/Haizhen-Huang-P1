//namespace
using Model;
using Service;


//Login and register process

    Console.WriteLine("Welcome to Expense Reimbursement System!");

while(true){

    Console.WriteLine("----------------------------------");
    Console.WriteLine("Please enter a number for you action: ");
    Console.WriteLine("[1]: Login into Expense Reimburse System");
    Console.WriteLine("[2]: Register as a new user");
    Console.WriteLine("[x]: Exit");

    string userAction = Console.ReadLine();

    if(userAction == "1"){

        Console.WriteLine("----------------------------------");
        Console.WriteLine("Please enter your user name: ");
        string userName = Console.ReadLine();
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Please enter your password: ");
        string userPassword = Console.ReadLine();

        User loginUser = new User(userName, userPassword);
        
        //login function service
        ServiceClass.login(loginUser);
        break;
        
    }
    else if(userAction == "2"){
                        
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Please enter your new user name: ");
        string userName = Console.ReadLine();
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Please enter your new password: ");
        string userPassword = Console.ReadLine();
        
        while(true){

            Console.WriteLine("----------------------------------");
            Console.WriteLine("Are you manager or employee? ");
            Console.WriteLine("Enter [0] for manager");
            Console.WriteLine("Enter [1] for manager");
            string userRole = Console.ReadLine();

            if(userRole == "0"){

                userRole = "manager";
                User registerUser = new User(userName, userPassword, userRole);

                //register function from service
                ServiceClass.register(registerUser);
                //Automitically login
                ServiceClass.login(registerUser);
                break;
                
            }
            else if(userRole == "1"){

                userRole = "employee";
                User registerUser = new User(userName, userPassword, userRole);

                //register function from service
                ServiceClass.register(registerUser);
                //Automitically login
                ServiceClass.login(registerUser);
                break;
            }
            else{

                Console.WriteLine("Your input is invalid");
            }
            
            
            break;
            
        }
            
    }
    else if(userAction == "x"){

        break;
    }
    else{

        Console.WriteLine("----------------------------------");
        Console.WriteLine("Your input is invalid");
    }
    
}

