using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKidAPI.Constants
{
    public class ApplicationConfig
    {
        public static int ServerPort = 50828;
        public static readonly string ServerName = "localhost"+":"+ServerPort.ToString();

        public const string API_KEY = "d2874bf65143333fa6155a417209bec39f73f2b1a0a9d6d1db2e4eedd5087114";
        public const string API_KEY_NAME = "APIKey";

        public static readonly string AdminRole = "Admin";
        public static readonly string TeacherRole = "Teacher";
        public static readonly string StudentRole = "Student";

        public static readonly string ListentCategory = "Listening";
        public static readonly string ReadingCategory = "Reading";
        public static readonly string SpeakingCategory = "Speaking";
        public static readonly string WritingCategory = "Writing";
        public static readonly string VocabularyCategory = "Vocabulary";
        public static readonly string WatchingCategory = "Watching";
        public static readonly string GrammarCategory = "Grammar";
        public static readonly string SpellCategory = "Spell";

        public static readonly string AdminUserName = "Admin";
        public static readonly string AdminPassword = "1234566";

        public static readonly string BossEmail = "englishforkidsprivate@gmail.com";
        public static readonly string BossEmailPassword = "abc12345678";
        public static readonly string BossEmailName = "English For Kids";
        public static readonly string EmailHost = "smtp.gmail.com";
    }
}