﻿#pragma checksum "..\..\..\Views\KonwerterView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3CBD8AAC510A850565DE8CBDA29E35896D4C28E0C5980D8A599B71AFFB6A58B1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KonwerterWalutowy.Views;
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


namespace KonwerterWalutowy.Views {
    
    
    /// <summary>
    /// KonwerterView
    /// </summary>
    public partial class KonwerterView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\Views\KonwerterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxFrom;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Views\KonwerterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox ListBoxTo;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Views\KonwerterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox toCount;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Views\KonwerterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Counted;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Views\KonwerterView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker Calendar;
        
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
            System.Uri resourceLocater = new System.Uri("/KonwerterWalutowy;component/views/konwerterview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\KonwerterView.xaml"
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
            this.ListBoxFrom = ((System.Windows.Controls.ListBox)(target));
            
            #line 24 "..\..\..\Views\KonwerterView.xaml"
            this.ListBoxFrom.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxFrom_OnSelected);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ListBoxTo = ((System.Windows.Controls.ListBox)(target));
            
            #line 27 "..\..\..\Views\KonwerterView.xaml"
            this.ListBoxTo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListBoxTo_OnSelected);
            
            #line default
            #line hidden
            return;
            case 3:
            this.toCount = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Counted = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            
            #line 39 "..\..\..\Views\KonwerterView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 50 "..\..\..\Views\KonwerterView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CalendarButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Calendar = ((System.Windows.Controls.DatePicker)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

