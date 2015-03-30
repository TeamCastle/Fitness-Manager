namespace Fitness.Data.Repositories.DietsFromDbRepository
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.IO;

    /// <summary>
    /// Store all diets in database
    /// </summary>
    public class DietsFromDbRepository
    {
        /// <summary>
        /// Path to Database file that contains all diets
        /// </summary>
        private const string DbFilePath = "../../../Fitness.Data/Database/Diets.mdb";

        /// <summary>
        /// Connection string used to open the database
        /// </summary>
        private const string DbConnectionString = @"provider=microsoft.jet.oledb.4.0;data source=" + DbFilePath;

        /// <summary>
        /// Collection of diets
        /// </summary>
        private HashSet<KeyValuePair<string, int>> diets = new HashSet<KeyValuePair<string, int>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DietsFromDbRepository"/> class.
        /// </summary>
        public DietsFromDbRepository()
        {
            this.Diets = this.ReadDietsFromDb();
        }

        /// <summary>
        /// Gets or sets the collections of diets
        /// </summary>
        public IList<KeyValuePair<string, int>> Diets
        {
            get
            {
                return new List<KeyValuePair<string, int>>(this.diets);
            }

            set
            {
                this.diets = new HashSet<KeyValuePair<string, int>>(value);
            }
        }

        /// <summary>
        /// Insert some player in the collection of diets in database
        /// </summary>
        /// <param name="player">The player</param>
        public void InsertPlayerInDb(KeyValuePair<string, int> player)
        {
            this.CheckDbFilePath();

            using (var connection = new OleDbConnection(DbConnectionString))
            {
                var isExistNameInDb = false;
                for (int i = 0; i < this.Diets.Count; i++)
                {
                    if (this.Diets[i].Key == player.Key)
                    {
                        isExistNameInDb = true;
                        if (player.Value < this.Diets[i].Value)
                        {
                            this.UpdateDietsDb(connection, player);
                        }

                        break;
                    }
                }

                if (!isExistNameInDb)
                {
                    var insertString = "INSERT INTO Diets (Diets, Mistakes) values(@Diets, @Mistakes)";
                    var oleDbCommand = new OleDbCommand(insertString, connection);
                    oleDbCommand.CommandType = CommandType.Text;
                    oleDbCommand.Parameters.AddWithValue("@Diets", player.Key);
                    oleDbCommand.Parameters.AddWithValue("@Mistakes", player.Value);

                    connection.Open();
                    oleDbCommand.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Gets the collection of diets from database
        /// </summary>
        /// <returns>Collection of KeyValuePair diets</returns>
        private IList<KeyValuePair<string, int>> ReadDietsFromDb()
        {
            this.CheckDbFilePath();

            var dietsCollection = new List<KeyValuePair<string, int>>();
            var selectString = "SELECT * FROM Diets";

            using (var connection = new OleDbConnection(DbConnectionString))
            {
                connection.Open();
                var oleDbCommand = new OleDbCommand(selectString, connection);
                oleDbCommand.ExecuteNonQuery();

                using (var dataReader = oleDbCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        string playerName = dataReader["Diets"].ToString();
                        int playerMistakes = int.Parse(dataReader["Mistakes"].ToString());

                        KeyValuePair<string, int> player =
                            new KeyValuePair<string, int>(playerName, playerMistakes);

                        dietsCollection.Add(player);
                    }
                }
            }

            return dietsCollection;
        }

        /// <summary>
        /// Update the information about some player in the database
        /// </summary>
        /// <param name="connection">Database connection</param>
        /// <param name="player">The updated player</param>
        private void UpdateDietsDb(OleDbConnection connection, KeyValuePair<string, int> player)
        {
            connection.Open();
            var updateString = "UPDATE Diets SET Mistakes = @mistakes WHERE Diets = @diet";

            OleDbCommand oleDbCommand = new OleDbCommand(updateString, connection);
            oleDbCommand.Parameters.AddWithValue("@mistakes", player.Value);
            oleDbCommand.Parameters.AddWithValue("@player", player.Key);
            oleDbCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Check whether the database file with the diets exist
        /// </summary>
        private void CheckDbFilePath()
        {
            if (!File.Exists(DbFilePath))
            {
                string fullFilePath = Path.GetFullPath(DbFilePath);
                string exceptionMessage = string.Format("Database file: \"{0}\" does not exists.", fullFilePath);
                throw new FileNotFoundException(exceptionMessage);
            }
        }
    }
}