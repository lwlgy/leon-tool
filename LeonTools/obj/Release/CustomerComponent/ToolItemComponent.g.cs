﻿#pragma checksum "..\..\..\CustomerComponent\ToolItemComponent.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9F15C6136A045BEF76DBCD74FF0B83B8F17646E813F068F628C337DF7EEE8A13"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using LeonTools.Converter;
using LeonTools.CustomerComponent;
using LeonTools.ViewModel;
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


namespace LeonTools.CustomerComponent {
    
    
    /// <summary>
    /// ToolItemComponent
    /// </summary>
    public partial class ToolItemComponent : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
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
            System.Uri resourceLocater = new System.Uri("/LeonTools;component/customercomponent/toolitemcomponent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CustomerComponent\ToolItemComponent.xaml"
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
            
            #line 13 "..\..\..\CustomerComponent\ToolItemComponent.xaml"
            ((LeonTools.CustomerComponent.ToolItemComponent)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.UserControl_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 43 "..\..\..\CustomerComponent\ToolItemComponent.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.miDelete_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 49 "..\..\..\CustomerComponent\ToolItemComponent.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.miDelete_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 55 "..\..\..\CustomerComponent\ToolItemComponent.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.miDelete_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 69 "..\..\..\CustomerComponent\ToolItemComponent.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.miDelete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 79 "..\..\..\CustomerComponent\ToolItemComponent.xaml"
            ((System.Windows.Controls.MenuItem)(target)).Click += new System.Windows.RoutedEventHandler(this.miDelete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

