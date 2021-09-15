using System;

namespace Cadastro.Series
{
    class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while( opcaoUsuario.ToUpper() != "X") {
                switch( opcaoUsuario ) {
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
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void ListarSeries() {
            Console.WriteLine("Listar séries.");

            var lista = repositorio.Lista();

            if( lista.Count == 0 ) {
                Console.WriteLine("Nenhuma série cadastrada.");
                return;
            }

            foreach( var serie in lista) {
                if( serie.retornaExcluido() == false ) {
                    Console.WriteLine($"Id: {serie.retornaId()} - {serie.retornaTitulo()}");
                }
            }
        }

        private static void InserirSerie() {
            Console.WriteLine("Inserir nova série.");

            foreach(int i in Enum.GetValues(typeof(Genero))) {
                Console.WriteLine($"{i}, {Enum.GetName(typeof(Genero), i)}");
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series novaSerie = new Series(
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Inserir(novaSerie);
        }

        private static void AtualizarSerie() {
            Console.WriteLine("Atualizar série.");

            Console.Write("Digite o Id da série a ser atualizada: ");
            int index = int.Parse(Console.ReadLine());

            foreach(int i in Enum.GetValues(typeof(Genero))) {
                Console.WriteLine($"{i}, {Enum.GetName(typeof(Genero), i)}");
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Series atualizaSerie = new Series(
                id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Atualizar(index, atualizaSerie);
        }

        private static void ExcluirSerie() {
            Console.WriteLine("Digite o Id da série a ser excluída: ");
            int indexSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indexSerie);
        }

        private static void VisualizarSerie() {
            Console.WriteLine("Digite o Id da série a ser visualizada: ");
            int indexSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indexSerie);

            if( serie.retornaExcluido() == true ) {
                Console.WriteLine("A série foi excluída!");
                return;
            }
            Console.WriteLine(serie);
        }


        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("Cadastro de Series de Tv!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1: Listar séries.");
            Console.WriteLine("2: Inserir nova série.");
            Console.WriteLine("3: Atualizar série.");
            Console.WriteLine("4: Excluir série.");
            Console.WriteLine("5: Visualizar série.");
            Console.WriteLine("C: Limpar Tela.");
            Console.WriteLine("X: Sair.");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
