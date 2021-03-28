using System;
using System.Text;

namespace Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero {get;set;}
        private string Titulo {get;set;}
        private string Descricao {get;set;}
        private int Ano {get;set;}
        private bool Excluido {get;set;}


        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = Genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }


        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();
            retorno.AppendLine($"Gênero: {this.Genero}");
            retorno.AppendLine($"Titulo: {this.Titulo}");
            retorno.AppendLine($"Descrição: {this.Descricao}");
            retorno.AppendLine($"Ano de Início: {this.Ano}");
            retorno.AppendLine($"Excluido: " + this.Excluido);

            return retorno.ToString();
        }



        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }
    }
}