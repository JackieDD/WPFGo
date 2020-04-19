using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingGo
{
   public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;
        private List<Student> students; 
        public string Name
        {
            

            get { return name; }

            set
            {
                name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));

            }
        }

        public List<Student> Students
        {
            get { return students; }
            set
            {
                students = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Students)));
            }
        }

    }
}
