//namespace
using Model;
using Service;


//Login and register process
while(true){

    Console.WriteLine("----------------------------------");
    Console.WriteLine("Are you an existing user? ");
    Console.WriteLine("Y/N: ");
    string isUser = Console.ReadLine();

    if(isUser == "Y" || isUser == "y"){

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
    else if(isUser == "N" || isUser == "n"){

        Console.WriteLine("----------------------------------");
        Console.WriteLine("Do you want to register?");
        Console.WriteLine("Y/N: ");
        string wantRegister = Console.ReadLine();

        if(wantRegister == "Y" || wantRegister == "y"){
            
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Please enter your new user name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Please enter your new password: ");
            string userPassword = Console.ReadLine();
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Are you manager or employee? ");
            string userRole = Console.ReadLine();


            User registerUser = new User(userName, userPassword, userRole);
            
            //register function from service
            ServiceClass.register(registerUser);
            //Automitically login
            ServiceClass.login(registerUser);
            break;
            
        }
        else if(wantRegister == "n" || wantRegister == "N"){
            //If don't want to create an account
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Back to login page");
            
        }
        else{
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Please input your choose correctly");
        }

    }
    else{
        Console.WriteLine("----------------------------------");
        Console.WriteLine("Please input your choose correctly");
    }
    
}

