using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using FitnessLogger.Models;

namespace FitnessLogger.Classes
{
    public class PostGreSQL
    {

        string DbConnection = "Server=139.162.220.195; Port=5432; User Id=dbadmin; Password=HavreLunsj0112; Database=Databasus;";

        public List<LogRow> Exercises
        {
            get
            {
                return ExerciseList();
            }
        }

        private List<LogRow> ExerciseList()
        {
            List<LogRow> exercises = new List<LogRow>();

            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(DbConnection);
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM fitnesslogger.exercise_log", connection);

                NpgsqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    LogRow logrow = new LogRow();

                    logrow.Id = Convert.ToInt32(dataReader["id"]);
                    logrow.Date = Convert.ToDateTime(dataReader["date"]);
                    logrow.Exercise = dataReader["exercise"].ToString();
                    logrow.Weight = Convert.ToInt32(dataReader["weight"]);
                    logrow.Repetitions = Convert.ToInt32(dataReader["repetitions"]);
                    logrow.Sets = Convert.ToInt32(dataReader["sets"]);
                    logrow.Rest_time = Convert.ToInt32(dataReader["rest_time"]);
                    logrow.Notes = dataReader["notes"].ToString();

                    exercises.Add(logrow);

                }

                connection.Close();

                return exercises;
            }
            catch(Exception msg)
            {
                throw;
            }


        }

        public void AddExercise(LogRow Exercise)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(DbConnection);
                connection.Open();

                string query = "INSERT INTO fitnesslogger.exercise_log VALUES(@Id, @Date, @Exercise, @Weight, @Repetitions, @Sets, @Rest_time, @Notes)";

                int NextId = GetNextId();

                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                command.Parameters.Add(new NpgsqlParameter("Id", NextId));
                command.Parameters.Add(new NpgsqlParameter("Date", Exercise.Date));
                command.Parameters.Add(new NpgsqlParameter("Exercise", Exercise.Exercise));
                command.Parameters.Add(new NpgsqlParameter("Weight", Exercise.Weight));
                command.Parameters.Add(new NpgsqlParameter("Repetitions", Exercise.Repetitions));
                command.Parameters.Add(new NpgsqlParameter("Sets", Exercise.Sets));
                command.Parameters.Add(new NpgsqlParameter("Rest_time", Exercise.Rest_time));
                command.Parameters.Add(new NpgsqlParameter("Notes", Exercise.Notes));

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteExercise(int id)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(DbConnection);
                connection.Open();

                string query = "DELETE FROM fitnesslogger.exercise_log WHERE id = " + id;

                NpgsqlCommand command = new NpgsqlCommand(query, connection);

                command.ExecuteNonQuery();

                connection.Close();
            }
            catch
            {
                throw;
            }
        }

        private int GetNextId()
        {
            int NextId;

            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(DbConnection);
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand("SELECT Max(id) FROM fitnesslogger.exercise_log", connection);

                NextId = Convert.ToInt32(command.ExecuteScalar());

                connection.Close();

                return NextId + 1;
            }
            catch (Exception msg)
            {
                throw;
            }
        }

    }
}