using Manutenção.API;
using Manutenção.Models;
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
    public partial class ListaAtividades : ContentPage
    {
        public ListaAtividades()
        {
            BindingContext = new ListaAtividadesViewModel();     

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            var vm = (ListaAtividadesViewModel)BindingContext;

            vm.AtualizarLista.Execute(null);
        }
    }
}