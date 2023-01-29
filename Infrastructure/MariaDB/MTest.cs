using MySql.Data.MySqlClient;

namespace Infrastructure.MariaDB
{
    public class MTest
    {
        public MTest()
        {
        }
        public static string? Get()
        {
            DotNetEnv.Env.TraversePath().Load();
            // 接続文字列
            var connectionString = DotNetEnv.Env.GetString("CONNECTION_STRING");

            // 実行するSQL
            var sql = "select * from exam_results";
            var res = "";

            // 接続・SQL実行に必要なインスタンスを生成
            using (var connection = new MySqlConnection(connectionString))
            {
                using (var command = new MySqlCommand(sql, connection))
                {
                    // 接続開始
                    connection.Open();

                    // SELECT文の実行
                    using (var reader = command.ExecuteReader())
                    {
                        // 1行ずつ読み取ってコンソールに表示
                        while (reader.Read())
                        {
                            res = Convert.ToString(reader["exam_year"]);
                        }
                    }
                }
            }
            return res;
        }
    }
}
