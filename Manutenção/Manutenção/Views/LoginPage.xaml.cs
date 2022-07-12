using Manutenção.API;
using Plugin.Connectivity;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Manutenção.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        List<Funcionarios> listfuncionarios;
        public LoginPage()
        {
            InitializeComponent();
            listfuncionarios = new List<Funcionarios>();
        }
        public async void Logar()
        {

            if (CrossConnectivity.Current.IsConnected)
            {
                if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(txtSenha.Text))
                {
                    await DisplayAlert("Ops, Erro!!", "Informe seu Nº de Usuario e(ou) Senha!!", "OK");
                }
                listfuncionarios = await ApiService.ObterFuncionarios();

                var funcionarios = listfuncionarios.Where(x => x.Usuario.ToLower() == txtUsuario.Text.ToLower() && x.Senha.ToLower() == txtSenha.Text.ToLower()).ToList();

                if (funcionarios.Count > 0)
                {
                    Application.Current.MainPage = new MainPage();
                }
               
                else
                {
                    await DisplayAlert("Erro", "Nº DE USUÁRIO E(OU) SENHA INCORRETOS", "OK");
                }
            }
            else
            {
                await DisplayAlert("Ops, Erro!!", "SEM CONEXÃO COM A INTERNET", "OK");
            }
        }
        public void BtnLogin_Clicked(object sender, EventArgs e)
        {
            Logar();
        }
    }
}