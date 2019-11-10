﻿#pragma checksum "..\..\Player.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "04843E9AE87264F6D1EF2731CDA6BE0A447238F8FF2E3A86C2B5F2E0C99616AF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AxWMPLib;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
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


namespace Wireframe_GUI {
    
    
    /// <summary>
    /// Player
    /// </summary>
    public partial class Player : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Forms.Integration.WindowsFormsHost formsHost;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AxWMPLib.AxWindowsMediaPlayer player;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox startTimeEntry;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button setNewStartTime;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox stopTimeEntry;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button setNewStopTime;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button restartBtn;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid commentTable;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn start;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn stop;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\Player.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn comment;
        
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
            System.Uri resourceLocater = new System.Uri("/Wireframe_GUI;component/player.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Player.xaml"
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
            
            #line 6 "..\..\Player.xaml"
            ((Wireframe_GUI.Player)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.formsHost = ((System.Windows.Forms.Integration.WindowsFormsHost)(target));
            return;
            case 3:
            this.player = ((AxWMPLib.AxWindowsMediaPlayer)(target));
            return;
            case 4:
            this.startTimeEntry = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.setNewStartTime = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\Player.xaml"
            this.setNewStartTime.Click += new System.Windows.RoutedEventHandler(this.newstartBtn_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.stopTimeEntry = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.setNewStopTime = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\Player.xaml"
            this.setNewStopTime.Click += new System.Windows.RoutedEventHandler(this.newstopBtn_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.restartBtn = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\Player.xaml"
            this.restartBtn.Click += new System.Windows.RoutedEventHandler(this.restartBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.commentTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 10:
            this.start = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 11:
            this.stop = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 12:
            this.comment = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

