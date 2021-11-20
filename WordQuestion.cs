using System;
using System.Collections.Generic;
using System.Text;

namespace WordGuessingGame
{
    class WordQuestion
    {

        public String Question
        {
            get; set;
        }
        public String Answer
        {
            get; set;
        }

        public WordQuestion(String question, String answer)
        {
            Question = question;
            Answer = answer;
        }
    }
}
