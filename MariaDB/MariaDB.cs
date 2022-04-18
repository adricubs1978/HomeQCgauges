using MySqlConnector;
using System;
using MariaDB.Classes;
using System.Collections.Generic;


namespace MariaDB
{
    public class MariaDB
    {
        private string _IP;
        private UInt32 _port;
        private string _user;
        private string _password;
        private string _database;
        private MySqlConnection _connection;


        public MariaDB(string IP, UInt32 Port, String User, String Password, String Database)
        {
            // Creating the instance should provide all the required info for connecting, and open and close connection + test connection
            _IP = IP;
            _port = Port;
            _user = User;
            _password = Password;
            _database = Database;

            string _connection_str = $"datasource={_IP};port={_port.ToString()};username={_user};pwd={_password};database={_database}";

            _connection = new MySqlConnection(_connection_str);
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
        public QueryResults ReadQuery(string Query,bool AllowEmpty)
        {
            QueryResults QueryResults = new QueryResults();
            List<List<string>> Results2D = new List<List<string>>();
            

            MySqlCommand ReadQueryCommand = new MySqlCommand(Query, _connection);
            MySqlDataReader dataread = ReadQueryCommand.ExecuteReader();
            if (dataread.HasRows! && AllowEmpty!)
            {
                throw new Exception($"Query '{Query}' did not give any results back");
            } else
            {
                //Read column names
                // Read full row
                for (int i = 0; i < dataread.FieldCount; i++)
                {
                    //Read all column names
                    QueryResults.ColumnNames.Add(dataread.GetName(i));
                }

                while (dataread.Read())
                {
                    // Read full row

                    List<string> RowData=new();//This is the list inside Results2D

                    for (int i = 0; i < dataread.FieldCount; i++)
                    {
                        //Read all columns in the row
                        RowData.Add(dataread.GetString(i));
                        
                    }
                    QueryResults.Results2D.Add(RowData);
                    RowData.Clear();
             
                }
            }
          
            return QueryResults;
        }
    }
}
