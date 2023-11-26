﻿namespace QuizzApp
{
    internal class FillInTheBlankQuestion : Question
    {
        public string Answer {  get; set; }

        public FillInTheBlankQuestion(string questionText, string answer, int score) : base(questionText, score) {
            this.Answer = answer;
         }
    }
}