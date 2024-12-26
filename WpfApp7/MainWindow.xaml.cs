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

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<UserControl1> _controlSrc = new List<UserControl1>();
        private List<UserControl1> Controls1 = new List<UserControl1>();

        public List<string> manuList = new List<string>();

        private bool isManuFiltered = false;

        public MainWindow()
        {
            InitializeComponent();
            _controlSrc.Add(new UserControl1() { productImgPath = "https://upload.wikimedia.org/wikipedia/en/3/30/CodeGeassmovieposter.png", productName = "Code Geass the Complete Series (Blu-ray)", productDesc = "Code Geass the Complete Series contains anime episodes 1-25 of Season 1...", productManu = "SUNRISE", productPric = 4100, productInStock = 5 });
            _controlSrc.Add(new UserControl1() { productImgPath = "https://i.ebayimg.com/images/g/M9oAAOSwFiRnPPA0/s-l1600.jpg", productName = "Mobile Suit Gundam Wing (Blu-Ray)", productDesc = "The experimental RX-78 Gundam mobile suit is forced into combat with a civilian...", productManu = "SUNRISE", productPric = 7200, productInStock = 5 });
            _controlSrc.Add(new UserControl1() { productImgPath = "https://upload.wikimedia.org/wikipedia/ru/8/82/Re_Zero_volume_1_cover.jpg", productName = "Re:Zero kara Hajimeta Isekai Seikatsu", productDesc = "Subaru Natsuki was just trying to get to the convenience store ... ", productManu = "Yen On", productPric = 999, productInStock = 7 });
            _controlSrc.Add(new UserControl1() { productImgPath = "https://m.media-amazon.com/images/I/81f6kZNIJBL._SL1500_.jpg", productName = "Re:ZERO, Vol. 2 - light novel", productDesc = "Breaking free of his death loop in the royal city, Subaru awakes in an opulent mansion ... ", productManu = "Yen On", productPric = 999, productInStock = 5 });
            _controlSrc.Add(new UserControl1() { productImgPath = "https://m.media-amazon.com/images/I/51To+WasYPL.jpg", productName = "Re:ZERO, Vol. 3 - light novel", productDesc = "Start from zero all over again with these five extra stories ... ", productManu = "Yen On", productPric = 999, productInStock = 6 });
            _controlSrc.Add(new UserControl1() { productImgPath = "https://upload.wikimedia.org/wikipedia/en/c/c3/Danganronpacharacters4.jpg", productName = "Danganronpa: The Animation (Blu-ray)", productDesc = "Hope’s Peak High School is an exclusive private school that only accepts the best of the best...", productManu = "Lerche", productPric = 7100, productInStock = 3 });


            Controls1 = _controlSrc;

            manuList.Add("All Manufacturers");
            foreach (var l in Controls1)
            {
                if (!manuList.Any(str => str.Contains(l.productManu)))
                {
                    manuList.Add(l.productManu);
                }
            }

            manuComboBox.SelectedIndex = 0;
            sortComboBox.SelectedIndex = 0;
            listNum.Content = _controlSrc.Count().ToString();
            listDispNum.Content = Controls1.Count().ToString();
            mainList.ItemsSource = Controls1;
            manuComboBox.ItemsSource = manuList;

        }


        private bool handle = true;
        private void manuComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (handle) comboHandle(sender as ComboBox);
            handle = true;
        }

        private void manuComboBox_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            handle = !cmb.IsDropDownOpen;
            comboHandle(cmb);
        }

        private void comboHandle(ComboBox cmbSelect)
        {
            if (manuComboBox.SelectedIndex == 0 || manuComboBox.SelectedIndex == -1)
            {
                Controls1 = _controlSrc;
            }
            else
            {
                Controls1 = _controlSrc.Where(c => c.productManu.Contains(manuComboBox.SelectedValue.ToString())).ToList();
            }

            switch (sortComboBox.SelectedIndex)
            {
                case 1: // By Price
                    {
                        Controls1 = Controls1.OrderBy(c => c.productPric).ToList();
                        break;
                    }
                case 2: // By Price (Desc.)
                    {
                        Controls1 = Controls1.OrderByDescending(c => c.productPric).ToList();
                        break;
                    }
                case 3: // By Stock
                    {
                        Controls1 = Controls1.OrderBy(c => c.productInStock).ToList();
                        break;
                    }
                case 4: // By Stock (Desc.)
                    {
                        Controls1 = Controls1.OrderByDescending(c => c.productInStock).ToList();
                        break;
                    }
            }

            listDispNum.Content = Controls1.Count().ToString();
            mainList.ItemsSource = Controls1;

        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
