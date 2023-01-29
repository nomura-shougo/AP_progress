using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MariaDB
{
    internal class MariaDBHelper
    {
        private static string connectionString = DotNetEnv.Env.GetString("CONNECTION_STRING");

        internal static IReadOnlyList<T> GetData<T>(
            MySqlCommand selectCommand,
            Func<MySqlDataReader, T> createEntity)
        {
            var result = new List<T>();
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                selectCommand.Connection = connection;

                using (var reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(createEntity(reader));
                    }
                }
            }

            return result;
        }

        internal static T? GetSingleData<T>(
            MySqlCommand selectCommand,
            Func<MySqlDataReader, T> createEntity
            )
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                selectCommand.Connection = connection;

                using (var reader = selectCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return createEntity(reader);
                    }
                }
            }
            return default(T);
        }

        internal static void Excute(MySqlCommand mySqlCommand)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                mySqlCommand.Connection = connection;
                connection.Open();
                mySqlCommand.ExecuteNonQuery();
            }
        }
        internal static void Upsert(
            MySqlCommand insertCommand,
            MySqlCommand updateCommand
           )
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                updateCommand.Connection = connection;
                connection.Open();

                if (updateCommand.ExecuteNonQuery() < 1)
                {
                    insertCommand.Connection = connection;
                    insertCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
