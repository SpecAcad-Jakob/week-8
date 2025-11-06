using MySql.Data.MySqlClient;
using W3_REST_API;

namespace W3___REST_API {
    public class DatabaseHandler {
        private DatabaseCreator databaseCreator = new DatabaseCreator();
        private DatabaseConnector DatabaseConnector;

        public DatabaseHandler(DatabaseConnector databaseConnector) {
            this.DatabaseConnector = databaseConnector;
            databaseConnector.connect();
        }


        public int createDatabase(String dataBaseName) {
            MySqlCommand command = new MySqlCommand();
            command.Connection = DatabaseConnector.connection;
            command.CommandText = $"CREATE DATABASE IF NOT EXISTS {dataBaseName};";

            int num = command.ExecuteNonQuery();

            DatabaseConnector.DatabaseName = dataBaseName;
            return num;
        }

        public int CreateTable(String tableName) {
            String queryString = $"CREATE TABLE IF NOT EXISTS {tableName} (" +
                "ID INT PRIMARY KEY AUTO_INCREMENT," +
                "name VARCHAR(255) NOT NULL UNIQUE," +
                "mfr VARCHAR(255)," +
                "type VARCHAR(255)," +
                "calories INT," +
                "protein INT," +
                "fat INT," +
                "sodium INT," +
                "fiber FLOAT," +
                "carbo FLOAT," +
                "sugars INT," +
                "potass INT," +
                "vitamins INT," +
                "shelf INT," +
                "weight FLOAT," +
                "cups FLOAT," +
                "rating VARCHAR(255));";

            MySqlCommand command = new MySqlCommand();
            command.Connection = DatabaseConnector.connection;
            command.CommandText = queryString;

            int num = command.ExecuteNonQuery();
            return num;
        }
    }
}
