using System.Xml;

namespace Lyra2
{
    interface IXMLConvertable
    {
        /// <summary>
        /// Converts Object to its XML representation
        /// </summary>
        /// <returns>XmlElement representing Object</returns>
        XmlElement ToXML();

        /// <summary>
        /// Converts Object to its XML representation and returns a formatted XML string
        /// </summary>
        /// <returns>XML string representing Object</returns>
        string XML { get; }

        /// <summary>
        /// Loads data from XML node
        /// </summary>
        /// <param name="el">XML element</param>
        /// <exception cref="LyraException">Thrown if element does not match</exception>
        void LoadXML(XmlElement el);

        /// <summary>
        /// Gets or Sets a bool flag indicating if values have changed
        /// </summary>
        /// <returns><code>true</code> if any value belonging to XML representation changed, 
        /// <code>false</code> otherwise.</returns>
        bool HasChanged { get; set;}
    }
}
