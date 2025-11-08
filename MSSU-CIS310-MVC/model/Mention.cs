using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSU_CIS310_MVC.model
{
    class Mention
    {
        private string book;
        private int mentionCount;

        public Mention(string book, int mentionCount)
        {
            this.book = book;
            this.mentionCount = mentionCount;
        }

        public string getBookName
        {
            get { return book; }
        }

        public int MentionCount
        {
            get { return mentionCount; }
        }

        public override string ToString()
        {
            return getBookName + ": " + MentionCount + " mention(s)";
        }
    }
}
