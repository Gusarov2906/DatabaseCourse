﻿#pragma checksum "..\..\..\Windows\AddRelativeOfStudentWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "60DDEE6E3D34014841B85D4F90B92016F3C0F958F9FC2AB93D417917E1FD3535"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Lab7.Windows;
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


namespace Lab7.Windows {
    
    
    /// <summary>
    /// AddRelativeOfStudentWindow
    /// </summary>
    public partial class AddRelativeOfStudentWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Windows\AddRelativeOfStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TitleLabel;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Windows\AddRelativeOfStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PersonIDTextbox;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Windows\AddRelativeOfStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label PersonIDLabel;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Windows\AddRelativeOfStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumberStudentCardTextbox;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Windows\AddRelativeOfStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NumberStudentCardLabel;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Windows\AddRelativeOfStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox IDTypeRelativeTextbox;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Windows\AddRelativeOfStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label IDTypeRelativeLabel;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Windows\AddRelativeOfStudentWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Lab7;component/windows/addrelativeofstudentwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\AddRelativeOfStudentWindow.xaml"
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
            this.TitleLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.PersonIDTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.PersonIDLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.NumberStudentCardTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.NumberStudentCardLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.IDTypeRelativeTextbox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.IDTypeRelativeLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Windows\AddRelativeOfStudentWindow.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.ButtonClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
