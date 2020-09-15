using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Food_app
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<Item> _item;
        public static ObservableCollection<CartItem> _cart;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            
            //CODE TO READ FROM XML
            //_item = Generateitem(100);
            //MyStorage.WriteXml<ObservableCollection<Item>>(_item, "Food_app.xml");
           _item = MyStorage.ReadXml<ObservableCollection<Item>>("Food_app.xml");


        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            //WRITE TO XML
            MyStorage.WriteXml<ObservableCollection<Item>>(_item, "Food_app.xml");
        }

        private ObservableCollection<Item> Generateitem(int cnt)
        {
            var lst = new ObservableCollection<Item>();
            for (int i = 0; i < cnt; i++)
            {
                lst.Add(new Item { name = "Name1" + i, description = "desc1" + i, price = 2 + i, itemtype = "itemtype1" });
            }
            return lst;




        }

       
    }
}
