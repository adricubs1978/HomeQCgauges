using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.DB
{
    static class MySQLCast
    {
       
            public static string ReadElement(int index, string type, MySqlDataReader dataread)
            {

                List<string> IntTypes = new List<string> { "INT", "TINYINT", "SMALLINT", "MEDIUMINT", "BIGINT" };
                List<string> FloatTypes = new List<string> { "DOUBLE", "DECIMAL", "FLOAT", "REAL" };
                List<string> StringTypes = new List<string> { "VARCHAR", "TEXT", "CHAR", "TINYTEXT", "MEDIUMTEXT", "LONGTEXT" };

                string Result_str = null;
                 if (dataread.IsDBNull(index))
                 {
                    Result_str = null;
                 }    
                else if (IntTypes.Contains(type))
                {
                    //Cast as an integer
                    Result_str = dataread.GetInt32(index).ToString();
                }
                else if (FloatTypes.Contains(type))
                {
                    Result_str = dataread.GetDouble(index).ToString();
                }
                else if (StringTypes.Contains(type))
                {
                    Result_str = dataread.GetString(index);
                }
                else
                {
                    //if no cast could be found
                    throw new Exception($"DB has a type: '{type} unrecognised by 'ReadElementMySQL' class, handle it to avoid expception");
                };


                return Result_str;
            }



        
    }

}

