namespace Fitness.Data.Access
{
    using System.Collections.Generic;
    using System.Data.OleDb;

    /// <summary>
    /// Helper class for Database access.
    /// </summary>
    public static class DbAccess
    {
        private const string ConnectionFormat = "provider=microsoft.jet.oledb.4.0;data source={0}";

        /// <summary>
        /// Gets the data from some database file.
        /// </summary>
        /// <param name="filePath">The path to the database file.</param>
        /// <param name="queryString">The query string.</param>
        /// <returns>Returns a list with all requested data.</returns>
        public static List<List<object>> GetData(string filePath, string queryString)
        {
            var result = new List<List<object>>();
            var connectionString = string.Format(ConnectionFormat, filePath);
            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                var command = new OleDbCommand(queryString, connection);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var obj = new List<object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            obj.Add(reader.GetValue(i));
                        }

                        result.Add(obj);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Insert, update or delete some database file data.
        /// </summary>
        /// <param name="filePath">The path to the database file.</param>
        /// <param name="queryString">The query string.</param>
        public static void ManipulateData(string filePath, string queryString)
        {
            var connectionString = string.Format(ConnectionFormat, filePath);
            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                var command = new OleDbCommand(queryString, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
