using System;
using System.Collections;
using System.Windows.Forms;
using System.Xml;
using Lyra2.UtilShared;

namespace Lyra2.LyraShell
{
    /// <summary>
    /// Manages physical storage. Contains methods to store current
    /// workspace and commit current data. And on the other side methods
    /// to load data from a XML-file.
    /// </summary>
    public class PhysicalXML : IPhysicalStorage
    {
        private string xmlurl;
        private XmlDocument doc;
        private static int highestID = 7000;
        private static int highestTrID = 0;

        public static string HighestID
        {
            get
            {
                highestID++;
                return "s" + Util.toFour(highestID);
            }
        }

        public static string HighestTrID
        {
            get
            {
                highestTrID++;
                return "t" + Util.toFour(highestTrID);
            }
        }

        public PhysicalXML(string url)
        {
            this.xmlurl = url;
            this.doc = new XmlDocument();
        }

        public SortedList getSongs()
        {
            return this.getSongs(new SortedList(), this.xmlurl, false);
        }

        /// <summary>
        /// add songs to SortedList (Song as value,song-number as key)
        /// </summary>
        /// <returns>SortedList containing all songs, null on error</returns>
        public SortedList getSongs(SortedList songs, string url, bool imp)
        {
            long start = Util.getCurrentTicks();
            try
            {
                doc.Load(url);
                XmlNodeList nodes = doc.GetElementsByTagName("Song");
                for (int i = 0; i < nodes.Count; i++)
                {
                    int nr;
                    string title;
                    string text;

                    string id = nodes[i].Attributes["id"].Value;
                    string desc = nodes[i].Attributes["zus"].Value;
                    string translations = nodes[i].Attributes["trans"].Value;

                    XmlNodeList songchildren = nodes[i].ChildNodes;
                    if ((songchildren[0].Name == "Number") &&
                        (songchildren[1].Name == "Title") &&
                        (songchildren[2].Name == "Text"))
                    {
                        nr = Int32.Parse(songchildren[0].InnerText);
                        highestID = nr > highestID ? nr : highestID;
                        title = songchildren[1].InnerText;
                        text = songchildren[2].InnerText;
                    }
                    else
                    {
                        throw new NotValidException();
                    }

                    Song newSong = new Song(nr, title, text, id, desc, imp);

                    if (songchildren.Count == 4)
                    {
                        XmlNodeList bgdesc = songchildren[3].ChildNodes;
                        if (songchildren[3].Name == "Background" && bgdesc.Count == 3 && bgdesc[0].Name == "uri"
                            && bgdesc[1].Name == "transparency" && bgdesc[2].Name == "scale")
                        {
                            newSong.BackgroundPicture = bgdesc[0].InnerText;
                            newSong.Transparency = Int32.Parse(bgdesc[1].InnerText);
                            newSong.Scale = bgdesc[2].InnerText == "yes";
                        }
                        else
                        {
                            throw new NotValidException("background node not valid");
                        }
                    }

                    this.GetTranslations(newSong, translations, imp);

                    try
                    {
                        songs.Add(newSong.ID, newSong);
                    }
                    catch (ArgumentException)
                    {
                        string msg = "Wollen Sie Lied Nr." + nr + " ersetzen?\n";
                        msg += "(drücken Sie \"abbrechen\", wenn Sie das Lied überspringen wollen.)";
                        DialogResult dr = MessageBox.Show(msg, "lyra import",
                                                          MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            songs.Remove(newSong.ID);
                            songs.Add(newSong.ID, newSong);
                        }
                        else if (dr == DialogResult.No)
                        {
                            newSong.nextID();
                            songs.Add(newSong.ID, newSong);
                        }
                        else
                        {
                            // cancel <-> ignore song
                        }
                        continue;
                    }
                }
                Util.addLoadTime(Util.getCurrentTicks() - start);
                // return SortedList with songs
                return songs;
            }
            catch (XmlException xmlEx)
            {
                Util.MBoxError(xmlEx.Message, xmlEx);
            }
            catch (NotValidException nValEx)
            {
                Util.MBoxError(nValEx.Message, nValEx);
            }
            catch (Exception e)
            {
                Util.MBoxError(e.Message, e);
            }
            return null;
        }

        private void GetTranslations(ISong song, string translations, bool imp)
            // throws XmlException, NotValidException
        {
            if (translations == "")
                return;
            string[] trs = translations.Split(',');
            XmlNode curt;
            for (int i = 0; i < trs.Length; i++)
            {
                if ((curt = doc.GetElementById(trs[i])) != null)
                {
                    XmlNodeList transchildren = curt.ChildNodes;

                    int lang = Util.getLanguageInt(curt.Attributes["lang"].Value);
                    string id = curt.Attributes["id"].Value;
                    bool uf = curt.Attributes["unform"].Value.Equals("yes");
                    string text;
                    string title;
                    if ((transchildren[0].Name == "Title") &&
                        (transchildren[1].Name == "Text"))
                    {
                        title = transchildren[0].InnerText;
                        text = transchildren[1].InnerText;
                    }
                    else
                    {
                        throw new NotValidException();
                    }
                    string newid = HighestTrID;
                    song.AddTranslation(
                        new Translation(title, text, lang, uf, "t" + Util.toFour(highestTrID), imp || (newid != id)));
                }
                else
                {
                    Util.MBoxError("Die Übersetzung \"" + trs[i] + "\" konnte nicht gefunden werden!");
                }
            }
        }


        /// <summary>
        /// Commit current workspace
        /// </summary>
        /// <param name="internList">SortedList of current songs. From Storage.</param>
        /// <returns>successful?</returns>
        public bool Commit(SortedList internList)
        {
            try
            {
                XmlNode curNode, newNode, nr, title, text;
                XmlAttribute transattr, idattr, descattr;

                XmlNode songs = doc.GetElementsByTagName("Songs")[0];

                // remove all, if songs have been replaced!
                if (Util.DELALL)
                {
                    XmlNode translations = doc.GetElementsByTagName("Translations")[0];
                    songs.RemoveAll();
                    translations.RemoveAll();
                }

                Song curSong;

                // Delete
                int j = 0;
                int top = internList.Count;
                for (int i = 0; i < top; i++)
                {
                    curSong = (Song) internList.GetByIndex(j);
                    if (curSong.Deleted)
                    {
                        j--;
                        internList.Remove(curSong.ID);
                        if ((curNode = doc.GetElementById(curSong.ID)) != null)
                        {
                            songs.RemoveChild(curNode);
                            curSong.UpdateTranslations(this);
                        }
                    }
                    j++;
                }

                IDictionaryEnumerator en = internList.GetEnumerator();
                en.Reset();


                // iterate through current SongList and update/store each song!
                while (en.MoveNext())
                {
                    curSong = (Song) en.Value;
                    if (curSong.ToUpdate)
                    {
                        // id exists
                        if ((curNode = doc.GetElementById(curSong.ID)) != null)
                        {
                            // update node
                            XmlNodeList children = curNode.ChildNodes;
                            if ((children[0].Name == "Number") &&
                                (children[1].Name == "Title") &&
                                (children[2].Name == "Text"))
                            {
                                children[0].InnerText = curSong.Number.ToString();
                                children[1].InnerText = curSong.Title;
                                children[2].InnerText = curSong.Text;
                            }
                            else
                            {
                                throw new NotValidException();
                            }
                            curSong.BackgroundPicture = Util.handlePicture(curSong.BackgroundPicture);
                            // check if background already existed:
                            if (children.Count == 4)
                            {
                                XmlNodeList bgdesc = children[3].ChildNodes;
                                if (children[3].Name == "Background" && bgdesc.Count == 3 && bgdesc[0].Name == "uri"
                                    && bgdesc[1].Name == "transparency" && bgdesc[2].Name == "scale")
                                {
                                    bgdesc[0].InnerText = curSong.BackgroundPicture;
                                    bgdesc[1].InnerText = curSong.Transparency.ToString();
                                    bgdesc[2].InnerText = curSong.Scale ? "yes" : "no";
                                }
                                else
                                {
                                    throw new NotValidException("background node not valid");
                                }
                            }
                            else
                            {
                                XmlNode bgdesc = doc.CreateNode(XmlNodeType.Element, "Background", doc.NamespaceURI);
                                XmlNode uri = doc.CreateNode(XmlNodeType.Element, "uri", doc.NamespaceURI);
                                uri.InnerText = curSong.BackgroundPicture;
                                XmlNode transp = doc.CreateNode(XmlNodeType.Element, "transparency", doc.NamespaceURI);
                                transp.InnerText = curSong.Transparency.ToString();
                                XmlNode scale = doc.CreateNode(XmlNodeType.Element, "scale", doc.NamespaceURI);
                                scale.InnerText = curSong.Scale ? "yes" : "no";
                                bgdesc.AppendChild(uri);
                                bgdesc.AppendChild(transp);
                                bgdesc.AppendChild(scale);
                                curNode.AppendChild(bgdesc);
                            }
                        }
                            // id doesn't exist
                        else
                        {
                            // create node
                            newNode = doc.CreateNode(XmlNodeType.Element, "Song", doc.NamespaceURI);

                            nr = doc.CreateNode(XmlNodeType.Element, "Number", doc.NamespaceURI);
                            title = doc.CreateNode(XmlNodeType.Element, "Title", doc.NamespaceURI);
                            text = doc.CreateNode(XmlNodeType.Element, "Text", doc.NamespaceURI);

                            nr.InnerText = curSong.Number.ToString();
                            title.InnerText = curSong.Title;
                            text.InnerText = curSong.Text;

                            transattr = doc.CreateAttribute("trans", doc.NamespaceURI);
                            transattr.Value = "";

                            idattr = doc.CreateAttribute("id", doc.NamespaceURI);
                            idattr.Value = "";
                            descattr = doc.CreateAttribute("zus", doc.NamespaceURI);
                            descattr.Value = "";
                            XmlNode bgdesc = null;
                            if (curSong.BackgroundPicture != "")
                            {
                                bgdesc = doc.CreateNode(XmlNodeType.Element, "Background", doc.NamespaceURI);
                                XmlNode uri = doc.CreateNode(XmlNodeType.Element, "uri", doc.NamespaceURI);
                                curSong.BackgroundPicture = Util.handlePicture(curSong.BackgroundPicture);
                                uri.InnerText = curSong.BackgroundPicture;
                                XmlNode transp = doc.CreateNode(XmlNodeType.Element, "transparency", doc.NamespaceURI);
                                transp.InnerText = curSong.Transparency.ToString();
                                XmlNode scale = doc.CreateNode(XmlNodeType.Element, "scale", doc.NamespaceURI);
                                scale.InnerText = curSong.Scale ? "yes" : "no";
                                bgdesc.AppendChild(uri);
                                bgdesc.AppendChild(transp);
                                bgdesc.AppendChild(scale);
                            }

                            newNode.AppendChild(nr);
                            newNode.AppendChild(title);
                            newNode.AppendChild(text);
                            if (bgdesc != null)
                            {
                                newNode.AppendChild(bgdesc);
                            }
                            newNode.Attributes.Append(idattr);
                            newNode.Attributes.Append(transattr);
                            newNode.Attributes.Append(descattr);


                            curNode = songs.AppendChild(newNode);
                        }

                        // translations
                        string transList = curSong.UpdateTranslations(this);
                        curNode.Attributes["trans"].Value = transList;
                        curNode.Attributes["id"].Value = curSong.ID;
                        curNode.Attributes["zus"].Value = curSong.Desc;
                    }
                }
                doc.Save(Util.BASEURL + "\\" + Util.URL);
                return true;
            }
                // on any error: return false => not commited!
            catch (Exception e)
            {
                Util.MBoxError(e.Message, e);
                return false;
            }
        }

        public string commitTranslations(SortedList trans)
            // throws NotValidException, XmlException
        {
            string list = "";
            XmlNode translations = doc.GetElementsByTagName("Translations")[0];

            Translation curTrans;
            XmlNode transNode;
            XmlNode newTrans, title, text;
            XmlAttribute lang, id, uf;

            // Delete
            int j = 0;
            int top = trans.Count;
            for (int i = 0; i < top; i++)
            {
                curTrans = (Translation) trans.GetByIndex(j);
                if (curTrans.Deleted)
                {
                    trans.Remove(curTrans.ID);
                    j--;
                    if ((transNode = doc.GetElementById(curTrans.ID)) != null)
                    {
                        translations.RemoveChild(transNode);
                    }
                }
                j++;
            }

            IDictionaryEnumerator en = trans.GetEnumerator();
            en.Reset();
            while (en.MoveNext())
            {
                curTrans = (Translation) en.Value;
                list += curTrans.ID + ",";
                if (curTrans.ToUpdate)
                {
                    if ((transNode = doc.GetElementById(curTrans.ID)) != null)
                    {
                        XmlNodeList transChildren = transNode.ChildNodes;
                        if ((transChildren[0].Name == "Title") &&
                            (transChildren[1].Name == "Text"))
                        {
                            transChildren[0].InnerText = curTrans.Title;
                            transChildren[1].InnerText = curTrans.Text;
                            transNode.Attributes["lang"].Value = Util.getLanguageString(curTrans.Language, true);
                            transNode.Attributes["id"].Value = curTrans.ID;
                            transNode.Attributes["unform"].Value = curTrans.Unformatted ? "yes" : "no";
                        }
                        else
                        {
                            throw new NotValidException();
                        }
                    }
                        // doesn't exist, create new Node
                    else
                    {
                        newTrans = doc.CreateNode(XmlNodeType.Element, "Translation", doc.NamespaceURI);

                        title = doc.CreateNode(XmlNodeType.Element, "Title", doc.NamespaceURI);
                        text = doc.CreateNode(XmlNodeType.Element, "Text", doc.NamespaceURI);
                        lang = doc.CreateAttribute("lang", doc.NamespaceURI);
                        id = doc.CreateAttribute("id", doc.NamespaceURI);
                        uf = doc.CreateAttribute("unform", doc.NamespaceURI);

                        lang.Value = Util.getLanguageString(curTrans.Language, true);
                        id.Value = curTrans.ID;
                        uf.Value = curTrans.Unformatted ? "yes" : "no";
                        title.InnerText = curTrans.Title;
                        text.InnerText = curTrans.Text;

                        newTrans.Attributes.Append(lang);
                        newTrans.Attributes.Append(id);
                        newTrans.Attributes.Append(uf);
                        newTrans.AppendChild(title);
                        newTrans.AppendChild(text);

                        translations.AppendChild(newTrans);
                    }
                }
            }
            int len = list.Length - 1 < 0 ? 0 : list.Length - 1;
            return list.Substring(0, len);
        }
    }

    public class NotValidException : Exception
    {
        public NotValidException() : base("XML-Datei ungültig")
        {
        }

        public NotValidException(string msg) : base("XML-Datei ungültig!\n" + msg)
        {
        }
    }
}