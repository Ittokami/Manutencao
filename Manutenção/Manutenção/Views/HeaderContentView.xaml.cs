using Manutenção.API;
using Manutenção.ViewModels;
using Plugin.Connectivity;
using Servico;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Manutenção.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeaderContentView : ContentView
    {
        List<Funcionarios> listfuncionarios;
        public HeaderContentView()
        {
            listfuncionarios = new List<Funcionarios>();

            InitializeComponent();           
        }   
    }
}