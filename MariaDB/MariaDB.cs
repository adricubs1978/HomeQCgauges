using MySqlConnector;
using System;

namespace MariaDB
{
    public class MariaDB
    {
        private string _IP;
        private UInt32 _port;
        private string _user;
        private string _password;
        private string _database;

        
        public MariaDB(string IP, UInt32 Port, String User, String Password, String Database)
        {
            // Creating the instance should provide all the required info for connecting, and open and close connection + test connection
            _IP = IP;
            _port = Port;
            _user = User;
            _password = Password;
            _database = Database;

            string _connection_str = $"datasource={_IP};port={_port.ToString()};username={_user};pwd={_password};database={_database}";
            MySqlConnection _connection = new MySqlConnection(_connection_str);
            _connection.Open();
            if (_connection.Ping())
            {
                //Do nothing, test passed
            }
            else 
            {
                throw new Exception($"Server/Database could not be pinged - IP{_IP}/{_port.ToString()} - Database: {_database} -- User: {_user} ");
            }
                ;
            _connection.Close();


        }
    }
}
