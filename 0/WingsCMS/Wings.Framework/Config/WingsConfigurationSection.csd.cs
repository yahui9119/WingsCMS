//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18449
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wings.Framework.Config
{
    
    
    /// <summary>
    /// The WingsConfigurationSection Configuration Section.
    /// </summary>
    public partial class WingsConfigurationSection : global::System.Configuration.ConfigurationSection
    {
        
        #region Singleton Instance
        /// <summary>
        /// The XML name of the WingsConfigurationSection Configuration Section.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string WingsConfigurationSectionSectionName = "wingsConfigurationSection";
        
        /// <summary>
        /// Gets the WingsConfigurationSection instance.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public static global::Wings.Framework.Config.WingsConfigurationSection Instance
        {
            get
            {
                return ((global::Wings.Framework.Config.WingsConfigurationSection)(global::System.Configuration.ConfigurationManager.GetSection(global::Wings.Framework.Config.WingsConfigurationSection.WingsConfigurationSectionSectionName)));
            }
        }
        #endregion
        
        #region Xmlns Property
        /// <summary>
        /// The XML name of the <see cref="Xmlns"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string XmlnsPropertyName = "xmlns";
        
        /// <summary>
        /// Gets the XML namespace of this Configuration Section.
        /// </summary>
        /// <remarks>
        /// This property makes sure that if the configuration file contains the XML namespace,
        /// the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        /// </remarks>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Wings.Framework.Config.WingsConfigurationSection.XmlnsPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public string Xmlns
        {
            get
            {
                return ((string)(base[global::Wings.Framework.Config.WingsConfigurationSection.XmlnsPropertyName]));
            }
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region EmailClient Property
        /// <summary>
        /// The XML name of the <see cref="EmailClient"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string EmailClientPropertyName = "emailClient";
        
        /// <summary>
        /// Gets or sets the EmailClient.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The EmailClient.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Wings.Framework.Config.WingsConfigurationSection.EmailClientPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Wings.Framework.Config.EmailClientElement EmailClient
        {
            get
            {
                return ((global::Wings.Framework.Config.EmailClientElement)(base[global::Wings.Framework.Config.WingsConfigurationSection.EmailClientPropertyName]));
            }
            set
            {
                base[global::Wings.Framework.Config.WingsConfigurationSection.EmailClientPropertyName] = value;
            }
        }
        #endregion
        
        #region PermissionKeys Property
        /// <summary>
        /// The XML name of the <see cref="PermissionKeys"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string PermissionKeysPropertyName = "permissionKeys";
        
        /// <summary>
        /// Gets or sets the PermissionKeys.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The PermissionKeys.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Wings.Framework.Config.WingsConfigurationSection.PermissionKeysPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Wings.Framework.Config.PermissionkeyElementCollection PermissionKeys
        {
            get
            {
                return ((global::Wings.Framework.Config.PermissionkeyElementCollection)(base[global::Wings.Framework.Config.WingsConfigurationSection.PermissionKeysPropertyName]));
            }
            set
            {
                base[global::Wings.Framework.Config.WingsConfigurationSection.PermissionKeysPropertyName] = value;
            }
        }
        #endregion
        
        #region Pressentation Property
        /// <summary>
        /// The XML name of the <see cref="Pressentation"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string PressentationPropertyName = "pressentation";
        
        /// <summary>
        /// Gets or sets the Pressentation.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Pressentation.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Wings.Framework.Config.WingsConfigurationSection.PressentationPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual global::Wings.Framework.Config.PressentationElement Pressentation
        {
            get
            {
                return ((global::Wings.Framework.Config.PressentationElement)(base[global::Wings.Framework.Config.WingsConfigurationSection.PressentationPropertyName]));
            }
            set
            {
                base[global::Wings.Framework.Config.WingsConfigurationSection.PressentationPropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Wings.Framework.Config
{
    
    
    /// <summary>
    /// The PressentationElement Configuration Element.
    /// </summary>
    public partial class PressentationElement : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region ProductsPageSize Property
        /// <summary>
        /// The XML name of the <see cref="ProductsPageSize"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string ProductsPageSizePropertyName = "productsPageSize";
        
        /// <summary>
        /// Gets or sets the ProductsPageSize.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The ProductsPageSize.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Wings.Framework.Config.PressentationElement.ProductsPageSizePropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual int ProductsPageSize
        {
            get
            {
                return ((int)(base[global::Wings.Framework.Config.PressentationElement.ProductsPageSizePropertyName]));
            }
            set
            {
                base[global::Wings.Framework.Config.PressentationElement.ProductsPageSizePropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Wings.Framework.Config
{
    
    
    /// <summary>
    /// A collection of PermissionkeyElement instances.
    /// </summary>
    [global::System.Configuration.ConfigurationCollectionAttribute(typeof(global::Wings.Framework.Config.PermissionkeyElement), CollectionType=global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate, AddItemName=global::Wings.Framework.Config.PermissionkeyElementCollection.PermissionkeyElementPropertyName)]
    public partial class PermissionkeyElementCollection : global::System.Configuration.ConfigurationElementCollection
    {
        
        #region Constants
        /// <summary>
        /// The XML name of the individual <see cref="global::Wings.Framework.Config.PermissionkeyElement"/> instances in this collection.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string PermissionkeyElementPropertyName = "permissionkeyElement";
        #endregion
        
        #region Overrides
        /// <summary>
        /// Gets the type of the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <returns>The <see cref="global::System.Configuration.ConfigurationElementCollectionType"/> of this collection.</returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override global::System.Configuration.ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return global::System.Configuration.ConfigurationElementCollectionType.BasicMapAlternate;
            }
        }
        
        /// <summary>
        /// Gets the name used to identify this collection of elements
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        protected override string ElementName
        {
            get
            {
                return global::Wings.Framework.Config.PermissionkeyElementCollection.PermissionkeyElementPropertyName;
            }
        }
        
        /// <summary>
        /// Indicates whether the specified <see cref="global::System.Configuration.ConfigurationElement"/> exists in the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="elementName">The name of the element to verify.</param>
        /// <returns>
        /// <see langword="true"/> if the element exists in the collection; otherwise, <see langword="false"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        protected override bool IsElementName(string elementName)
        {
            return (elementName == global::Wings.Framework.Config.PermissionkeyElementCollection.PermissionkeyElementPropertyName);
        }
        
        /// <summary>
        /// Gets the element key for the specified configuration element.
        /// </summary>
        /// <param name="element">The <see cref="global::System.Configuration.ConfigurationElement"/> to return the key for.</param>
        /// <returns>
        /// An <see cref="object"/> that acts as the key for the specified <see cref="global::System.Configuration.ConfigurationElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        protected override object GetElementKey(global::System.Configuration.ConfigurationElement element)
        {
            return ((global::Wings.Framework.Config.PermissionkeyElement)(element)).RoleName;
        }
        
        /// <summary>
        /// Creates a new <see cref="global::Wings.Framework.Config.PermissionkeyElement"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="global::Wings.Framework.Config.PermissionkeyElement"/>.
        /// </returns>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        protected override global::System.Configuration.ConfigurationElement CreateNewElement()
        {
            return new global::Wings.Framework.Config.PermissionkeyElement();
        }
        #endregion
        
        #region Indexer
        /// <summary>
        /// Gets the <see cref="global::Wings.Framework.Config.PermissionkeyElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::Wings.Framework.Config.PermissionkeyElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public global::Wings.Framework.Config.PermissionkeyElement this[int index]
        {
            get
            {
                return ((global::Wings.Framework.Config.PermissionkeyElement)(base.BaseGet(index)));
            }
        }
        
        /// <summary>
        /// Gets the <see cref="global::Wings.Framework.Config.PermissionkeyElement"/> with the specified key.
        /// </summary>
        /// <param name="roleName">The key of the <see cref="global::Wings.Framework.Config.PermissionkeyElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public global::Wings.Framework.Config.PermissionkeyElement this[object roleName]
        {
            get
            {
                return ((global::Wings.Framework.Config.PermissionkeyElement)(base.BaseGet(roleName)));
            }
        }
        #endregion
        
        #region Add
        /// <summary>
        /// Adds the specified <see cref="global::Wings.Framework.Config.PermissionkeyElement"/> to the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="permissionkeyElement">The <see cref="global::Wings.Framework.Config.PermissionkeyElement"/> to add.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public void Add(global::Wings.Framework.Config.PermissionkeyElement permissionkeyElement)
        {
            base.BaseAdd(permissionkeyElement);
        }
        #endregion
        
        #region Remove
        /// <summary>
        /// Removes the specified <see cref="global::Wings.Framework.Config.PermissionkeyElement"/> from the <see cref="global::System.Configuration.ConfigurationElementCollection"/>.
        /// </summary>
        /// <param name="permissionkeyElement">The <see cref="global::Wings.Framework.Config.PermissionkeyElement"/> to remove.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public void Remove(global::Wings.Framework.Config.PermissionkeyElement permissionkeyElement)
        {
            base.BaseRemove(this.GetElementKey(permissionkeyElement));
        }
        #endregion
        
        #region GetItem
        /// <summary>
        /// Gets the <see cref="global::Wings.Framework.Config.PermissionkeyElement"/> at the specified index.
        /// </summary>
        /// <param name="index">The index of the <see cref="global::Wings.Framework.Config.PermissionkeyElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public global::Wings.Framework.Config.PermissionkeyElement GetItemAt(int index)
        {
            return ((global::Wings.Framework.Config.PermissionkeyElement)(base.BaseGet(index)));
        }
        
        /// <summary>
        /// Gets the <see cref="global::Wings.Framework.Config.PermissionkeyElement"/> with the specified key.
        /// </summary>
        /// <param name="roleName">The key of the <see cref="global::Wings.Framework.Config.PermissionkeyElement"/> to retrieve.</param>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public global::Wings.Framework.Config.PermissionkeyElement GetItemByKey(string roleName)
        {
            return ((global::Wings.Framework.Config.PermissionkeyElement)(base.BaseGet(((object)(roleName)))));
        }
        #endregion
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
    }
}
namespace Wings.Framework.Config
{
    
    
    /// <summary>
    /// The PermissionkeyElement Configuration Element.
    /// </summary>
    public partial class PermissionkeyElement : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region RoleName Property
        /// <summary>
        /// The XML name of the <see cref="RoleName"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string RoleNamePropertyName = "roleName";
        
        /// <summary>
        /// Gets or sets the RoleName.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The RoleName.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Wings.Framework.Config.PermissionkeyElement.RoleNamePropertyName, IsRequired=true, IsKey=true, IsDefaultCollection=false)]
        public virtual string RoleName
        {
            get
            {
                return ((string)(base[global::Wings.Framework.Config.PermissionkeyElement.RoleNamePropertyName]));
            }
            set
            {
                base[global::Wings.Framework.Config.PermissionkeyElement.RoleNamePropertyName] = value;
            }
        }
        #endregion
        
        #region KeyName Property
        /// <summary>
        /// The XML name of the <see cref="KeyName"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string KeyNamePropertyName = "keyName";
        
        /// <summary>
        /// Gets or sets the KeyName.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The KeyName.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Wings.Framework.Config.PermissionkeyElement.KeyNamePropertyName, IsRequired=true, IsKey=false, IsDefaultCollection=false)]
        public virtual string KeyName
        {
            get
            {
                return ((string)(base[global::Wings.Framework.Config.PermissionkeyElement.KeyNamePropertyName]));
            }
            set
            {
                base[global::Wings.Framework.Config.PermissionkeyElement.KeyNamePropertyName] = value;
            }
        }
        #endregion
    }
}
namespace Wings.Framework.Config
{
    
    
    /// <summary>
    /// The EmailClientElement Configuration Element.
    /// </summary>
    public partial class EmailClientElement : global::System.Configuration.ConfigurationElement
    {
        
        #region IsReadOnly override
        /// <summary>
        /// Gets a value indicating whether the element is read-only.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        public override bool IsReadOnly()
        {
            return false;
        }
        #endregion
        
        #region Host Property
        /// <summary>
        /// The XML name of the <see cref="Host"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string HostPropertyName = "host";
        
        /// <summary>
        /// Gets or sets the Host.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Host.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Wings.Framework.Config.EmailClientElement.HostPropertyName, IsRequired=true, IsKey=true, IsDefaultCollection=false)]
        public virtual string Host
        {
            get
            {
                return ((string)(base[global::Wings.Framework.Config.EmailClientElement.HostPropertyName]));
            }
            set
            {
                base[global::Wings.Framework.Config.EmailClientElement.HostPropertyName] = value;
            }
        }
        #endregion
        
        #region Port Property
        /// <summary>
        /// The XML name of the <see cref="Port"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string PortPropertyName = "port";
        
        /// <summary>
        /// Gets or sets the Port.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Port.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Wings.Framework.Config.EmailClientElement.PortPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual int Port
        {
            get
            {
                return ((int)(base[global::Wings.Framework.Config.EmailClientElement.PortPropertyName]));
            }
            set
            {
                base[global::Wings.Framework.Config.EmailClientElement.PortPropertyName] = value;
            }
        }
        #endregion
        
        #region UserName Property
        /// <summary>
        /// The XML name of the <see cref="UserName"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string UserNamePropertyName = "userName";
        
        /// <summary>
        /// Gets or sets the UserName.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The UserName.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Wings.Framework.Config.EmailClientElement.UserNamePropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string UserName
        {
            get
            {
                return ((string)(base[global::Wings.Framework.Config.EmailClientElement.UserNamePropertyName]));
            }
            set
            {
                base[global::Wings.Framework.Config.EmailClientElement.UserNamePropertyName] = value;
            }
        }
        #endregion
        
        #region Password Property
        /// <summary>
        /// The XML name of the <see cref="Password"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string PasswordPropertyName = "password";
        
        /// <summary>
        /// Gets or sets the Password.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Password.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Wings.Framework.Config.EmailClientElement.PasswordPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string Password
        {
            get
            {
                return ((string)(base[global::Wings.Framework.Config.EmailClientElement.PasswordPropertyName]));
            }
            set
            {
                base[global::Wings.Framework.Config.EmailClientElement.PasswordPropertyName] = value;
            }
        }
        #endregion
        
        #region EnableSsl Property
        /// <summary>
        /// The XML name of the <see cref="EnableSsl"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string EnableSslPropertyName = "enableSsl";
        
        /// <summary>
        /// Gets or sets the EnableSsl.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The EnableSsl.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Wings.Framework.Config.EmailClientElement.EnableSslPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual bool EnableSsl
        {
            get
            {
                return ((bool)(base[global::Wings.Framework.Config.EmailClientElement.EnableSslPropertyName]));
            }
            set
            {
                base[global::Wings.Framework.Config.EmailClientElement.EnableSslPropertyName] = value;
            }
        }
        #endregion
        
        #region Sender Property
        /// <summary>
        /// The XML name of the <see cref="Sender"/> property.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        internal const string SenderPropertyName = "sender";
        
        /// <summary>
        /// Gets or sets the Sender.
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")]
        [global::System.ComponentModel.DescriptionAttribute("The Sender.")]
        [global::System.Configuration.ConfigurationPropertyAttribute(global::Wings.Framework.Config.EmailClientElement.SenderPropertyName, IsRequired=false, IsKey=false, IsDefaultCollection=false)]
        public virtual string Sender
        {
            get
            {
                return ((string)(base[global::Wings.Framework.Config.EmailClientElement.SenderPropertyName]));
            }
            set
            {
                base[global::Wings.Framework.Config.EmailClientElement.SenderPropertyName] = value;
            }
        }
        #endregion
    }
}
