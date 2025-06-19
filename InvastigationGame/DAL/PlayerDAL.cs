using InvastigationGame.MySQL;
using MySql.Data.MySqlClient;
using InvastigationGame.DAL;

namespace InvastigationGame.PlayerDal
{
    public class PlayerDAL
    {
        public SQLServer SQL;

        public PlayerDAL()
        {
            this.SQL = new SQLServer();
        }

        public void AddPlayer(Player player)
        {
            try
            {
                MySqlConnection connection = this.SQL.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO players (" +
                                                    "name," +
                                                    "level) " +
                                                    "VALUES (" +
                                                    "@name," +
                                                    "@level)", connection);
                cmd.Parameters.AddWithValue(@"name", player.Name);
                cmd.Parameters.AddWithValue(@"level", player.Level);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.SQL.CloseConnection();
            }
        }

        public void UpdateLevel(Player player)
        {
            try
            {
                MySqlConnection connection = this.SQL.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("UPDATE players " +
                                                    "SET level = @level " +
                                                    "WHERE name = @name", connection);
                cmd.Parameters.AddWithValue(@"level", player.Level);
                cmd.Parameters.AddWithValue(@"name", player.Name);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.SQL.CloseConnection();
            }
        }

    public Player FindByName(string Name)
        {
            MySqlDataReader reader = null;
            Player player = null;

            try
            {
                MySqlConnection connection = this.SQL.OpenConnection();
                MySqlCommand cmd = new MySqlCommand("SELECT * " +
                                                    "FROM players " +
                                                    "WHERE name = @name", connection);
                cmd.Parameters.AddWithValue(@"name", Name);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    player = Converters.ConvertFromSQLToPlayer(reader);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                this.SQL.CloseConnection();
            }
            return player;
        }
    }
}
