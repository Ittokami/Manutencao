using Manutenção.Models;
using Manutenção.Views;
using Manutenção;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Manutenção.ViewModels
{
    [QueryProperty("PegarIdDaNavegacao", "parametro_id")]
    class DetalhesRatoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string tipoServ, setorX, maquina, equipamento, descricao, responsavel, realizado, executante, executante1, executante2;
        int id;
        DateTime data1, dataFim;
        TimeSpan timing, fim;
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

        public ICommand NovaAtiv
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
                Fim = TimeSpan.Zero;
                Patrimonio = null;
            });
        }

        public ICommand SalvarAtv
        {
            get => new Command(async () =>
            {
                try
                {
                    Atividade model = new Atividade()
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
                        Fim = this.Fim,
                        Patrimonio = this.Patrimonio
                    };

                    if (this.Id == 0)
                    {
                        await App.Database.Insert(model);
                    }
                    else
                    {
                        model.Id = this.Id;
                        await App.Database.Update(model);
                    }

                    await Application.Current.MainPage.DisplayAlert("CERTO!", "ENVIADO!", "OK");

                    await Shell.Current.GoToAsync("//AtividadesdoRato");

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
                    Atividade model = await App.Database.GetById(id);

                    this.Id = model.Id;
                    this.TipoServ = model.TipoServ;
                    this.SetorX = model.SetorX;
                    this.Maquina = model.Maquina;
                    this.Equipamento = model.Equipamento;
                    this.Descricao = model.Descricao;
                    this.Responsavel = model.Responsavel;
                    this.Realizado = model.Realizado;
                    this.Executante = model.Executante;
                    this.Data1 = model.Data1;
                    this.DataFim = model.DataFim;
                    this.Timing = model.Timing;
                    this.Fim = model.Fim;
                    this.Patrimonio = model.Patrimonio;
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "OK");
                }
            });
        }
    }
}
