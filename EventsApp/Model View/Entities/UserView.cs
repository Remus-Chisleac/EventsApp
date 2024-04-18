using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Model_View.Entities
{
    public class UserView : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string? Name { get; set; }
    }
}
