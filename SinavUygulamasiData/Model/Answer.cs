using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinavUygulamasiData.Model
{
    public class Answer:BaseEntity
    {
        public string Name { get; set; }
        public bool IsTrue { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }

    }
}
