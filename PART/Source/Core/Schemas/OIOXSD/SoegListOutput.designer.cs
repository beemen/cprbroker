//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5485
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.3038.
// 
namespace CprBroker.Schemas.Part {
    using System.Xml.Serialization;
    using CprBroker.Schemas;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("SchemaGeneration", "1.0.0.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="urn:oio:sagdok:person:1.0.0")]
    [System.Xml.Serialization.XmlRootAttribute("SoegListOutput", Namespace="urn:oio:sagdok:person:1.0.0", IsNullable=false)]
    public partial class SoegListOutputType {
        
        private StandardReturType standardReturField;
        
        private LaesResultatType[] laesResultatField;
        
        private string[] idlisteField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Namespace="urn:oio:sagdok:2.0.0")]
        public StandardReturType StandardRetur {
            get {
                return this.standardReturField;
            }
            set {
                this.standardReturField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LaesResultat")]
        public LaesResultatType[] LaesResultat {
            get {
                return this.laesResultatField;
            }
            set {
                this.laesResultatField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace="urn:oio:sagdok:1.0.0")]
        [System.Xml.Serialization.XmlArrayItemAttribute("UUID", Namespace="urn:oio:dkal:1.0.0", IsNullable=false)]
        public string[] Idliste {
            get {
                return this.idlisteField;
            }
            set {
                this.idlisteField = value;
            }
        }
    }
}