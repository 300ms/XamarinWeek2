using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewUserForm : ContentPage
    {
        ObservableCollection<User> ul { get; set; }

        public NewUserForm(ObservableCollection<User> UserList)
        {
            InitializeComponent();

            ul = UserList;
        }

        private async void addAndBackToList(object sender, EventArgs e)
        {
            string firstName = userFirstNameEntry.Text;
            string lastName = userLastNameEntry.Text;
            if (Int32.TryParse(userAgeEntry.Text, out int age))
            {
                User user = new User(firstName, lastName, age);
                Console.WriteLine(user.ToString());
                ul.Add(user);
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Error", "You must enter a valid age!", "OK");
            }
        }

        private async void backToList(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}