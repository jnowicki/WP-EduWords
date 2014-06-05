using System.Collections.Generic;
using System;

namespace EduWords
{
    public class Tag : IEquatable<Tag>
    {
        public int id { get; set; }
        public string name { get; set; }
        public object language_user_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public int user_id { get; set; }
        public bool Equals(Tag other)
        {
            if (this.name == other.name) return true;
            else return false;
        }
    }

    public class Word
    {
        public int id { get; set; }
        public string namelanguage1 { get; set; }
        public string namelanguage2 { get; set; }
        public List<Tag> tags { get; set; }
        public int language1_id { get; set; }
        public int language2_id { get; set; }
        public string url { get; set; }
    }

    public class RootObject
    {
        public List<Word> words { get; set; }
    }

    public class QuestionAnswer
    {
        public string question;
        public string answer;
        public QuestionAnswer(string question, string answer)
        {
            this.question = question;
            this.answer = answer;
        }
    }
}