using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CalorieCount.Views;
using Windows.Storage;
using Windows.UI.Popups;
using CalorieCount.Models;
using Windows.Devices.Geolocation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CalorieCount
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            LoadPage();
        }

        /* View variables */
        private double dailyGoal;
        private double totalCaloriesToday = 0;


        /* Start of Local Storage ====================================================================================== */
        /* Create localstorage folder */
        private static StorageFolder localstorage = ApplicationData.Current.LocalFolder;

        /* Return the localstorage */
        public static StorageFolder getStorageFolder()
        {
            return localstorage;
        }
        /* End of Local Storage ====================================================================================== */

        /* Start of List Functions ====================================================================================== */
        private List<FoodItem> todaysFoods = new List<FoodItem>();

        /* Open eaten foods and determine which were eaten today. Sum up today's food and subtract from today's remaining goal */
        private async void getList()
        {
            totalCaloriesToday = 0;
            try
            {
                var myList = await getStorageFolder().GetFileAsync("myListTest.txt");
                var buffer = await FileIO.ReadLinesAsync(myList);
                int controlVariable = 0;
                FoodItem foodItem = new FoodItem();

                

                for (int i = 0; i < buffer.Count; i++)
                {
                    switch (controlVariable)
                    {
                        case 0:
                            foodItem.foodName = buffer[i];
                            controlVariable++;
                            break;
                        case 1:
                            foodItem.calorieAmount = double.Parse(buffer[i]);
                            controlVariable++;
                            break;
                        case 2:
                            foodItem.dateAdded = DateTime.Parse(buffer[i]);

                            if (foodItem.dateAdded.Date == DateTime.Today)
                            {
                                todaysFoods.Add(foodItem);
                                totalCaloriesToday += foodItem.calorieAmount;
                            }
                            
                            controlVariable = 0;
                            
                            foodItem = new FoodItem();
                            break;
                        default:
                            break;
                    }
                }

                return;
            }
            catch
            {
                return;
            }
        }
        /* End of List Functions ====================================================================================== */

        /* Start of Goal Functions ====================================================================================== */
        /* Use the localstorage to retrieve the goal | Default to 0 if not successful */
        private async void getGoal()
        {
            try
            {
                var myCalories = await getStorageFolder().GetFileAsync("myCaloriesTest.txt");
                var buffer = await FileIO.ReadLinesAsync(myCalories);

                dailyGoal = double.Parse(buffer[0]);

                GoalAmount.Text = dailyGoal.ToString();
                GoalRemaining.Text = (dailyGoal - totalCaloriesToday).ToString();

                return;
            }
            catch
            {
                showHowToMessage();
                GoalAmount.Text = "0";
                GoalRemaining.Text = "0";

                return;
            }
        }

        /* Set a new value for goal */
        private async void setGoal(double NewGoal)
        {
            try
            {
                var myCalories = await getStorageFolder().GetFileAsync("myCaloriesTest.txt");

                await FileIO.WriteTextAsync(myCalories, NewGoal.ToString());

                return;
            }
            catch
            {
                var myCalories = await getStorageFolder().CreateFileAsync("myCaloriesTest.txt");

                await FileIO.WriteTextAsync(myCalories, NewGoal.ToString());

                return;
            }
        }
        /* End of Goal Functions ====================================================================================== */

        /* Start of View Functions ====================================================================================== */

        /* Load in values */
        private void LoadPage()
        {
            getList();
            getGoal();

            return;
        }

        /* Display a helpful message with a simple user guide */
        private async void showHowToMessage()
        {
            var Dialog = new MessageDialog("")
            {
                Title = "Welcome to CalorieCount",
                Content = "Keep track of your calorie intake and set a daily calorie goal. CalorieCount will save your progress everyday. \n\n" +
                          "To set a new daily calorie goal, simply tap on your current calorie goal and set a new amount. \n\nTo add a new food entry, tap on the 'Add Entry' button." +
                          "\n\nTo change your profile details, simply tap on 'Settings' button." +
                          "\n\nTo change your profile picture, tap on your current profile picture (in the settings view) and select an option. "

            };
            await Dialog.ShowAsync();

            return;
        }
        /* End of View Functions ====================================================================================== */


        /* Start of Button Events ====================================================================================== */
        private void AddButton_Tapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddEntryPage));

            return;
        }

        private void SettingsButton_Tapped(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SettingsPage));

            return;
        }

        private void GoalAmount_Tapped(object sender, TappedRoutedEventArgs e)
        {
            GoalAmountSP.Visibility = Visibility.Collapsed;
            NewGoalSP.Visibility = Visibility.Visible;

            return;
        }

        private void SaveNewGoal_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                setGoal(double.Parse(NewGoalTB.Text));

                GoalAmount.Text = NewGoalTB.Text;
                GoalRemaining.Text = (double.Parse(NewGoalTB.Text) - totalCaloriesToday).ToString();

                ErrorTB.Visibility = Visibility.Collapsed;
                GoalAmountSP.Visibility = Visibility.Visible;
                NewGoalSP.Visibility = Visibility.Collapsed;
            }
            catch
            {
                ErrorTB.Visibility = Visibility.Visible;
                ErrorTB.Text = "Please enter a valid numeric value for 'Calorie Goal'.";

            }

            return;
        }

        private void CancelNewGoal_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ErrorTB.Visibility = Visibility.Collapsed;
            GoalAmountSP.Visibility = Visibility.Visible;
            NewGoalSP.Visibility = Visibility.Collapsed;

            return;
        }

        private void HowToButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            showHowToMessage();

            return;
        }
        /* End of Button Events ====================================================================================== */
    }
}
