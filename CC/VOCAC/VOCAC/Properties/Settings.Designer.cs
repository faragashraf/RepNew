﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VOCAC.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.1.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("192, 192, 255")]
        public global::System.Drawing.Color ClrSys {
            get {
                return ((global::System.Drawing.Color)(this["ClrSys"]));
            }
            set {
                this["ClrSys"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("128, 255, 128")]
        public global::System.Drawing.Color ClrUsr {
            get {
                return ((global::System.Drawing.Color)(this["ClrUsr"]));
            }
            set {
                this["ClrUsr"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("239, 255, 156")]
        public global::System.Drawing.Color ClrNotUsr {
            get {
                return ((global::System.Drawing.Color)(this["ClrNotUsr"]));
            }
            set {
                this["ClrNotUsr"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("255, 224, 192")]
        public global::System.Drawing.Color ClrSamCat {
            get {
                return ((global::System.Drawing.Color)(this["ClrSamCat"]));
            }
            set {
                this["ClrSamCat"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("255, 153, 51")]
        public global::System.Drawing.Color ClrOperation {
            get {
                return ((global::System.Drawing.Color)(this["ClrOperation"]));
            }
            set {
                this["ClrOperation"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://10.10.26.4:8000/VOCAServiceGet.asmx")]
        public string VOCAC_VOCAServiceGet_VOCAServiceGet {
            get {
                return ((string)(this["VOCAC_VOCAServiceGet_VOCAServiceGet"]));
            }
        }
    }
}
