using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace W3_REST_API {
    public class DatabaseConnector {
        public MySqlConnection connection;

        public String Server { get; set; } = "";
        private String _databaseName = "";
        public String DatabaseName { get { return _databaseName; } set { _databaseName = value; connection.ConnectionString = $"server={Server};uid={Username};pwd={Password};database={DatabaseName}"; } }
        public String Username { get; set; } = "";
        public String Password { get; set; } = "";
        //public String TableName { get; set; }

        /// <summary>
        /// Create new DatabaseConnector object. 
        /// Consider using overload constructor with table name.
        /// </summary>
        public DatabaseConnector() {
        }

        /// <summary>
        /// Create new DatabaseConnector object with connection to given table.
        /// </summary>
        /// <param name="tableName">Name of table as it exists in database. 
        /// Typically NOT case sentitive.</param>
        /*public DatabaseConnector(String tableName) {
            this.TableName = tableName;
        }*/

        /// <summary>
        /// Statically form connection to MySQL database. 
        /// All instances of this class use same database connection.
        /// </summary>
        public void connect() {
            connection = new MySqlConnection();
            
            string connectionString = $"server={Server};uid={Username};pwd={Password}" +
                /*$";database={DatabaseName}" +*/
                $"";
            connection.ConnectionString = connectionString;
            Console.WriteLine("DEBUG: " + connectionString);
            Console.WriteLine("DEBUG: " + connection.ConnectionString);
            connection.Open();
        }

        /// <summary>
        /// Create new item in selected table.
        /// Tests if item has required number of fields, and tries to push to table in database.
        /// </summary>
        /// <param name="tableRow">List of objects to push to table as a row of columns.</param>
        /// <returns>True if successful. False if unsuccessful.</returns>
        /*public Boolean createDatabase(Object[] tableRow, Boolean allowUpdateInstead) {
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = $"SELECT DATA_TYPE FROM information_schema.COLUMNS WHERE TABLE_NAME = '{TableName}' AND NOT COLUMN_NAME = 'ID'";

            MySqlDataReader reader = command.ExecuteReader();

            //  Put data reader into datatable, such that actions can be performed on data, like simply getting number of rows.
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            //  Cannot createDatabase entry with ID, so only accept if one column, presumably ID, is missing?
            if (tableRow.Length == dataTable.Rows.Count) {
                throw new NotImplementedException();

                //  Format command.
                String commandTextCompound_values = "0, ";
                for (int i = 0; i < tableRow.Length; i++) {
                    //  SQL command just takes a string. Do I not even need to format into objects of various types?
                    commandTextCompound_values += tableRow[i].ToString() + (i < tableRow.Length - 1 ? ", " : "");
                }
                String commandTextCompound = $"INSERT INTO {TableName} ({commandTextCompound_values})";

                command.CommandText = commandTextCompound;
                reader = command.ExecuteReader();

                return true;
            } else if (tableRow.Length == dataTable.Rows.Count + 1 && allowUpdateInstead) {
                //  If ID is NOT missing, as above, and update is allowed in its stead as per the assignment, try update.
                return update(tableRow);
            } else {
                return false;
            }
        }*/

        /// <summary>
        /// Read all lines from selected table.
        /// </summary>
        /// <returns>Collection of collections of object; a list of rows of columns</returns>
        /*public List<Object[]> readAll() {
            MySqlCommand command = new MySqlCommand();
            command.CommandText = $"SELECT * FROM {TableName}";
            command.Connection = connection;

            MySqlDataReader reader = command.ExecuteReader();
            List<Object[]> table = new List<object[]>();
            while (reader.Read()) {
                Console.WriteLine(reader);
                
                /*
                table.Add(reader);
                
            }

            return null;
        }*/

        public Boolean update(Object[] tableRow) {
            throw new NotImplementedException();
        }

        public Boolean delete(Object primaryKeyOfDatabase) {
            throw new NotImplementedException();
        }

    }
}
