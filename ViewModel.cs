using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Windows.Input;


namespace MVVMКалькулятор
{
    class ViewModel : INotifyPropertyChanged
    {
        public CommandBinding bind; // создание привязки

        public ViewModel()//конструктор в котором происходит привязка
        {
            bind = new CommandBinding(Command);
            bind.Executed += Command_Executed;
        }
        

        int ListCBid = -1;// индекс выбранного элемента списка
        int res = 0;

        public string Res // свойство возвращающие результат вычислений
        {
            get 
            {
                return res + "";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        int N1 = 0, N2 = 0;// значение первого и второго числа
        public string Number1// свойства которые возвращают и меняют значение чисел
        {
            get 
            {
                return N1 + "";                    
            }
            set 
            {
                N1 = Convert.ToInt32(value);
            }
           
        }
        public string Number2
        {
            get
            {
                return N2 + "";
            }
            set
            {
                N2 = Convert.ToInt32(value);
            }

        }

        public List<string> ListCB { get; } = Model.SignList; // свойство которое получает список 

        public int CBind
        {
            
            set
            {
                ListCBid = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SignView"));
            }
        }

        public string SignView 
        {
            get
            {
                string sign;
                switch (ListCBid)
                {
                    case 0:
                        sign = "+";
                        break;
                    case 1:
                        sign = "-";
                        break;
                    case 2:
                        sign = "*";
                        break;
                    case 3:
                        sign = "/";
                        break;
                    default:
                        sign = " ";
                        break;
                }
                return sign;
            }
        }

        public RoutedCommand Command { get; set; } = new RoutedCommand();

        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            switch (ListCBid)
            {
                case 0:
                    res = N1 + N2;
                    break;
                case 1:
                    res = N1 - N2;
                    break;
                case 2:
                    res = N1 * N2;
                    break;
                case 3:
                    res = N1 / N2;
                    break;
                default:
                    res = 0;
                    break;
            }
            PropertyChanged(this, new PropertyChangedEventArgs("Res"));
        }




    }
}
