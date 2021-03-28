using System;

namespace Series
{
    class Program
    {
        private static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        listaSeries();
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
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                    
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }



        #region OBTER RESPOSTA DO USUARIO
        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        #endregion






        #region LISTAR SERIES
        public static void listaSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), excluido ? "- Excluido" : "");
            }
        }
        #endregion







        #region INSERIR SERIES
        public static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            
            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                id: repositorio.ProximoId(), 
                genero:(Genero)entradaGenero,
                titulo:entradaTitulo,
                ano:entradaAno,
                descricao: entradaDescricao
            );


            repositorio.Insere(novaSerie);
        }
        #endregion








        #region ATUALIZAR SERIE
        public static void AtualizarSerie()
        {
            System.Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());


            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
            }

            System.Console.WriteLine("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            
            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie entradaSerie = new Serie(
                id: indiceSerie, 
                genero:(Genero)entradaGenero,
                titulo:entradaTitulo,
                ano:entradaAno,
                descricao: entradaDescricao
            );


            repositorio.Atualiza(indiceSerie, entradaSerie);
        }
        #endregion









        #region EXCLUIR SERIE
        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série: ");

            int indiceSerie = int.Parse(Console.ReadLine());

            string entradaConfirmacao = "";

            /********************************
            * Caso o usuário insira uma resposta
            * diferente de 1 ou 2, o programa 
            * fará a pergunta novamente até 
            * que seja inserido uma resposta válida
            *********************************/

            do{
                Console.WriteLine($"Deseja realmente excluir a série de indice {indiceSerie}? ");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não");

                entradaConfirmacao = Console.ReadLine();
            }while(entradaConfirmacao != "1" && entradaConfirmacao != "2");

            if(entradaConfirmacao == "1")
                repositorio.Exclui(indiceSerie);
        }
        #endregion







        #region VISUALIZAR SERIE
        public static void VisualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);


            Console.WriteLine(serie);
        }
        #endregion
    }
}
