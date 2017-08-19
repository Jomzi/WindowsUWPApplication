using CalorieCount.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CalorieCount.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddEntryPage : Page
    {
        public AddEntryPage()
        {
            this.InitializeComponent();
            getList();
            updateList();
        }

        /* Start of List Functions ====================================================================================== */
        private List<FoodItem> foodList = new List<FoodItem>();

        /* Add a food item to an existing file or create a file */
        private async void setList(FoodItem NewFood)
        {
            try
            {
                var myList = await MainPage.getStorageFolder().GetFileAsync("myListTest.txt");

                await FileIO.AppendTextAsync(myList, NewFood.ToString());
            }
            catch
            {
                var myList = await MainPage.getStorageFolder().CreateFileAsync("myListTest.txt");

                await FileIO.AppendTextAsync(myList, NewFood.ToString());
            }
        }

        /* Retrieve the food file and use a buffer with a for loop to parse it. | If the file does not exist, do nothing */
        private async void getList()
        {
            try
            {
                var myList = await MainPage.getStorageFolder().GetFileAsync("myListTest.txt");
                var buffer = await FileIO.ReadLinesAsync(myList);
                int controlVariable = 0;
                FoodItem foodItem = new FoodItem();

                for(int i = 0; i < buffer.Count; i++)
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
                            controlVariable = 0;
                            AddListItem(foodItem);
                            foodItem = new FoodItem();
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {

            }
        }

        /* Add a new food item to the list and update the list */
        private void AddListItem(FoodItem foodItem)
        {
            foodList.Add(foodItem);
            updateList();
        }

        /* Update the list in the view */
        private void updateList()
        {
            List<FoodItem> listview = new List<FoodItem>();

            foreach (var item in foodList)
            {
                listview.Add(item);
            }

            listview.Reverse();

            foodlist.DataContext = listview;
        }

        /* End of List Functions ====================================================================================== */

        /* Start of Button Events ====================================================================================== */
        private void SaveButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            try
            {
                string foodName = FoodNameTB.Text;
                double calorieAmount = Convert.ToDouble(CalorieAmountTB.Text);
                ErrorTB.Visibility = Visibility.Collapsed;
                FoodItem fooditem = new Models.FoodItem()
                {
                    foodName = foodName,
                    calorieAmount = calorieAmount,
                    dateAdded = DateTime.Now
                };
                AddListItem(fooditem);
                setList(fooditem);
            }
            catch
            {
                ErrorTB.Visibility = Visibility.Visible;

                ErrorTB.Text = "Please enter a valid numeric value for 'Amount of Calories'.";
            }

        }

        private void CancelButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        /* End of Button Events ====================================================================================== */

    }
}
