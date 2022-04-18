using MySqlConnector;
using System;
using System.Collections.Generic;


namespace Repository.DB
{
    
    public class MariaDB
    {
        public string IP;
        public UInt32 Port;
        public string User;
        private string _password;
        public string Database;
        private MySqlConnection _connection;
        private UInt32 _timeout_sec;
        
        public bool Connected = false;
      


        public MariaDB(string IP_in, UInt32 Port_in, String User_in, String Password, String Database_in, UInt32 timeout_sec)
        {
            // Creating the instance should provide all the required info for connecting, and open and close connection + test connection
            IP = IP_in;
            Port = Port_in;
            User = User_in;
            _password = Password;
            Database = Database_in;
            _timeout_sec = timeout_sec;

            Connected=false;

            string _connection_str = $"datasource={IP};port={Port};username={User};pwd={_password};database={Database};Connect Timeout={_timeout_sec}";


            _connection = new MySqlConnection(_connection_str);
            //MySqlConnection _connection = new MySqlConnection("datasource=192.168.0.3;port=3306;username=Acub;pwd=@Aa16621662;database=QCGauges");
            try
            {
                _connection.Open();
            }
            catch
            {
                throw new AccessViolationException($"Could not connect to server- IP{IP}/{Port.ToString()} - Database: {Database} -- User: {User} ");
            }
            if (_connection.Ping())
            {
                //Do nothing, test passed
                Connected =true;
            }
            else 
            {
                Connected = false;
                throw new Exception($"Server/Database could not be pinged - IP{IP}/{Port.ToString()} - Database: {Database} -- User: {User} ");
            }
                ;
            _connection.Close();
          
        }
        private void OpenConnection()
        {
            _connection.Open();
        }
        private void CloseConnection()
        {
            _connection.Close();
        }
        public QueryResults ReadQuery(string Query,bool AllowEmpty)
        {
            QueryResults QueryResults = new QueryResults();

            List<List<string>> Results2D = new List<List<string>>();

            OpenConnection();
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
                    QueryResults.ColumnDataTypes.Add(dataread.GetDataTypeName(i));
                }

                while (dataread.Read())
                {
                    // Read full row
                    

                    List<string> RowData=new List<string>();//This is the list inside Results2D

                    for (int i = 0; i < dataread.FieldCount; i++)
                    {
                        //Read all columns in the row
                        string _datatype = QueryResults.ColumnDataTypes[i];
                        RowData.Add(MySQLCast.ReadElement(i,_datatype,dataread));
                        
                    }
                    QueryResults.Results2D.Add(RowData);
                    
             
                }
            }
            CloseConnection();
            List<string> Row0 = QueryResults.Results2D[0];
            string Item00 = Row0[0];
            return QueryResults;
        }

    }
}
