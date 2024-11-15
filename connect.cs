using MySql.Data.MySqlClient;


namespace BasketTeam
{
    public class connect
    {
        public MySqlConnection Connection;
        public string Host;
        public string Database;
        public string User;
        public string Password;
        public string ConnectionString;

        public connect()
        {
            Host = "localhost";
            Database = "Team";
            User = "root";
            Password = "";
            
            ConnectionString ="SERVER=" + Host + ";DATABASE=" + Database + ";UID=" + 
                User + ";PASSWORD=" + Password + ";SslMode=None";

            Connection = new MySqlConnection(ConnectionString);
        }
    }
}
