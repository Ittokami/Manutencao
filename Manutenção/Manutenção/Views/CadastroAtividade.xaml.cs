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
    public partial class CadastroAtividade : ContentPage
    {
        public CadastroAtividade()
        {
            BindingContext = new CadastroAtividadeViewModel();
            InitializeComponent();
                  
        }
        protected override void OnAppearing()
        {
            var vm = (CadastroAtividadeViewModel)BindingContext;

            if (vm.Id == 0)
            {
                vm.NovaAtividade.Execute(null);
            }
        }
        
    }
}