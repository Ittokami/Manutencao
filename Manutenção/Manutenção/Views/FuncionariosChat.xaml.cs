using Manutenção.API;
using Manutenção.Cell;
using Servico;
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
    public partial class FuncionariosChat : ContentPage
    {
        public List<Funcionarios> ListaFuncionarios;
        public FuncionariosChat()
        {
            InitializeComponent();
            ListaFuncionarios = new List<Funcionarios>();
            ListViewCliente.ItemTemplate = new DataTemplate(typeof(ClienteCell));
            ListViewCliente.RowHeight = 120;
            ListViewCliente.ItemSelected += ListViewCliente_ItemSelect;
        }

        private void ListViewCliente_ItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public async void CarregarClientes()
        {
            ListaFuncionarios = await ApiService.ObterFuncionarios();
            ListViewCliente.ItemsSource = ListaFuncionarios.ToList().OrderBy(x=>x.Nome).ToList();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CarregarClientes();
        }

        private void PesquisaCliente_TextChanged(object sender, TextChangedEventArgs e)
        {
            string textopesquisa = pesquisaCliente.Text;
            ListViewCliente.ItemsSource = ListaFuncionarios.Where(x=> x.Nome.ToLower().Contains(textopesquisa.ToLower())).ToList();
        }
    }
}