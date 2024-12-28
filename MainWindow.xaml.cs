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
        private Person ? _player;
        public MainWindow()
        {
            InitializeComponent();
            Render.RunRender();
            createPlayer.Visibility = Visibility.Visible;
            tabcontr.Visibility = Visibility.Collapsed;
            startgame.IsEnabled = false;
            countryChooser.ItemsSource=Country.countryList;
        }
        private void StartWindow_StartGameClicked(object sender, EventArgs e)
        {
            countrybox.Text = _player.Country.Name;
            agebox.Text = _player.Age.ToString();
            namebox.Text = _player.FullName;
            PersonDynamics.FamilyMaker(_player);
            relationshipListView.ItemsSource = _player.Relationships;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Flow.Cycle(Render.peoplePool);
            foreach(Person person in Render.peoplePool)
            {
                News.NewsAdder($"{person.FullName}, age: {person.Age}" +
                    $"agegroup: {person.AgeGroup}, money: {person.Money}," +
                    $"fitness: {person.Fitness}, hapinness: {person.Happiness}," +
                    $"health: {person.Health}, intelligence: {person.Intelligence}," +
                    $"looks: {person.Looks}, school: {person.School?.Name}");
            }
            Refresh();
            relationshipListView.Items.Refresh();
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
            Render.RenderPlayer(player);
            _player = player;
        }
        private void MainText_TextChanged(object sender, TextChangedEventArgs e)
        {
            mainText.ScrollToEnd();
        }
        private void Refresh()
        {
            relationshipListView.ItemsSource = _player?.Relationships;
            agebox.Text = _player?.Age.ToString();
            mainText.Text = News.NewsWriter;
            TabHandler(_player);
        }
        private void TabHandler(Person player)
        {
            switch (player.School?.Description)
            {
                case "Elementary School":
                    elementary.Visibility = Visibility.Visible;
                    break;
                case "High School":
                    highSchool.Visibility = Visibility.Visible;
                    elementary.Visibility = Visibility.Collapsed;
                    break;
                case "University":
                    university.Visibility = Visibility.Visible;
                    highSchool.Visibility = Visibility.Collapsed;
                    elementary.Visibility = Visibility.Collapsed;
                    break;
                default:
                    elementary.Visibility = Visibility.Collapsed;
                    highSchool.Visibility = Visibility.Collapsed;
                    university.Visibility = Visibility.Collapsed;
                    break;
            }
            if (player.Employed)
            {
                work.Visibility = Visibility.Visible;                
            }
            else
            {
                work.Visibility = Visibility.Collapsed;
            }
        }
    }
}