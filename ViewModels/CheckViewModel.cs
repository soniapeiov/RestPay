using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPay.ViewModels
{
    public partial class CheckViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalFinal))]
        [NotifyPropertyChangedFor(nameof(GorjetaCalculada))]
        [NotifyPropertyChangedFor(nameof(ValorPessoal))]
        double _total;  // Total bill amount

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalFinal))]
        [NotifyPropertyChangedFor(nameof(GorjetaCalculada))]
        [NotifyPropertyChangedFor(nameof(ValorPessoal))]
        double _gorjeta;    // Tip amount

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(TotalFinal))]
        [NotifyPropertyChangedFor(nameof(GorjetaCalculada))]
        [NotifyPropertyChangedFor(nameof(ValorPessoal))]
        double _numPessoas = 1; // Default to 1 to avoid division by zero

        private double Arredonda(double total)
        {
            decimal n = 0;

            try
            {
                n = (decimal)total;
                n = System.Math.Ceiling(n * 100) / 100; // Round up to the nearest 100
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during rounding
                Console.WriteLine(ex.Message);
            }

            return (double)n;
        }

        public double GorjetaCalculada => Arredonda(Total * (Gorjeta / 100.0));
        public double TotalFinal => Arredonda(Total + GorjetaCalculada);
        public double ValorPessoal => Arredonda(TotalFinal / (NumPessoas * 1.0));
    }
}