using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace stembowl.Models
{
    public class QADataAccessLayer
    {
        string connectionString = "server=db;port=3306;userid=dbuser;password=dbuserpassword;database=accountowner;";

        public IEnumerable<Question> GetAllQuestions()
        {
            var questions = new List<Question>();

            using(var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                var cmd = new MySql.Data.MySqlClient.MySqlCommand
                ("SELECT QuestionID, Text, Format FROM Questions", con);
                cmd.CommandType = CommandType.Text;

                con.Open();

                var rdrQuestions = cmd.ExecuteReader();

                while(rdrQuestions.Read())
                {
                    var question = new Question();
                    
                    question.QuestionID = rdrQuestions.GetInt32("QuestionID");
                    question.Text = rdrQuestions.GetString("Text");
                    question.Format = (Format)rdrQuestions.GetInt32("Format");
                    question.Answers = GetAnswers(question.QuestionID).ToList();

                    questions.Add(question);
                }
            
            }
            return questions;
        }

        public IEnumerable<Answer> GetAnswers(int QuestionID)
        {
            var answers = new List<Answer>();

            using(var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                var cmd = new MySql.Data.MySqlClient.MySqlCommand
                ("SELECT AnswerID, Text FROM Questions WHERE @QuestionID = QuestionID", con);
                cmd.Parameters.AddWithValue("@QuestionID", QuestionID);
                cmd.CommandType = CommandType.Text;

                con.Open();

                var rdrAnswers = cmd.ExecuteReader();
                while (rdrAnswers.Read())
                {
                    var answer = new Answer();
                    
                    answer.QuestionID = QuestionID;
                    answer.AnswerID = rdrAnswers.GetInt32("AnswerID");
                    answer.Text = rdrAnswers.GetString("Text");

                    answers.Add(answer);
                }

            }
            return answers;
        }
    
        public void AddQuestion(Question question)
        {
            
            using(var con = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
            {
                var cmd = new MySql.Data.MySqlClient.MySqlCommand
                ("INSERT INTO Questions(Format, Text) VALUES(@Format, @Text)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Text", question.Text);
                cmd.Parameters.AddWithValue("@Format", (int) question.Format);

                con.Open();
                cmd.ExecuteNonQuery();

                cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT LAST_INSERT_ID()", con);
                var questionID = Convert.ToInt32(cmd.ExecuteScalar());

                foreach(var answer in question.Answers)
                {

                    cmd = new MySql.Data.MySqlClient.MySqlCommand
                    ("INSERT INTO Answers(QuestionID, Text) VALUES(@QuestionID, @Text)", con);
                    cmd.Parameters.AddWithValue("@QuestionID", questionID);
                    cmd.Parameters.AddWithValue("@Text", answer.Text);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

    }
}