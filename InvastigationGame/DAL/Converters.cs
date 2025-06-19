using MySql.Data.MySqlClient;

namespace InvastigationGame.DAL
{
    public class Converters
    {
        public static Player ConvertFromSQLToPlayer(MySqlDataReader reader)
        {
            string name = reader.GetString("name");
            int level = reader.GetInt16("level");

            return new Player(name, level);
        }


    }
}
