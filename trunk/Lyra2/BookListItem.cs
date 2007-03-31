using System;
using System.Collections.Generic;
using System.Text;
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
                return bli.WrappedBook.ID == this.WrappedBook.ID;
            }
            else if (obj is Book)
            {
                Book b = (Book)obj;
                return b.ID == this.WrappedBook.ID;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.WrappedBook.ID.GetHashCode();
        }

        #region INiceListBoxItem Members

        public string Title
        {
            get { return this.book.Title; }
        }

        public string Desc
        {
            get { return this.book.Desc; }
        }

        public string State
        {
            get { return "Erstellt am " + Utils.FormatShortDate(this.book.CreateDate) + " von " + this.book.Author + "."; }
        }

        public System.Drawing.Image Icon
        {
            get { return BookListItem.icon; }
        }

        #endregion
    }
}
