using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    class Program
    {
        static void Main(string[] args)
        {
            //bir nesne değişikliğe uğradıktan sonra istendiğinde eski haliyle kullanılır
            Book book = new Book
            {
                Isbn = "123",
                Title = "Sefiller",
                Author = "Victor Hugo"
            };
            book.ShowBook();
            CareTaker history = new CareTaker(); //yedek oluşturduk
            history.memento = book.CreateUndo();

            book.Isbn = "321";
            book.Title = "SEFİLLER";

            book.ShowBook();

            book.RestoreFromUndo(history.memento);
            book.ShowBook();
            Console.ReadLine();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        private DateTime _lastedited;
        public string Title
        {
            get { return _title; }
            set {
                _title = value;
                SetLastEdited();
            }
        }
        public string Author {
            get { return _author; }
            set
            {
                _author = value;
                SetLastEdited();
            }
        }
        public string Isbn {
            get { return _isbn; }
            set
            {
                _isbn = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _lastedited = DateTime.UtcNow;

        }

        public Memento CreateUndo()
        {
            return new Memento(_isbn, _title, _author, _lastedited);
        }

        public void RestoreFromUndo(Memento memento)
        {
            _title = memento.Title;
            _author = memento.Author;
            _isbn = memento.Isbn;
            _lastedited = memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine("{0},{1},{2} edited : {3}", Isbn, Title, Author, _lastedited);

        }
    }

    class Memento
    {
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string isbn,string title,string author,DateTime lastEdited)
        {
            Isbn = isbn;
            Title = title;
            Author = author;
            LastEdited = lastEdited;
        }
    }

    class CareTaker
    {
        public Memento memento { get; set; }
    }
}
