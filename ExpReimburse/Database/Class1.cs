using Model;

namespace Database;

public class UserDatabase
{


    public Dictionary<string,User> UserDB;

    public UserDatabase(){

        UserDB = new Dictionary<string, User>(){ {"Haizhen", new User("Haizhen", "000", "Manager")} };

    }

    public void AddUser(string key, User user){

        UserDB.Add(user.userName, user);
    }
}
