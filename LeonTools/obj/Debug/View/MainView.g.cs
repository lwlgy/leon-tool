﻿#pragma checksum "..\..\..\View\MainView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "BB36D732924F8FE57EE8296D2743547FDE59C74B7D7804FAB4B6622DD2F89708"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using LeonTools;
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


namespace LeonTools {
    
    
    /// <summary>
    /// MainView
    /// </summary>
    public partial class MainView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\View\MainView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel MainPanel;
        
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
            System.Uri resourceLocater = new System.Uri("/LeonTools;component/view/mainview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\View\MainView.xaml"
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
            
            #line 9 "..\..\..\View\MainView.xaml"
            ((LeonTools.MainView)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\View\MainView.xaml"
            ((LeonTools.MainView)(target)).DragEnter += new System.Windows.DragEventHandler(this.MainPanel_OnDragEnter);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\View\MainView.xaml"
            ((LeonTools.MainView)(target)).Drop += new System.Windows.DragEventHandler(this.MainPanel_OnDrop);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\View\MainView.xaml"
            ((LeonTools.MainView)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\View\MainView.xaml"
            ((LeonTools.MainView)(target)).SizeChanged += new System.Windows.SizeChangedEventHandler(this.Window_SizeChanged);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\View\MainView.xaml"
            ((LeonTools.MainView)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\View\MainView.xaml"
            ((LeonTools.MainView)(target)).Deactivated += new System.EventHandler(this.Window_Deactivated);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\View\MainView.xaml"
            ((LeonTools.MainView)(target)).IsVisibleChanged += new System.Windows.DependencyPropertyChangedEventHandler(this.Window_IsVisibleChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.MainPanel = ((System.Windows.Controls.WrapPanel)(target));
            
            #line 13 "..\..\..\View\MainView.xaml"
            this.MainPanel.DragEnter += new System.Windows.DragEventHandler(this.MainPanel_OnDragEnter);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\View\MainView.xaml"
            this.MainPanel.Drop += new System.Windows.DragEventHandler(this.MainPanel_OnDrop);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\View\MainView.xaml"
            this.MainPanel.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.MainPanel_MouseLeftButtonUp);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\View\MainView.xaml"
            this.MainPanel.MouseMove += new System.Windows.Input.MouseEventHandler(this.MainPanel_MouseMove);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

