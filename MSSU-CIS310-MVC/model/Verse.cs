using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSU_CIS310_MVC.model
{
    public class Verse
    {
        private string id;
        private string bookName;
        private int chapterNumber;
        private int verseNumber;
        private string text;

        public Verse(string id, string bookName, int chapterNumber, int verseNumber, string text)
        {
            this.id = id;
            this.bookName = bookName;
            this.chapterNumber = chapterNumber;
            this.verseNumber = verseNumber;
            this.text = text;
        }

        public string Id
        {
            get { return id; }
        }

        public string BookName
        {
            get { return bookName; }
        }

        public int ChapterNumber
        {
            get { return chapterNumber; }
        }

        public int VerseNumber
        {
            get { return verseNumber; }
        }

        public string Text
        {
            get { return text; }
        }

        public string Info()
        {
            return BookName + " " + ChapterNumber + ":" + VerseNumber + "\n\"" + Text + "\"";
        }

        public override string ToString()
        {
            return BookName + " " + ChapterNumber + ":" + VerseNumber;
        }
    }
}
