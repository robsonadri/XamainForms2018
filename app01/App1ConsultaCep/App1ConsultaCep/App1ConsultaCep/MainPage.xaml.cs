using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1ConsultaCep.Servico.Modelo;
using App1ConsultaCep.Servico;

namespace App1ConsultaCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs e)
        {
            
            string cep = CEP.Text.Trim();

            if (ValidarCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = String.Format("Endereço : {0} {1}, {2}", end.logradouro, end.complemento, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("Erro", "Cep nao encontrado", "OK");
                    }
                    
                }
                catch
                {
                    DisplayAlert("Erro Crítico", "erro", "Ok");
                }
                
            }

        }

        private bool ValidarCEP(string cep)
        {
            bool valida = true;
            
            if (cep.Length!=8)
            {
                DisplayAlert("Erro", "Cep invalido", "OK");
                valida = false;
            }

            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("Erro", "Cep nao pode conter letras", "OK");
                valida = false;
            }

            return valida;

        }
    }
}
