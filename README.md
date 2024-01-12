# SelectionChanged-Behavior-in-the-.NET-MAUI-ComboBox
The sample demonstrates how to manage the SelectionChanged behaviors in the .NET MAUI ComboBox control.
# Getting Started with .NET MAUI ComboBox (SfComboBox)
## Adding a .NET MAUI ComboBox reference
Syncfusion .NET MAUI controls are available in Nuget.org. To add .NET MAUI ComboBox to your project, open the NuGet package manager in Visual Studio, search for Syncfusion.Maui.Inputs and then install it.

# Create a Simple .NET MAUI ComboBox
The .NET MAUI ComboBox control is configured entirely in C# code or by using XAML markup. The following steps explain how to create a .NET MAUI ComboBox (SfComboBox) and configure its elements:
## Adding the .NET MAUI ComboBox control

Step 1: Add the NuGet to the project as discussed in the above reference section.

Step 2: Add the namespace as shown in the following code sample:

**[XAML]**

```
xmlns:inputs="clr-namespace:Syncfusion.Maui.Inputs;assembly=Syncfusion.Maui.Inputs"
```

Step 3: Set the control to content in ContentPage.

**[XAML]**

```
<ContentPage.Content>    
    <inputs:SfComboBox x:Name="comboBox" />
</ContentPage.Content>
```
#   Add a SelectionChanged Behavior to the .NET MAUI SfComboBox

**[XAML]**

```
  <ContentPage.BindingContext>
   <local:EmployeeViewModel/>
</ContentPage.BindingContext>

<StackLayout Padding="50,100,50,0">
   <inputs:SfComboBox x:Name="comboBox"
                      WidthRequest="200"
                      IsEditable="True"
                      SelectedIndex="2"
                      DisplayMemberPath="Name" 
                      ItemsSource="{Binding EmployeeCollection}"
                      MaxDropDownHeight = "180">
       <inputs:SfComboBox.Behaviors>
           <local:SelectionChangedBehavior/>
       </inputs:SfComboBox.Behaviors>
   </inputs:SfComboBox>
</StackLayout>
```
##  SelectionChanged Behavior

**[C#]**
```
 ppublic class SelectionChangedBehavior : Behavior<SfComboBox>
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
```
## How to run this application?

To run this application, you need to first clone the How-to-bind-an-Enum-to-the-ItemsSource-property-of-.NET-MAUI-SfComboBox repository and then open it in Visual Studio 2022. Now, simply build and run your project to view the output.

## <a name="troubleshooting"></a>Troubleshooting ##
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion has no liability for any damage or consequence that may arise by using or viewing the samples. The samples are for demonstrative purposes, and if you choose to use or access the samples, you agree to not hold Syncfusion liable, in any form, for any damage that is related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion’s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion’s samples.
