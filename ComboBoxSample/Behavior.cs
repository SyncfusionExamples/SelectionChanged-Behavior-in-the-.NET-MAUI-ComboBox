using Syncfusion.Maui.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxSample
{
    public class SelectionChangedBehavior : Behavior<SfComboBox>
    {
        public Command Display { get; private set; }
        EmployeeViewModel employeeViewModel;
        protected override void OnAttachedTo(SfComboBox bindable)
        {
            bindable.SelectionChanged += Bindable_SelectionChanged;
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(SfComboBox bindable)
        {
            bindable.SelectionChanged -= Bindable_SelectionChanged;
            base.OnDetachingFrom(bindable);
        }

        async void Bindable_SelectionChanged(object sender, Syncfusion.Maui.Inputs.SelectionChangedEventArgs e)
        {
            employeeViewModel = new EmployeeViewModel();
            var selectedValue = e.CurrentSelection;
            var lastItem = selectedValue.Last();
            employeeViewModel.SelectedId = new List<string>();
            foreach (var item in selectedValue)
            {
                var selectedId = (item as Employee).Id;
                if (item == lastItem)
                {
                    employeeViewModel.SelectedId.Add(selectedId);
                    Application.Current.MainPage.DisplayAlert("Selected Id", "The last selected ID is " + selectedId, "Ok");
                }
                else
                {
                    employeeViewModel.SelectedId.Add(selectedId);
                }

            }
        }
    }

}
