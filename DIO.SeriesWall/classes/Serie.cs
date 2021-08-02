using System;

namespace DIO.SeriesWall
{
    public class Serie : EntidadeBase    
    {
        private Categoria Categoria { get; set; }
        private string Titulo { get; set; }        
        private string Descricao { get; set; }
        private int Ano  { get; set; }
        public bool Excluido { get; set; }
        
        

        public Serie(int id, Categoria categoria, string titulo, string descricao, int ano) {
            this.Id = id;
            this.Categoria = categoria;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        
        public override string ToString() {
            string retorno = string.Empty;
            retorno += "Categoria: " + this.Categoria + Environment.NewLine;
            retorno += "   Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "      Ano: " + this.Ano + Environment.NewLine;
            retorno += " Excluído: " + serieExcluida();
            return retorno;
        }
        
        public string retornaTitulo() 
        {
            return this.Titulo;
        }
        
        public int retornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public int retornaAno()
        {
            return this.Ano;
        } 

        public string serieExcluida()
        {
            return (this.Excluido ? "Sim" : "Não");
        }       
        
    }
}