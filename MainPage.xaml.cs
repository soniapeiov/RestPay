using RestPay.ViewModels;
using System.Runtime.CompilerServices;

namespace RestPay;

public partial class MainPage : ContentPage
{
    readonly CheckViewModel vm;

    public MainPage()
    {
        InitializeComponent();

        vm = (CheckViewModel)BindingContext;

        for (int i = 1; i < 16; i++)
        {
            NumPessoas.Items.Add(i.ToString());
        }
        NumPessoas.SelectedIndex = 0; // Default to 1 person
    }
    private void NumPessoas_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;
        if (selectedIndex != -1)
        {
            vm.NumPessoas = selectedIndex + 1; // Update the ViewModel with the selected number of people
        }
    }
}