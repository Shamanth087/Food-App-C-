using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Food_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<CartItem> _cart1 = new ObservableCollection<CartItem>();
        List<CartItem> _cart = new List<CartItem>();
        public MainWindow()
        {
            InitializeComponent();
            if (App._cart != null)
            {
                var addedlst = from m in App._cart select m;
                Lbx_cart.ItemsSource = addedlst;
            }
        }

        private void btn_veg_Click(object sender, RoutedEventArgs e)

        {
            btn_veg.Background = Brushes.Gray;
            btn_non_veg.Background = Brushes.CadetBlue;
            btn_bev.Background = Brushes.CadetBlue;
            btn_des.Background = Brushes.CadetBlue;
            var lst = from m in App._item where m.itemtype.Contains("veg") select m;
            Lbx_members.ItemsSource = lst;
        }



        private void btn_non_veg_Click(object sender, RoutedEventArgs e)
        {
            btn_non_veg.Background = Brushes.Gray;
            btn_veg.Background =Brushes.CadetBlue ;
            btn_bev.Background = Brushes.CadetBlue;
            btn_des.Background = Brushes.CadetBlue;

            var lst = from m in App._item where m.itemtype.Contains("meat") select m;
            Lbx_members.ItemsSource = lst;
        }

        private void btn_bev_Click(object sender, RoutedEventArgs e)
        {
            btn_bev.Background = Brushes.Gray;
            btn_non_veg.Background = Brushes.CadetBlue;
            btn_veg.Background = Brushes.CadetBlue;
            btn_des.Background = Brushes.CadetBlue;
            var lst = from m in App._item where m.itemtype.Contains("beverage") select m;
            Lbx_members.ItemsSource = lst;
        }

        private void btn_des_Click(object sender, RoutedEventArgs e)
        {
            btn_des.Background = Brushes.Gray;
            btn_bev.Background = Brushes.CadetBlue;
            btn_non_veg.Background = Brushes.CadetBlue;
            btn_veg.Background = Brushes.CadetBlue;
            var lst = from m in App._item where m.itemtype.Contains("dessert") select m;
            Lbx_members.ItemsSource = lst;

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool found = false;
            CartItem cart = new CartItem();
            var itemName = (sender as Button).Tag.ToString();
            foreach (var item in App._item)
            {
                if (item.name == itemName)
                {
                    if (_cart1 != null)
                    {
                        for (int i = 0; i < _cart1.Count; i++)
                        {
                            if (_cart1[i].name == itemName)
                            {
                                found = true;
                              

                                _cart1[i].quantity = _cart1[i].quantity + 1;
                                Lbx_cart.ItemsSource = _cart1;
                                break;
                            }
                        }
                    }
                    if (found == false)
                    {
                        double quantityPrice = item.price * 1;
                        _cart1.Add(new CartItem { name = item.name, price = item.price, quantity = 1, totalPrice = 0, quantityPrice = quantityPrice });

                        Lbx_cart.ItemsSource = _cart1;

                      


                    }

                }

            }
            AddTotalPrice(_cart1);

          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_decreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            string itemName = (sender as Button).Tag.ToString();
            foreach (var item in _cart1)
            {
                if (item.name == itemName)
                {
                    if (item.quantity > 1)
                    {
                        item.quantity --;
                        item.quantityPrice = item.quantity * item.price;
                    }
                    else
                    {
                        (sender as Button).IsEnabled = false;
                    }

                }
            }
            AddTotalPrice(_cart1);
            Lbx_cart.ItemsSource = null;
            Lbx_cart.ItemsSource = _cart1;

        }


        private void Btn_increaseQuantity_Click(object sender, RoutedEventArgs e)
        {

            string itemName = (sender as Button).Tag.ToString();
            foreach (var item in _cart1)
            {
                if (item.name == itemName)
                {
                    item.quantity++;
                    item.quantityPrice = item.quantity * item.price;
                }
            }


            Lbx_cart.ItemsSource = null;
            Lbx_cart.ItemsSource = _cart1;
            AddTotalPrice(_cart1);







        }


        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            string itemName = (sender as Button).Tag.ToString();
            foreach (var item in _cart1)
            {
                if (itemName == item.name)
                {
                    _cart1.Remove(item);
                    Lbx_cart.ItemsSource = _cart1;
                    AddTotalPrice(_cart1);
                    break;


                }
            }

        }


        private void AddTotalPrice(ObservableCollection<CartItem> cartitems)
        {
            double totalPrice = cartitems.Select(x => x.quantityPrice).Sum();
            Tbk_totalPrice.Text = totalPrice.ToString();

        }


        
       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your Order is Placed!\n" + "Total Amount is:  " + Tbk_totalPrice.Text + "\n Your Table Number :  " + tbx_table.Text);
            tbx_table.Clear();
            Tbk_totalPrice.Text = "";
            _cart1.Clear();


        }
    }
}
