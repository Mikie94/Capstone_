﻿#pragma checksum "..\..\..\Controls\Equipments.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "DDA05C3B1F8584E7FEEB954C0B26D347D8F48E0C23BEC2EC9BA82E1025D39E33"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PerfectFarming.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace PerfectFarming.Controls {
    
    
    /// <summary>
    /// Equipments
    /// </summary>
    public partial class Equipments : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\Controls\Equipments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchField;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Controls\Equipments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView listEquipments;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Controls\Equipments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid detailGrid;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Controls\Equipments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label equipmentName;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Controls\Equipments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock make;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\Controls\Equipments.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock model;
        
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
            System.Uri resourceLocater = new System.Uri("/PerfectFarming;component/controls/equipments.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\Equipments.xaml"
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
            this.searchField = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\Controls\Equipments.xaml"
            this.searchField.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.searchField_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.listEquipments = ((System.Windows.Controls.ListView)(target));
            
            #line 27 "..\..\..\Controls\Equipments.xaml"
            this.listEquipments.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listEquipments_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 44 "..\..\..\Controls\Equipments.xaml"
            ((System.Windows.Controls.Border)(target)).MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.detailGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.equipmentName = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.make = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.model = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
