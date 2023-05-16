using CrazyElephant.Client.Models;
using CrazyElephant.Client.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CrazyElephant.Client.ViewModels
{
    class MainWindowViewModel : BindableBase
    {
        public DelegateCommand PlaceOrderCommand { get; set; }
        public DelegateCommand SelectMenuItemCommand { get; set; }

        private int count;

        public int Count
        {
            get { return count; }
            set
            {
                count = value;
                this.RaisePropertyChanged("Count");
            }
        }

        private Restaurant restaurant;

        public Restaurant Restaurant
        {
            get { return restaurant; }
            set
            {
                restaurant = value;
                this.RaisePropertyChanged("Restaurant");
            }
        }

        //单独划分出DishMenuItemViewModel，是为了实现单独checkbox选取菜品的机能
        private List<DishMenuItemViewModel> dishMenu;

        public List<DishMenuItemViewModel> DishMenu
        {
            get { return dishMenu; }
            set
            {
                dishMenu = value;
                this.RaisePropertyChanged("DishMenu");
            }
        }

        public MainWindowViewModel()
        {
            this.LoadRestaurant();
            this.LoadDishMenu();
            this.PlaceOrderCommand = new DelegateCommand(new Action(this.PlaceOrderCommandExecute));
            this.SelectMenuItemCommand = new DelegateCommand(new Action(this.SelectMenuItemCommandExecute));

        }

        private void SelectMenuItemCommandExecute()
        {
            this.Count = this.DishMenu.Count(i => i.IsSelected == true);
        }

        private void PlaceOrderCommandExecute()
        {
            //此处用了LINQ
            var selectedDishes = this.dishMenu.Where(i => i.IsSelected == true).Select(i => i.Dish.Name).ToList();
            IOrderSevice orderSevice = new MockOrderService();
            orderSevice.PlaceOrder(selectedDishes);
            MessageBox.Show("订餐成功！");
        }

        private void LoadDishMenu()
        {
            XmlDataService ds = new XmlDataService();
            var dishes = ds.GetAllDishes();
            this.dishMenu = new List<DishMenuItemViewModel>();
            foreach (var dish in dishes)
            {
                DishMenuItemViewModel item = new DishMenuItemViewModel();
                item.Dish = dish;
                this.DishMenu.Add(item);
            }
        }

        private void LoadRestaurant()
        {
            this.Restaurant = new Restaurant();
            this.Restaurant.Name = "吉野家";
            this.Restaurant.Address = "东京墨田区锦系町";
            this.Restaurant.PhoneNumber = "080-0654-3210";

        }
    }
}
