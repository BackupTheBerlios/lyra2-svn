using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Lyra2
{
    public class ViewTemplate : IXMLConvertable
    {
        // data changed flag
        private bool changed = false;

        public ViewTemplate(XmlElement el)
        {
            this.LoadXML(el);
        }

        #region IXMLConvertable Members

        public XmlElement ToXML()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void LoadXML(XmlElement el)
        {
            
        }

        public string XML
        {
            get { return Utils.XMLPrettyPrint(this.ToXML()); }
        }

        public bool HasChanged
        {
            get { return this.changed; }
            set { this.changed = value; }
        }

        #endregion
    }
}
