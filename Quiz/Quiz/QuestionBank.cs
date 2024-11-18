using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class QuestionBank
    {
        public string Question { set; get; }
        public string Option1 {  set; get; }
        public string Option2 { set; get; }
        public string Option3 { set; get; }
        public string Option4 { set; get; }
        public int CorrectOption {  set; get; }
    }
}
