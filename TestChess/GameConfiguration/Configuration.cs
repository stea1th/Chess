using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChess.GameConfiguration

{
    // HINWEIS: Für den generierten Code ist möglicherweise mindestens .NET Framework 4.5 oder .NET Core/Standard 2.0 erforderlich.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://infoteam.de")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://infoteam.de", IsNullable = false)]
    public partial class Configuration
    {

        private ConfigurationFigure[] figuresField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Figure", IsNullable = false)]
        public ConfigurationFigure[] Figures
        {
            get
            {
                return this.figuresField;
            }
            set
            {
                this.figuresField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://infoteam.de")]
    public partial class ConfigurationFigure
    {

        private string typeField;

        private string positionField;

        private bool whiteField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]

        public bool white
        {
            get
            {
                return this.whiteField;
            }
            set
            {
                this.whiteField = value;
            }
        }
    }
}
