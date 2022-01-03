using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Linq;

namespace UserList
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<User> UserList { get; set; } = new ObservableCollection<User>();

        public MainPage()
        {
            InitializeComponent();

            UserList.Add(new User("111", "222", 11));
            UserList.Add(new User("asd", "asd", 22));
            UserList.Add(new User("qwe", "qwe", 33));
            UserList.Add(new User("zxc", "zxc", 44));

            userListView.ItemsSource = UserList;
        }

        async void userDescription(object sender, EventArgs e)
        {
            User user = (User)userListView.SelectedItem;
            await Navigation.PushModalAsync(new UserDescription((ObservableCollection<User>)userListView.ItemsSource, user));
        }

        async void newUserForm(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NewUserForm((ObservableCollection<User>)userListView.ItemsSource));
        }

        private void searchUsers(object sender, EventArgs e)
        {
            string filter = userSearchEntry.Text;

            if (!String.IsNullOrEmpty(filter))
            {
                ObservableCollection<User> ul = new ObservableCollection<User>();
                // ul = (ObservableCollection<User>)UserList.Where(x => x.firstName.ToLower().Contains(filter.ToLower()) || x.lastName.ToLower().Contains(filter.ToLower()));
                userListView.ItemsSource = ul;
            }
            else
            {
                userListView.ItemsSource = UserList;
            }
        }
    }
}
