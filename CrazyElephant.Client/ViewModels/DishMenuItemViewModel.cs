using CrazyElephant.Client.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyElephant.Client.ViewModels
{
    //继承Prism框架中的BindableBase代表此类与View的元素有绑定关系，表现为交互能力
    class DishMenuItemViewModel : BindableBase
    {
        //ViewModel与Model的交互可以有三种方法：
        //1.ViewModel中创建与Model相同的属性，进行属性拷贝，适用于Model中存在大量属性，而ViewModel只需其中一部分的情况
        //2.ViewModel中的类继承自Model类，但采用此种方法会破坏MVVM的设计原则
        //3.如下，ViewModel中含有Model类
        public Dish Dish { get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }


    }
}
