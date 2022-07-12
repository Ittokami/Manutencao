using Manutenção.API;
using Manutenção.Models;
using Manutenção.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Manutenção.ViewModels
{
    [QueryProperty("PegarIdDaNavegacao", "parametro_id")]
    class CadastroAtividadeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string tipoServ, setorX, maquina, equipamento, descricao, responsavel, realizado, executante, executante1, executante2 ;
        int id;       
        DateTime data1, dataFim;
        TimeSpan timing, fim, inicio;
        double? patrimonio;
        

        public string PegarIdDaNavegacao
        {
            set
            {
                int id_parametro = Convert.ToInt32(Uri.UnescapeDataString(value));

                VerAtividade.Execute(id_parametro);
            }
        }

        public string TipoServ
        { 
            get => tipoServ;
            set
            {
                tipoServ = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TipoServ"));
            }
        }

        public string SetorX 
        { 
            get => setorX;
            set
            {
                setorX = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SetorX"));
            }
        }

        public string Maquina 
        { 
            get => maquina;
            set
            {
                maquina = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Maquina"));
            }
        }

        public string Equipamento 
        { 
            get => equipamento;
            set
            {
                equipamento = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Equipamento"));
            }
        }

        public string Descricao
        { 
            get => descricao;
            set
            {
                descricao = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Descricao"));
            }
        }

        public string Responsavel
        {
            get => responsavel;
            set
            {
                responsavel = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Responsavel"));
            }
    }
        public string Realizado
        {
            get => realizado;
            set
            {
                realizado = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Realizado"));
            }
        }
        public string Executante
        {
            get => executante;
            set
            {
                executante = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Executante"));
            }
        }
        public string Executante1
        {
            get => executante1;
            set
            {
                executante1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Executante1"));
            }
        }
        public string Executante2
        {
            get => executante2;
            set
            {
                executante2 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Executante2"));
            }
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Id"));
            }
        }
        public DateTime Data1
        { 
            get => data1;
            set
            {
                data1 = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Data1"));
            }
        }
        public DateTime DataFim
        {
            get => dataFim;
            set
            {
                dataFim = value;
                PropertyChanged(this, new PropertyChangedEventArgs("DataFim"));
            }
        }
        public TimeSpan Timing
        {
            get => timing;
            set
            {
                timing = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Timing"));
            }
        }

        public TimeSpan Inicio
        {
            get => inicio;
            set
            {
                inicio = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Inicio"));
            }
        }
        public TimeSpan Fim
        {
            get => fim;
            set
            {
                fim = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Fim"));
            }
        }
        public double? Patrimonio
        {
            get => patrimonio;
            set
            {
                patrimonio = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Patrimonio"));
            }
        }    

        public ICommand NovaAtividade
        {
            get => new Command(() =>
            {
                Id = 0;
                TipoServ = String.Empty;
                SetorX = String.Empty;
                Maquina = String.Empty;
                Equipamento = String.Empty;
                Descricao = String.Empty;
                Responsavel = String.Empty;
                Realizado = String.Empty;
                Executante = String.Empty;
                Data1 = DateTime.Now;
                DataFim = DateTime.Now;
                Timing = TimeSpan.Zero;
                Inicio = TimeSpan.Zero;
                Fim = TimeSpan.Zero;
                Patrimonio = null;
            });
        }

        public ICommand SalvarAtividade
        {
            get => new Command(async () =>
            {
                try
                {
                    Atividade atividades = new Atividade()
                    {
                        TipoServ = this.TipoServ,
                        SetorX = this.SetorX,
                        Maquina = this.Maquina,
                        Equipamento = this.Equipamento,
                        Descricao = this.Descricao,
                        Responsavel = this.Responsavel,
                        Realizado = this.Realizado,
                        Executante = this.Executante,
                        Data1 = this.Data1,
                        DataFim = this.DataFim,
                        Timing = this.Timing,
                        Inicio = this.Inicio,
                        Fim = this.Fim,
                        Patrimonio = this.Patrimonio
                    };

                    if (this.Id == 0)
                    {
                        await App.Database.Insert(atividades);
                        
                    }
                    else
                    {
                        atividades.Id = this.Id;
                        await App.Database.Update(atividades);
                    }
                    
                    await Application.Current.MainPage.DisplayAlert("CERTO!", "ENVIADO!", "OK");

                    await Shell.Current.GoToAsync("//MinhasAtividades");
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                }
            });
        }

        public ICommand VerAtividade
        {
            get => new Command<int>(async (int id) =>
            {
                try
                {
                    Atividade atividades = await App.Database.GetById(id);

                    this.Id = atividades.Id;
                    this.TipoServ = atividades.TipoServ;
                    this.SetorX = atividades.SetorX;
                    this.Maquina = atividades.Maquina;
                    this.Equipamento = atividades.Equipamento;
                    this.Descricao = atividades.Descricao;
                    this.Responsavel = atividades.Responsavel;
                    this.Realizado = atividades.Realizado;
                    this.Executante = atividades.Executante;
                    this.Data1 = atividades.Data1;
                    this.DataFim = atividades.DataFim;
                    this.Timing = atividades.Timing;
                    this.Inicio = atividades.Inicio;
                    this.Fim = atividades.Fim;
                    this.Patrimonio = atividades.Patrimonio; 
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                }
            });
        }
    }
}
