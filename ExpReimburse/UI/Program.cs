//namespace
using Model;
using Database;



// Create admin
var userDatabase = new UserDatabase();



//Login and register process
while(true){
    Console.WriteLine("-------------------------------------------------");
    Console.WriteLine("Are you an existing user? ");
    Console.WriteLine("Y/N: ");
    string isUser = Console.ReadLine();

    if(isUser == "Y" || isUser == "y"){

        Console.WriteLine("Please enter your user name: ");
        string userName = Console.ReadLine();
        Console.WriteLine("Please enter your password: ");
        string userPassword = Console.ReadLine();

        // Find User object from UserDB
        User.login(userName, userPassword, userDatabase.UserDB);
        break;
        
    }
    else if(isUser == "N" || isUser == "n"){

        Console.WriteLine("Do you want to register?");
        Console.WriteLine("Y/N: ");
        string wantRegister = Console.ReadLine();

        if(wantRegister == "Y" || wantRegister == "y"){
            
            
            Console.WriteLine("Please enter your new user name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Please enter your new password: ");
            string userPassword = Console.ReadLine();
            Console.WriteLine("Are you manager or employee? ");
            string userRole = Console.ReadLine();


            //New user will ask for create an account
            User newUser = new User(userName, userPassword, userRole);
            //Add new user to DB
            userDatabase.AddUser(userName, newUser);
            //Automatically perform Login
            User.login(userName, userPassword, userDatabase.UserDB);
            break;
            
        }
        else if(wantRegister == "n" || wantRegister == "N"){
            //If don't want to create an account
            Console.WriteLine("Back to login page");
        }
        else{
            Console.WriteLine("Please input your choose correctly");
        }

    }
    else{
        Console.WriteLine("Please input your choose correctly");
    }
}

