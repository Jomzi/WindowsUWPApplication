﻿#pragma checksum "C:\Users\Ervii\OneDrive\Documents\Visual Studio 2015\Projects\CalorieCount\CalorieCount\Views\AddEntryPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "921D85BEED6E09E83B0E01A182FB69CE"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CalorieCount.Views
{
    partial class AddEntryPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.foodlist = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 2:
                {
                    this.ErrorTB = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3:
                {
                    this.FoodNameTB = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4:
                {
                    this.CalorieAmountTB = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5:
                {
                    this.SaveButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 19 "..\..\..\Views\AddEntryPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.SaveButton).Tapped += this.SaveButton_Tapped;
                    #line default
                }
                break;
            case 6:
                {
                    this.CancelButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 20 "..\..\..\Views\AddEntryPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.CancelButton).Tapped += this.CancelButton_Tapped;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
