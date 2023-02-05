using System;
using System.Collections.Generic;
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

namespace Task_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private char _divide = '÷';
        private char _times = '×';
        private char _minus = '-';
        private char _plus = '+';
        private char _equal = '=';
        private char _dot = '.';

        private string _str_operation = "";

        private bool _startnew = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button num)
            {
                if (_startnew)
                {
                    _str_operation = "";
                    _startnew = false;
                }
                _str_operation += GetNumber(num).ToString();
                screen.Text = _str_operation;
            }

        }

        private void OpClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button op)
            {
                char c = GetOperator(op);
                
                if (_startnew)
                {
                    if (c == _minus || c == _dot) {
                        _startnew = false;
                        _str_operation = "";
                    }
                    else return;
                }

                if (c != _equal) {
                    _str_operation += c.ToString();
                    screen.Text = _str_operation;
                }

                else
                {
                    _str_operation = ExpressionEvaluator.EvaluateExpression(_str_operation).ToString();
                    screen.Text = _str_operation;
                    _startnew = true;
                }

            }
        }

        private int GetNumber(Button num)
        {
            int tmp = num.Name.ToString() switch
            {
                "zero" => 0,
                "one" => 1,
                "two" => 2,
                "three" => 3,
                "four" => 4,
                "five" => 5,
                "six" => 6,
                "seven" => 7,
                "eight" => 8,
                "nine" => 9,
                _ => 0
            };

            return tmp;
        }

        private char GetOperator(Button op)
        {
            char tmp = op.Name.ToString() switch
            {
                "plus" => _plus,
                "minus" => _minus,
                "divide" => _divide,
                "times" => _times,
                "equal" => _equal,
                "dot" => _dot,
                _ => _plus
            };

            return tmp;
        }


    }
}

