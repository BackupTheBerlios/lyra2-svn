using System.Drawing;

namespace Lyra2
{
    class BookListItem : NiceListBox.INiceListBoxItem
    {
        private Book book = null;
        private static Image icon = Image.FromFile(Info.RES_PATH + "icon_book.png");

        public BookListItem(Book book)
        {
            this.book = book;
        }

        public static implicit operator Book(BookListItem bItem)
        {
            return bItem.book;
        }

        public Book WrappedBook
        {
            get { return this.book; }
        }

        public override bool Equals(object obj)
        {
            if (obj is BookListItem)
            {
                BookListItem bli = (BookListItem)obj;
                return this.book.Equals(bli.book);
            }
            else if (obj is Book)
            {
                Book b = (Book)obj;
                return this.book.Equals(b);
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.WrappedBook.GetHashCode();
        }

        #region INiceListBoxItem Members

        public string Title
        {
            get { return this.book.Info.Label; }
        }

        public string Desc
        {
            get { return this.book.Info.Description; }
        }

        public string State
        {
            get { return "Erstellt am " + Utils.FormatShortDate(this.book.Info.CreateDate) + " von " + 
                this.book.Info.Author + "."; }
        }

        public Image Icon
        {
            get { return icon; }
        }

        #endregion
    }
}
