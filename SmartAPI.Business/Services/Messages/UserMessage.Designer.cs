﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartAPI.Business.Services.Messages {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class UserMessage {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal UserMessage() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SmartAPI.Business.Services.Messages.UserMessage", typeof(UserMessage).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Credenciais inválidas.
        /// </summary>
        public static string AUTH01 {
            get {
                return ResourceManager.GetString("AUTH01", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuário não cadastrado.
        /// </summary>
        public static string AUTH02 {
            get {
                return ResourceManager.GetString("AUTH02", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuário Autenticado com sucesso.
        /// </summary>
        public static string AUTHSUCCESS {
            get {
                return ResourceManager.GetString("AUTHSUCCESS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuário criado com sucesso.
        /// </summary>
        public static string CREATE {
            get {
                return ResourceManager.GetString("CREATE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuário deletado com sucesso.
        /// </summary>
        public static string DELETE {
            get {
                return ResourceManager.GetString("DELETE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Erro na criação do usuário.
        /// </summary>
        public static string ERROR_CREATE {
            get {
                return ResourceManager.GetString("ERROR_CREATE", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuário encontrado.
        /// </summary>
        public static string FOUND {
            get {
                return ResourceManager.GetString("FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to UserId Inválido.
        /// </summary>
        public static string INVALID {
            get {
                return ResourceManager.GetString("INVALID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Usuário não encontrado.
        /// </summary>
        public static string NOTFOUND {
            get {
                return ResourceManager.GetString("NOTFOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Username inválido.
        /// </summary>
        public static string VALIDATIONREQUEST01 {
            get {
                return ResourceManager.GetString("VALIDATIONREQUEST01", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Senhas não coincidem.
        /// </summary>
        public static string VALIDATIONREQUEST02 {
            get {
                return ResourceManager.GetString("VALIDATIONREQUEST02", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Senha muito extensa ou não está no tamanho adequado de pelo menos 8 dígitos.
        /// </summary>
        public static string VALIDATIONREQUEST03 {
            get {
                return ResourceManager.GetString("VALIDATIONREQUEST03", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Email não está no formato adequado.
        /// </summary>
        public static string VALIDATIONREQUEST04 {
            get {
                return ResourceManager.GetString("VALIDATIONREQUEST04", resourceCulture);
            }
        }
    }
}
