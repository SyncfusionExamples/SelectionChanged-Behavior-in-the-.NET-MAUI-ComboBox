using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Maui.Inputs;
using System.Linq;

namespace ComboBoxSample
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<object> tempselectedvalueCollection = new ObservableCollection<object>();

        private ObservableCollection<Employee> employeeCollection;
        public ObservableCollection<Employee> EmployeeCollection
        {
            get { return employeeCollection; }
            set
            {
                employeeCollection = value;
                RaisePropertyChanged("EmployeeCollection");

            }
        }

        private ObservableCollection<string> selectionobject = new ObservableCollection<string>();
        public ObservableCollection<string> SelectionObject
        {
            get { return selectionobject; }
            set
            {
                selectionobject = value;
                RaisePropertyChanged("SelectionObject");
            }
        }

        private List<string> selectedId = new List<string>();
        public List<string> SelectedId
        {
            get
            {
                return selectedId;
            }
            set
            {
                selectedId = value;
                RaisePropertyChanged("SelectedId");
            }
        }

        /// <summary>
        /// MultiSelect Mode SelectedItem 
        /// </summary>
        private ObservableCollection<object> selectedvalueCollection = new ObservableCollection<object>();

        public ObservableCollection<object> SelectedvalueCollection
        {
            get { return selectedvalueCollection; }
            set
            {
                selectedvalueCollection = value;
                RaisePropertyChanged("SelctedvalueCollection");

            }
        }


        /// <summary>
        /// MultiSelect Mode SelectedItem 
        /// </summary>
        private ObservableCollection<object> multiSelectedItem;

        public ObservableCollection<object> MultiSelectedItem
        {
            get { return multiSelectedItem; }
            set
            {
                multiSelectedItem = value;
                RaisePropertyChanged("SelectedItems");

                tempselectedvalueCollection.Clear();
                foreach (var item in multiSelectedItem)
                {
                    tempselectedvalueCollection.Add((item as Employee).Id);
                }
                SelectedvalueCollection = tempselectedvalueCollection;
            }
        }

        public EmployeeViewModel()
        {
            MultiSelectedItem = new ObservableCollection<object>();
            employeeCollection = new ObservableCollection<Employee>();
            employeeCollection.Add(new Employee() { Id = "1", Name = "John" });
            employeeCollection.Add(new Employee() { Id = "2", Name = "James" });
            employeeCollection.Add(new Employee() { Id = "3", Name = "Jacob" });
            employeeCollection.Add(new Employee() { Id = "4", Name = "Joy" });
            employeeCollection.Add(new Employee() { Id = "5", Name = "Justin" });
            employeeCollection.Add(new Employee() { Id = "6", Name = "Jerome" });
            employeeCollection.Add(new Employee() { Id = "7", Name = "Jessica" });
            employeeCollection.Add(new Employee() { Id = "8", Name = "Victoria" });
          
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }

   

}
