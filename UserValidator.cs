using Novell.Directory.Ldap;

public class UserValidator
{

    public bool ValidateUser(string username, string password)
    {
        try
        {
            using (var connection = new LdapConnection() { SecureSocketLayer = false })
            {
                connection.Connect("localhost", 3893);
                connection.Bind(username, password);

                if (connection.Bound)
                    return true;
            }
        }
        catch (LdapException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return false;
    }

}