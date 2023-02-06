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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFDay03
{
    /// <summary>
    /// Interaction logic for AnimationWindow.xaml
    /// </summary>
    public partial class AnimationWindow : Window
    {
        public AnimationWindow()
        {
            InitializeComponent();
        }

        private void Rect_Animation(object sender, MouseEventArgs e)
        {
            //1
            DoubleAnimation Animation1=new DoubleAnimation();

            //2
            Animation1.From = 100;
            Animation1.To = 400;
            Animation1.Duration = TimeSpan.FromSeconds(3);
            Animation1.AutoReverse = true;
            Animation1.RepeatBehavior = RepeatBehavior.Forever;

            //3
           // rect.BeginAnimation(WidthProperty ,Animation1);
            //rect.BeginAnimation(HeightProperty ,Animation1);




        }
    }
}
