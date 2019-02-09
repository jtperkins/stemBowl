using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace stembowl.Models
{
    public class TeamAnswers
    {
        public TeamAnswers(){}
        public TeamAnswers(Question question, Team team)
        {
            TeamID = team.TeamID;
            QuestionID = question.QuestionID;
        }

        public string TeamAnswersID {get; set;}
        public string TeamID {get; set;}
        [ForeignKey("Question")]
        public int QuestionID {get; set;}
        public Question Question {get; set;}
        public string Answer {get; set;}
        public bool Correct {get; set;}

    }
}