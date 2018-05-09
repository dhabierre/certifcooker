﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :2.0.50727.8605
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=2.0.50727.3038.
// 
namespace CertifCooker.Configuration {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
    public partial class Configuration {
        
        private ConfigurationAutoFill autoFillField;
        
        private ConfigurationCertificate[] certificatesField;
        
        /// <remarks/>
        public ConfigurationAutoFill AutoFill {
            get {
                return this.autoFillField;
            }
            set {
                this.autoFillField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Certificate", IsNullable=false)]
        public ConfigurationCertificate[] Certificates {
            get {
                return this.certificatesField;
            }
            set {
                this.certificatesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ConfigurationAutoFill {
        
        private string fullnameField;
        
        private string birthdayField;

		private string activityField;

		private string sexField;
        
        /// <remarks/>
        public string Fullname {
            get {
                return this.fullnameField;
            }
            set {
                this.fullnameField = value;
            }
        }
        
        /// <remarks/>
        public string Birthday {
            get {
                return this.birthdayField;
            }
            set {
                this.birthdayField = value;
            }
        }
        
        /// <remarks/>
        public string Activity {
            get {
                return this.activityField;
            }
            set {
                this.activityField = value;
            }
        }
        
        /// <remarks/>
        public string Sex {
            get {
				return this.sexField;
            }
            set {
				this.sexField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ConfigurationCertificate {
        
        private ConfigurationCertificateDateText dateTextField;
        
        private ConfigurationCertificateContentText contentTextField;
        
        private string nameField;
        
        private string fontFamilyNameField;

		private byte fontSizeEmField;

		private float rotateAngle;
        
        /// <remarks/>
        public ConfigurationCertificateDateText DateText {
            get {
                return this.dateTextField;
            }
            set {
                this.dateTextField = value;
            }
        }
        
        /// <remarks/>
        public ConfigurationCertificateContentText ContentText {
            get {
                return this.contentTextField;
            }
            set {
                this.contentTextField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FontFamilyName {
            get {
                return this.fontFamilyNameField;
            }
            set {
                this.fontFamilyNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte FontSizeEm {
            get {
                return this.fontSizeEmField;
            }
            set {
                this.fontSizeEmField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public float RotateAngle {
            get {
				return this.rotateAngle;
            }
            set {
				this.rotateAngle = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ConfigurationCertificateDateText {
        
        private string valueField;
        
        private int coordXField;
        
        private int coordYField;
        
        private int widthField;
        
        private int heightField;
        
        /// <remarks/>
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int CoordX {
            get {
                return this.coordXField;
            }
            set {
                this.coordXField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int CoordY {
            get {
                return this.coordYField;
            }
            set {
                this.coordYField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Width {
            get {
                return this.widthField;
            }
            set {
                this.widthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Height {
            get {
                return this.heightField;
            }
            set {
                this.heightField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
    public partial class ConfigurationCertificateContentText {
        
        private string valueField;
        
        private byte coordXField;
        
        private int coordYField;
        
        private int widthField;
        
        private int heightField;
        
        /// <remarks/>
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte CoordX {
            get {
                return this.coordXField;
            }
            set {
                this.coordXField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int CoordY {
            get {
                return this.coordYField;
            }
            set {
                this.coordYField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Width {
            get {
                return this.widthField;
            }
            set {
                this.widthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Height {
            get {
                return this.heightField;
            }
            set {
                this.heightField = value;
            }
        }
    }
}
