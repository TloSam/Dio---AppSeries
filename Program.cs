using System;


namespace Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":                       
                        ListarSeries();
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;

                    case "2":
                       InserirSerie();
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;
                    case "3":
                          AtualizarSerie();
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;
                    case "4":
                         ExcluirSerie();
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;
                    case "5":
                          VisualizarSerie();
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;
                    case "C":
                        Console.Clear();
                        opcaoUsuario = ObterOpcaoUsuario();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                        
                }
            }
           
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");
            
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }           
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
               
                
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo(), excluido ? " - Serie excluída do catálogo. ": "");
                
                
            }
            
        }
        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova Série");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescrição = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescrição);

            repositorio.Insere(novaSerie);

        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da Série: ");
            string entradaDescrição = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: indiceSerie, genero: (Genero)entradaGenero, titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescrição);

            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o ID da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o ID da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("c- Limpar Tela");
            Console.WriteLine("x- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
