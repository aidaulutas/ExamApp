﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavUygulamasiData.Model
{
    public class ExamQuestion : BaseEntity
    {
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
