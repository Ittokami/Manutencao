using Manutenção.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Manutenção.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalhesRato : ContentPage
    {
        public DetalhesRato()
        {
            BindingContext = new DetalhesRatoViewModel();

            InitializeComponent();
        }      

        protected override void OnAppearing()
        {
            var vm = (DetalhesRatoViewModel)BindingContext;

            if (vm.Id == 0)
            {
                vm.NovaAtiv.Execute(null);
            }
        }
    }
}