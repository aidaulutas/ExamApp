using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavUygulamasiData.Model
{
    public  class Exam : BaseEntity
    {
        public string Name { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }
        public int DifficultyLevelId { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public List<ExamQuestion> ExamQuestion { get; set; }



    }
}
