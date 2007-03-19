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
