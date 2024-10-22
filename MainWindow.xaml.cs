using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteLife2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private Start _startWindow;
        private Person _player;
        public MainWindow()
        {
            InitializeComponent();
            Render.RunRender();
            createPlayer.Visibility = Visibility.Visible;
            tabcontr.Visibility = Visibility.Collapsed;
            startgame.IsEnabled = false;
            countryChooser.ItemsSource=Country.countryList;
            // _startWindow = new Start();
            // _startWindow.Visibility = Visibility.Visible;
            // _startWindow.StartGameClicked += StartWindow_StartGameClicked;
        }
        private void StartWindow_StartGameClicked(object sender, EventArgs e)
        {
            // _startWindow.Visibility=Visibility.Collapsed;
            // _player = _startWindow.CreatePerson();
            countrybox.Text = _player.Country.Name;
            agebox.Text = _player.Age.ToString();
            namebox.Text = _player.FirstName + " " + _player.LastName;


            PersonDynamics.FamilyMaker(_player);
            relationshipListView.ItemsSource = _player.Relationships;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            mainText.Text = News.NewsWriter;
            foreach (Relationship relationship in _player.Relationships)
            {
                News.NewsAdder(relationship.Person2.FirstName + relationship.Person2.LastName + relationship.Description);
            }

        }

        private void CreatePeople(object sender, RoutedEventArgs e)
        {

        }

        private void firstnameInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            ValidateInputs();
        }

        private void countryChooser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ValidateInputs();
        }
        private void ValidateInputs()
        {
            bool isFirstNameValid = !string.IsNullOrWhiteSpace(firstnameInput.Text) && firstnameInput.Text.All(char.IsLetter);
            bool isLastNameValid = !string.IsNullOrWhiteSpace(lastnameInput.Text) && lastnameInput.Text.All(char.IsLetter);

            startgame.IsEnabled = isFirstNameValid
                                  && isLastNameValid
                                  && countryChooser.SelectedItem != null
                                  && (maleRadioButton.IsChecked==true
                                  || femaleRadioButton.IsChecked==true);

        }
        public void startgame_Click(object sender, RoutedEventArgs e)
        {
            bool female=false;
            if (femaleRadioButton.IsChecked == true) { female = true; }
            Person player = new(firstnameInput.Text, lastnameInput.Text,Country.countryList[ countryChooser.SelectedIndex], 0, female, relationships: []);
            PersonDynamics.FamilyMaker(player);
            createPlayer.Visibility = Visibility.Collapsed;
            tabcontr.Visibility = Visibility.Visible;
            countrybox.Text = player.Country.Name;
            agebox.Text = player.Age.ToString();
            namebox.Text = player.FullName;
            relationshipListView.ItemsSource = player.Relationships;
            mainText.Text = News.NewsWriter;
        }
        private void MainText_TextChanged(object sender, TextChangedEventArgs e)
        {
            mainText.ScrollToEnd();
        }

    }
}