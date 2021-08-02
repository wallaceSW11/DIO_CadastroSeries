using System;

namespace DIO.SeriesWall
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoDigitada = ObterOpcaoUsuario();

            while (opcaoDigitada.ToUpper() != "X")
            {
                switch (opcaoDigitada)
                {
                    case "1":
                      ListarSeries();
                      break;

                    case "2":
                      InserirSerie();
                      break;

                    case "3":
                      AtualizarSerie();
                      break;

                    case "4":
                      ExcluirSerie();
                      break;

                    case "5":
                      VisualizarSerie();
                      break;

                    default:
                      Console.WriteLine("Opção inválida");                    
                      break;                     

                }

                opcaoDigitada = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado pela preferência");
            Console.ReadLine();
            Environment.Exit(0);

        }

        private static void ListarSeries() 
        {
            LimparTela();
            TituloMenu("Séries cadastradas");
            Console.WriteLine();

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada no momento."); 
                Console.WriteLine();                           
                Console.WriteLine("Deseja cadastrar uma agora? (S/N)");
                string opcaoInformada = Console.ReadLine().ToUpper();

                if (opcaoInformada == "S")
                {
                    InserirSerie();
                    return;
                }

                LimparTela();
                ObterOpcaoUsuario();
            }

            Console.WriteLine("Código | Ano | Título");
            foreach (var serie in lista)
            {
                Console.WriteLine("{0}       {1}  {2}", serie.retornaId(), serie.retornaAno(), serie.retornaTitulo());
            }

            Console.WriteLine();
           
        }

        private static void InserirSerie()
        {     
            LimparTela();            
            TituloMenu("== Cadstrar nova série ==");
            Console.WriteLine();

            Console.WriteLine("Lista de categorias:");
            Console.WriteLine();
            Console.WriteLine("Código | Descrição");            

            repositorio.Insere(ObterSerieInformada());
            LimparTela();
            Console.WriteLine("Série cadastrada com sucesso!");
        }

        private static void AtualizarSerie()
        {
            LimparTela();
            TituloMenu("== Atualizar série ==");
            Console.WriteLine("Digite o código da série: ");
            int entradaId = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Lista de categorias:");
            foreach (int i in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine("{0}    {1}", i, Enum.GetName(typeof(Categoria), i));
            }

            repositorio.Atualiza(entradaId, ObterSerieInformada(entradaId)); 

            LimparTela();
            Console.WriteLine("Série cadastrada com sucesso!");       
            Console.WriteLine();

        }

        private static void ExcluirSerie()
        {
            LimparTela();
            TituloMenu("Excluir uma série");

            Console.WriteLine("Digite o código da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            repositorio.Exclui(entradaId);
            Console.WriteLine("Excluído com sucesso.");
        }

        private static void VisualizarSerie() 
        {
            LimparTela();
            TituloMenu("Dados da série");
            Console.WriteLine("Digite o código da série: ");
            int entradaId = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornarPorId(entradaId);

            Console.WriteLine(serie);
        }


        private static string ObterOpcaoUsuario()
        {
            TituloMenu("======== Series Wall =========");        
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine();
            Console.WriteLine(" 1 - Listar séries");
            Console.WriteLine(" 2 - Inserir série");
            Console.WriteLine(" 3 - Atualizar série");
            Console.WriteLine(" 4 - Excluir série");
            Console.WriteLine(" 5 - Visualizar série");
            Console.WriteLine(" X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            Console.WriteLine();
            return opcaoUsuario;
        }

        //utils
        private static void LimparTela()
        {
            Console.Clear();
        }

        private static void TituloMenu(string titulo) 
        {  
            Console.WriteLine("==============================");
            Console.WriteLine(titulo);
            Console.WriteLine("==============================");
        }

        private static Serie ObterSerieInformada(int idInformado = -1) 
        {
            foreach (int i in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine(" {0}        {1}", i, Enum.GetName(typeof(Categoria), i));
            }

            Console.WriteLine();
            Console.WriteLine("Digite o código da categoria entre as opções acima: ");
            int entradaCategoria = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Digite o Ano da série: ");
            int entradaAno = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            Console.WriteLine();

            Serie serieInformada = new Serie(
                id: idInformado != -1 ? idInformado : repositorio.ProximoId(),
                categoria: (Categoria)entradaCategoria,
                titulo: entradaTitulo,
                descricao: entradaDescricao,
                ano: entradaAno);

            return serieInformada;
        }
    }
}
