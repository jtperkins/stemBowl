using System.Collections.Generic;

namespace stembowl.Models
{
    public enum Format
    {
        MultipleChoice, ShortAnswer, TrueFalse
    }
    public class Question
    {
        public int QuestionID {get; set;}
        public Format Format {get; set;}
        public string Text {get; set;}
        public List<Answer> Answers {get; set;}
    }
}