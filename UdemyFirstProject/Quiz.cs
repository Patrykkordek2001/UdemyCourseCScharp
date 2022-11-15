using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UdemyFirstProject
{
    class Quiz
    {
        public List<Question> Questions { get; set; }

        public Quiz()
        {
            LoadQuestionsFromFile("questions.txt");
        }
        private void LoadQuestionsFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var counter = 0;
            Questions = new List<Question>();
            var currentQuestion = new Question();

            foreach(var line in lines)
            {
                if (counter == 6)
                {
                    counter = 0;
                }
                if (counter == 0)
                {
                    currentQuestion.Title = line;
                }
                if (counter == 1)
                {
                    currentQuestion.AnswerA = line;
                }
                if (counter == 2)
                {
                    currentQuestion.AnswerB = line;
                }
                if (counter == 3)
                {
                    currentQuestion.AnswerC = line;
                }
                if (counter == 4)
                {
                    currentQuestion.AnswerD = line;
                }
                if (counter == 5)
                {
                    currentQuestion.RightAnswer = line[0].ToString();
                    currentQuestion.Score = int.Parse(line[1].ToString());

                    var newQuestion = new Question
                    {
                        Title = currentQuestion.Title,
                        AnswerA = currentQuestion.AnswerA,
                        AnswerB = currentQuestion.AnswerB,
                        AnswerC = currentQuestion.AnswerC,
                        AnswerD = currentQuestion.AnswerD,
                        RightAnswer = currentQuestion.RightAnswer,
                        Score = currentQuestion.Score

                    };
                    Questions.Add(newQuestion);
                }
                
                
                counter++;

            }

        }
    }
}
