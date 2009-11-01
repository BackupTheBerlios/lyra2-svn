using System;
using System.Collections;
using System.Windows.Forms;

namespace Lyra2.LyraShell
{
    /// <summary>
    /// Datatype Song.
    /// Stored in a SortedList, accessible only through the Storage-Class.
    /// For further efficiency, I chose to directly load ALL data into the ram
    /// on initialising. So there's NO lazy binding.
    /// </summary>
    public class Song : ISong
    {
        /// <summary>
        /// Data section
        /// </summary>
        // id
        private string id;

        public string ID
        {
            get { return this.id; }
        }

        // pay attention! changes id to next free ID over s700.
        public string nextID()
        {
            return this.id = PhysicalXML.HighestID;
        }


        // number
        private int nr;

        public int Number
        {
            get { return this.nr; }
        }

        // desc
        private string zus;

        public string Desc
        {
            get { return this.zus; }
            set
            {
                this.zus = value;
                this.toupdate = true;
            }
        }

        // title
        private string title;

        public string Title
        {
            get { return this.title; }
            set
            {
                this.title = value;
                this.toupdate = true;
            }
        }

        public static GUI owner = null;

        // text		
        private string text;

        public string Text
        {
            get { return this.text; }
            set
            {
                this.text = value;
                this.toupdate = true;
            }
        }

        /// <summary>
        /// translations
        /// </summary>
        private SortedList translations = new SortedList();

        /// <summary>
        /// Gets the translations of the song
        /// </summary>
        public SortedList Translations
        {
            get { return translations; }
        }

        public IDictionaryEnumerator GetTransEnum()
        {
            return this.translations.GetEnumerator();
        }

        public ITranslation GetTranslation(string lang)
        {
            return (ITranslation) this.translations[lang];
        }

        public bool HasTrans
        {
            get { return (this.translations.Count > 0); }
        }

        public void AddTranslation(ITranslation t)
        {
            this.translations.Add(t.ID, t);
            this.transMenu = this.getTransMenuItem();
        }

        public void RemoveTranslation(ITranslation t)
        {
            t.Delete();
            this.translations.Remove(t.ID);
            this.transMenu = this.getTransMenuItem();
        }

        public void RefreshTransMenu()
        {
            this.transMenu = this.getTransMenuItem();
        }

        public string UpdateTranslations(IPhysicalStorage pStorage)
        {
            return pStorage.commitTranslations(this.translations);
        }

        public void ShowTranslations(ListBox box)
        {
            box.Items.Clear();
            IDictionaryEnumerator en = this.translations.GetEnumerator();
            en.Reset();
            while (en.MoveNext())
            {
                if (!((ITranslation) en.Value).Deleted)
                {
                    box.Items.Add(en.Value);
                }
            }
        }

        // picture
        private string backgroundpic = "";

        public string BackgroundPicture
        {
            get { return this.backgroundpic; }
            set { this.backgroundpic = value; }
        }

        private int transparency = 0;

        public int Transparency
        {
            get { return this.transparency; }
            set { this.transparency = value; }
        }

        private bool scale = true;

        public bool Scale
        {
            get { return this.scale; }
            set { this.scale = value; }
        }


        // cons
        public Song(int nr, string title, string text, string id, string zus)
        {
            this.nr = nr;
            this.title = title;
            this.text = text;
            this.id = id;
            this.zus = zus;
        }

        public Song(int nr, string title, string text, string id, string zus, bool isNew)
            : this(nr, title, text, id, zus)
        {
            this.toupdate = isNew;
        }

        // indicates if an update ist necessary
        private bool toupdate = false;

        public bool ToUpdate
        {
            get { return this.toupdate; }
        }

        public void Update()
        {
            this.toupdate = true;
        }

        // indicates if song is deleted
        private bool deleted = false;

        public bool Deleted
        {
            get { return this.deleted; }
        }

        public void Delete()
        {
            // remove translations
            IDictionaryEnumerator en = this.translations.GetEnumerator();
            en.Reset();
            while (en.MoveNext())
            {
                ((Translation) en.Value).Delete();
            }
            // this
            this.deleted = true;
        }

        // util
        public override string ToString()
        {
            return Util.toFour(this.nr) + ":\t" + this.title;
        }

        private View view = null;
        private MenuItem transMenu = null;

        public MenuItem GetTransMenu(View view)
        {
            this.view = view;
            return this.transMenu;
        }

        public MenuItem TransMenu
        {
            get
            {
                this.view = null;
                return this.transMenu;
            }
        }

        private MenuItem getTransMenuItem()
        {
            IDictionaryEnumerator en = this.translations.GetEnumerator();
            en.Reset();
            MenuItem menu = new MenuItem();
            menu.Text = "Überse&tzungen";
            while (en.MoveNext())
            {
                if (!((Translation) en.Value).Deleted)
                {
                    MenuItem newItem = new MenuItem(((Translation) en.Value).ToString());
                    newItem.Click += new EventHandler(this.handleTransClick);
                    menu.MenuItems.Add(newItem);
                }
            }
            if (menu.MenuItems.Count != 0)
            {
                return menu;
            }
            return null;
        }


        public void uncheck()
        {
            try
            {
                if(this.transMenu == null) return;
                foreach (MenuItem mi in this.transMenu.MenuItems)
                {
                    mi.Checked = false;
                }
            }
            catch (NullReferenceException)
            {
            }
        }

        private void handleTransClick(object sender, EventArgs e)
        {
            if (!((MenuItem) sender).Checked)
            {
                int i = 0;
                this.uncheck();
                while ((MenuItem) sender != this.transMenu.MenuItems[i]) i++;
                this.transMenu.MenuItems[i].Checked = true;

                if (this.view == null)
                {
                    View.ShowSong(this, (Translation) this.translations.GetByIndex(i), owner, owner.StandardNavigate);
                }
                else
                {
                    this.view.refresh(this, ((Translation) this.translations.GetByIndex(i)));
                }
            }
        }

        // copy translations

        public void acceptTranslation(SortedList trans)
        {
            this.translations = trans;
        }

        public void copyTranslation(ISong to)
        {
            to.acceptTranslation(this.translations);
        }

        public ITranslation GetTranslation(int index)
        {
            if (index < 0 || index >= this.translations.Count)
            {
                index %= this.translations.Count;
            }
            return (ITranslation) this.translations.GetByIndex(index);
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is Song)
            {
                Song s = (Song) obj;
                return this.ToString().CompareTo(s.ToString());
            }
            return 0;
        }

        #endregion
    }
}