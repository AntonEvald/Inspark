using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Inspark.Viewmodels
{
    class AddCodeViewModel
    {
        public string Code { get; set; }

        public ICommand OK_Command => new Command( () =>
        {
            //Kod
        });
    }
}
