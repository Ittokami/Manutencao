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
    public partial class AtividadesRato : ContentPage
    {

        public AtividadesRato()
        {
            BindingContext = new RatoAtividadesViewModel();

            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            var vm = (RatoAtividadesViewModel)BindingContext;

            vm.AtualizarLista.Execute(null);
        }
    }
}