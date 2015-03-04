using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StatClient.Lib
{
    public class CommandBinder : ICommand
    {
        Action<object> _clickDelegate;

        public CommandBinder(Action<object> clickDelegate)
        {
            if (clickDelegate != null)
            {
                this._clickDelegate += clickDelegate;
            }
        }

        /// <summary>
        /// Lets caller know if it is safe to execute the command.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {

            return this._clickDelegate != null;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (_clickDelegate != null)
                _clickDelegate(parameter);
        }
    }
}
