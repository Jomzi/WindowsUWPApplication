﻿#pragma checksum "C:\Users\Ervii\OneDrive\Documents\Visual Studio 2015\Projects\CalorieCount\CalorieCount\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7E91E351878D0121EDFA1336B5B05F8B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CalorieCount
{
    partial class MainPage : 
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
                    this.GoalAmountSP = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 2:
                {
                    this.NewGoalSP = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3:
                {
                    this.ViewButtonsSP = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 4:
                {
                    this.AddButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 35 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.AddButton).Tapped += this.AddButton_Tapped;
                    #line default
                }
                break;
            case 5:
                {
                    this.SettingsButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 36 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.SettingsButton).Tapped += this.SettingsButton_Tapped;
                    #line default
                }
                break;
            case 6:
                {
                    this.HowToButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 37 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.HowToButton).Tapped += this.HowToButton_Tapped;
                    #line default
                }
                break;
            case 7:
                {
                    this.ErrorTB = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 8:
                {
                    this.NewGoalTB = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9:
                {
                    this.SaveNewGoal = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 28 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.SaveNewGoal).Tapped += this.SaveNewGoal_Tapped;
                    #line default
                }
                break;
            case 10:
                {
                    this.CancelNewGoal = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 29 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.CancelNewGoal).Tapped += this.CancelNewGoal_Tapped;
                    #line default
                }
                break;
            case 11:
                {
                    this.GoalAmount = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 16 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)this.GoalAmount).Tapped += this.GoalAmount_Tapped;
                    #line default
                }
                break;
            case 12:
                {
                    this.GoalRemaining = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

