﻿#pragma checksum "..\..\..\Screens\MainScreen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D1297BC62E416F6A6A5E9951974FE4A1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ElderlyNetflix.Screens {
    
    
    /// <summary>
    /// MainScreen
    /// </summary>
    public partial class MainScreen : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 29 "..\..\..\Screens\MainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Profile;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Screens\MainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Recent;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Screens\MainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Saved;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Screens\MainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BROWSE;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Screens\MainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Search;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\Screens\MainScreen.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ElderlyNetflix;component/screens/mainscreen.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Screens\MainScreen.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Profile = ((System.Windows.Controls.Button)(target));
            return;
            case 2:
            this.Recent = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\Screens\MainScreen.xaml"
            this.Recent.Click += new System.Windows.RoutedEventHandler(this.Recent_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Saved = ((System.Windows.Controls.Button)(target));
            
            #line 57 "..\..\..\Screens\MainScreen.xaml"
            this.Saved.Click += new System.Windows.RoutedEventHandler(this.Saved_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.BROWSE = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\..\Screens\MainScreen.xaml"
            this.BROWSE.Click += new System.Windows.RoutedEventHandler(this.Browse_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Search = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\Screens\MainScreen.xaml"
            this.Search.Click += new System.Windows.RoutedEventHandler(this.Search_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 99 "..\..\..\Screens\MainScreen.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

