using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UserList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDescription : ContentPage
    {
        ObservableCollection<User> ul { get; set; }
        User u { get; set; }
        public UserDescription(ObservableCollection<User> UserList, User user)
        {
            InitializeComponent();

            ul = UserList;

            u = user;

            displayTheDetails(user);
        }

        async void backToList(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        void displayTheDetails(User user)
        {
            userIdLabel.Text = user.Id.ToString();
            userFirstNameEntry.Text = user.firstName;
            userLastNameEntry.Text = user.lastName;
            userAgeEntry.Text = user.age.ToString();
        }

        async void deleteUser(object sender, EventArgs e)
        {
            ul.Remove(u);
            await Navigation.PopModalAsync();
        }

        async void editUser(object sender, EventArgs e)
        {
            string firstName = userFirstNameEntry.Text;
            string lastName = userLastNameEntry.Text;

            if (Int32.TryParse(userAgeEntry.Text, out int age))
            {
                ul.Remove(ul.Where(X => X.Id == u.Id).FirstOrDefault());
                User newUser = new User(firstName, lastName, age);
                ul.Add(newUser);
                await Navigation.PopModalAsync();
            }
            else
            {
                await DisplayAlert("Error", "You must enter a valid age!", "OK");
            }
        }

        void editInformation(User user, string firstName, string lastName, int age) 
        {
            user.firstName = firstName;
            user.lastName = lastName;
            user.age = age;
        }
    }
}