using MSSU_CIS310_MVC.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace MSSU_CIS310_MVC
{
    public partial class KeywordUI : Window
    {
        private IList<Verse> verseList;
        private IList<Mention> mentionList;
        private Translation selectedTranslation;
        private Book selectedUpperBook;
        private Book selectedLowerBook;

        public KeywordUI()
        {
            InitializeComponent();
            verseList = new List<Verse>();
            mentionList = new List<Mention>();

            generateTranslationComboBoxItems();
            generateBookComboBoxItems();
            generateTutorialText();
        }

        private void generateTutorialText()
        {
            tutorialText.Text = "Welcome to Oliver's Bible Browser! " +
                "To get started, type in a keyword and click Search (or hit ENTER). " +
                "This will display all the verses in the Bible with that specific keyword--right here in this box! " +
                "You can also choose between 7 different translations of the Bible by clicking on the box next to \"Translation\". " +
                "If the search result is too big, you can narrow it down by choosing different books of the Bible " +
                "to search between using the boxes above the \"Search\" button";
        }
        private void generateTranslationComboBoxItems()
        {
            string sql = "SELECT abbreviation FROM bible_version_key;";
            DataTable searchResults = ExecuteSQL(sql);
            List<string> translationList = new List<string>();
            foreach (DataRow row in searchResults.Rows)
            {
                translationList.Add(row[0].ToString());
            }
            translations.ItemsSource = translationList;
            translations.SelectedIndex = 0;
        }

        private void generateBookComboBoxItems()
        {
            string sql = "SELECT n FROM key_english;";
            DataTable searchResults = ExecuteSQL(sql);
            List<string> bookList = new List<string>();
            foreach (DataRow row in searchResults.Rows)
            {
                bookList.Add(row[0].ToString());
            }
            upperBook.ItemsSource = bookList;
            lowerBook.ItemsSource = bookList;
            upperBook.SelectedIndex = 65;
            lowerBook.SelectedIndex = 0;
        }

        private void PopulateLists()
        {
            outputListBox.Items.Clear();
            foreach (Verse v in verseList)
            {
                outputListBox.Items.Add(v);
            }

            placesMentionedListBox.Items.Clear();
            foreach (Mention m in mentionList)
            {
                placesMentionedListBox.Items.Add(m);
            }
        }

        private void ReadTextClick(object sender, RoutedEventArgs e)
        {
            Verse selectedVerse = null;
            if (outputListBox.SelectedItem == null)
            {
                outputText.Text = ("Please select a verse from the list.");
                return;
            }
            selectedVerse = (Verse)outputListBox.SelectedItem;

            if (selectedVerse == null)
                outputText.Text = ("Please select a verse from the list.");
            else
                outputText.Text = (selectedVerse.Info());
        }

        private void SearchButtonClick(object sender, RoutedEventArgs e)
        {
            tutorialText.Text = "";
            outputText.Text = "";
            verseList.Clear();
            mentionList.Clear();
            string searchSql = SearchSQLString(txtKeyword.Text, selectedTranslation, selectedLowerBook, selectedUpperBook);
            string mentionSql = placesMentionedSQLstring(txtKeyword.Text, selectedTranslation);
            DataTable searchResults = ExecuteSQL(searchSql);
            DataTable mentionResults = ExecuteSQL(mentionSql);
            foreach (DataRow row in searchResults.Rows)
            {
                Verse newVerse = new Verse(row[0].ToString(), row[1].ToString(), Convert.ToInt32(row[2]),
                                        Convert.ToInt32(row[3]), row[4].ToString());

                verseList.Add(newVerse);
            }
            int totalMentions = 0;
            foreach (DataRow row in mentionResults.Rows)
            {
                Mention newMention = new Mention(row[0].ToString(), Convert.ToInt32(row[1]));
                totalMentions += Convert.ToInt32(row[1]);

                mentionList.Add(newMention);
            }
            mentionList.Add(new Mention("Total", totalMentions));

            PopulateLists();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private string placesMentionedSQLstring(string keyword, Translation translation)
        {
            return "SELECT key_english.n, COUNT(v)" +
                   $"FROM {translation.Table} NATURAL JOIN key_english " +
                   $"WHERE t LIKE '%{keyword}%' " +
                   "GROUP BY b " +
                   "ORDER BY id;";
        }

        private string SearchSQLString(string keyword, Translation translation, Book lower, Book upper)
        {
            return "SELECT id, key_english.n, c, v, t " +
                   $"FROM {translation.Table} NATURAL JOIN key_english " +
                   $"WHERE t LIKE '%{keyword}%' AND " +
                   $"b BETWEEN '{lower.Id}' AND '{upper.Id}';";
        }

        private DataTable ExecuteSQL(string sql)
        {
            DataTable dt = new DataTable();
            string datasource = @"Data Source=..\..\bible-sqlite.db;";
            using (SQLiteConnection conn = new SQLiteConnection(datasource))
            {
                conn.Open();
                SQLiteDataAdapter da = new SQLiteDataAdapter(sql, conn);
                da.Fill(dt);
                conn.Close();
            }
            return dt;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchButtonClick(sender, e);
            }
        }

        private void OnKeywordLoad(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(txtKeyword);
        }

        private void ClearTextClick(object sender, RoutedEventArgs e)
        {
            outputText.Text = "";
            placesMentionedListBox.Items.Clear();
            outputListBox.Items.Clear();
        }

        private void OnSelectTranslation(object sender, SelectionChangedEventArgs e)
        {
            string translationName = translations.SelectedItem as string;
            string sql = $"SELECT id, bible_version_key.'table', abbreviation FROM bible_version_key WHERE abbreviation = '{translationName}';";
            DataTable searchResults = ExecuteSQL(sql);
            DataRow row = searchResults.Rows[0];
            selectedTranslation = new Translation(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString());
        }

        private void OnSelectUpperBook(object sender, SelectionChangedEventArgs e)
        {
            string bookName = upperBook.SelectedItem as string;
            string sql = $"SELECT b, n FROM key_english WHERE n = '{bookName}';";
            DataTable searchResults = ExecuteSQL(sql);
            DataRow row = searchResults.Rows[0];
            selectedUpperBook = new Book(Convert.ToInt32(row[0]), row[1].ToString());
        }

        private void OnSelectLowerBook(object sender, SelectionChangedEventArgs e)
        {
            string bookName = lowerBook.SelectedItem as string;
            string sql = $"SELECT b, n FROM key_english WHERE n = '{bookName}';";
            DataTable searchResults = ExecuteSQL(sql);
            DataRow row = searchResults.Rows[0];
            selectedLowerBook = new Book(Convert.ToInt32(row[0]), row[1].ToString());
        }
    }
}