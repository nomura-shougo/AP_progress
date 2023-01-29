using Domain.Entities;
using Domain.Repositories;
using MySql.Data.MySqlClient;

namespace Infrastructure.MariaDB
{
    public sealed class ExamResultsMariaDB : IExamResultsRepository
    {
        public IReadOnlyList<ExamResultsEntity> GetData()
        {
            MySqlCommand command = GetAllSqlCommand();

            return MariaDBHelper.GetData(command,
                reader =>
                {
                    return CreateExamResultsEntity(
                       reader["exam_year"],
                       reader["haruaki"],
                       reader["solved_date"],
                       reader["score"]
                    );
                });
        }

        public ExamResultsEntity? GetSingleData(ExamResultsEntity examResults)
        {
            MySqlCommand command = GetSingleSqlCommand(examResults);

            return MariaDBHelper.GetSingleData(command,
                reader =>
                {
                    return CreateExamResultsEntity(
                       reader["exam_year"],
                       reader["haruaki"],
                       reader["solved_date"],
                       reader["score"]
                    );
                }
            );

        }

        public ExamResultsEntity CreateExamResultsEntity(
            object examYear,
            object haruaki,
            object solvedDate,
            object score
        )
        {
            return new ExamResultsEntity(
                            Convert.ToInt32(examYear),
                            Convert.ToInt32(haruaki),
                            Convert.ToDateTime(solvedDate),
                            Convert.ToInt32(score)
                        );

        }
        public void Save(ExamResultsEntity examResults)
        {
            MySqlCommand insertCommand = InsertSqlCommand(examResults);
            MySqlCommand updateCommand = UpdateSqlCommand(examResults);

            MariaDBHelper.Upsert(
                insertCommand,
                updateCommand
            );
        }
        private MySqlCommand GetAllSqlCommand()
        {
            MySqlCommand command = new MySqlCommand();

            string sql = @"
select
    exam_year,
    haruaki,
    solved_date,
    score
from
    exam_results
order by
    solved_date
            ";
            command.CommandText = sql;

            return command;
        }

        private MySqlCommand GetSingleSqlCommand(ExamResultsEntity examResults)
        {
            MySqlCommand command = new MySqlCommand();

            string sql = @"
            select
                exam_year,
                haruaki,
                solved_date,
                score
            from
                exam_results
            WHERE
                1 = 1
                and exam_year = @exam_year
                and haruaki = @haruaki
                and solved_date = @solved_date
";
            command.CommandText = sql;

            var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@exam_year",examResults.ExamYear.Value),
                new MySqlParameter("@haruaki",examResults.Haruaki.Value),
                new MySqlParameter("@solved_date",examResults.SolvedDate.Value),
            };

            command.Parameters.AddRange(parameters.ToArray());

            return command;
        }

        private MySqlCommand InsertSqlCommand(ExamResultsEntity examResults)
        {
            MySqlCommand command = new MySqlCommand();

            string sql = @"
            insert into exam_results
            (
                exam_year,
                haruaki,
                solved_date,
                score
            )
            values
            (
                @exam_year,
                @haruaki,
                @solved_date,
                @score
            )
            ";
            command.CommandText = sql;

            var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@exam_year",examResults.ExamYear.Value),
                new MySqlParameter("@haruaki",examResults.Haruaki.Value),
                new MySqlParameter("@solved_date",examResults.SolvedDate.Value),
                new MySqlParameter("@score",examResults.Score.Value),
            };

            command.Parameters.AddRange(parameters.ToArray());

            return command;

        }
        private MySqlCommand UpdateSqlCommand(ExamResultsEntity examResults)
        {
            MySqlCommand command = new MySqlCommand();
            string sql = @"
            update
                exam_results
            set
                score = @score
            where
                exam_year = @exam_year
                and haruaki = @haruaki
                and solved_date = @solved_date
            ";
            command.CommandText = sql;

            var parameters = new List<MySqlParameter>
            {
                new MySqlParameter("@exam_year",examResults.ExamYear.Value),
                new MySqlParameter("@haruaki",examResults.Haruaki.Value),
                new MySqlParameter("@solved_date",examResults.SolvedDate.Value),
                new MySqlParameter("@score",examResults.Score.Value),
            };

            command.Parameters.AddRange(parameters.ToArray());

            return command;
        }
    }
}
