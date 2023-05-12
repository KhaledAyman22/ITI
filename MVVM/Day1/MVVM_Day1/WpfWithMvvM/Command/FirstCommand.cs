using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfWithMvvM.Command
{
    internal class FirstCommand : ICommand
    {
        Action<object> excute;
        Predicate<object> canExcute;
        public FirstCommand(Action<object> _excute,Predicate<object> _canExcute)
        {
            excute = _excute;
            canExcute = _canExcute;

        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return canExcute==null?true:canExcute.Invoke(parameter);
        }

        public void Execute(object? parameter)
        {
            excute.Invoke(parameter);
        }
    }
}
