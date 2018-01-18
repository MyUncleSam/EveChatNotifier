using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EveChatNotifier.Github.UpdaterXml
{

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class item
    {

        private string versionField;

        private string urlField;

        private string changelogField;

        private bool mandatoryField;

        /// <remarks/>
        public string version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }

        /// <remarks/>
        public string changelog
        {
            get
            {
                return this.changelogField;
            }
            set
            {
                this.changelogField = value;
            }
        }

        /// <remarks/>
        public bool mandatory
        {
            get
            {
                return this.mandatoryField;
            }
            set
            {
                this.mandatoryField = value;
            }
        }
    }


}
