using UserNameSp;

namespace UserDBNameSp;

public class UserDatabase
{
    public Dictionary<string,User> UserDB;

    public UserDatabase(){

        UserDB = new Dictionary<string,User>();
    }

    public void AddUser(string key, User user){

        UserDB.Add(user.userName, user);
    }
}
