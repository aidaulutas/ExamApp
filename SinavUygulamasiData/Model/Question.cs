using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SinavUygulamasiData.Model
{
    public class Question : BaseEntity
    {
        public string Description { get; set; }
        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<Answer> Answers { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int DifficultyLevelId { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public int Point { get; set; }

    }
}