using System;
using AppSeries;
using System.Collections.Generic;

namespace DIOSeries.Console {
    class Program {

        static SerieRepositorio serieRepositorio = new SerieRepositorio();

        static void Main(string[] args) {

            //Descomente o método abaixo se quiser testar já com algum valor definido
            ValoresTeste();

            string opcao = ObterOpcaoUsuario();
            while (opcao != "X") {
                switch (opcao) {
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
                        System.Console.WriteLine("Informe uma opção válida");
                        System.Console.ReadKey();
                        break;
                }

                opcao = ObterOpcaoUsuario();

            }


        }

        static void ValoresTeste() {
            var temp = serieRepositorio;
            temp.Insere(new Serie(0, Genero.Aventura, "Homem Aranha", "Já nos cinemas", 2010));
            temp.Insere(new Serie(1, Genero.Aventura, "Homem Aranha 2", "Já nos cinemas", 2011));
            temp.Insere(new Serie(2, Genero.Aventura, "Homem Aranha 3", "Já nos cinemas", 2012));
            temp.Insere(new Serie(3, Genero.Aventura, "Homem Aranha 4", "Já nos cinemas", 2013));
            temp.Insere(new Serie(4, Genero.Aventura, "Homem Aranha 5", "Já nos cinemas", 2014));
            temp.Insere(new Serie(5, Genero.Aventura, "Homem Aranha 6", "Já nos cinemas", 2015));
        }

        static string ObterOpcaoUsuario() {
            System.Console.Clear();
            System.Console.WriteLine("Series e tudo mais");
            System.Console.WriteLine("Informe a opção desejada:");

            System.Console.WriteLine("1- Listar Séries");
            System.Console.WriteLine("2- Inserir nova série");
            System.Console.WriteLine("3- Atualizar série");
            System.Console.WriteLine("4- Excluir série");
            System.Console.WriteLine("5- Visualizar série");
            System.Console.WriteLine("X- Sair");

            System.Console.WriteLine();
            return System.Console.ReadLine().ToUpper();

        }

        static void ListarSeries() {
            System.Console.Clear();
            System.Console.WriteLine("Listar Séries");

            var repositorio = serieRepositorio;
            List<Serie> lista = repositorio.Lista();

            if (lista.Count == 0) {
                System.Console.WriteLine("Nenhuma série cadastrada");
                System.Console.ReadKey();
                return;
            }

            foreach (var item in lista) {
                System.Console.WriteLine($"#ID {item.retornaId()}: - {item.retornaTitulo()}");
            }
            System.Console.ReadKey();

        }

        static void InserirSerie() {
            System.Console.Clear();
            var repositorio = serieRepositorio;

            Genero genero = 0;
            string titulo = string.Empty;
            string descricao = string.Empty;
            int ano = -1;


            if (!AtribuirValorItemSerie($"Inserir Item", ref genero, ref titulo, ref descricao, ref ano)) return;


            Serie serie = new Serie(repositorio.ProximoId(), genero, titulo, descricao, ano);
            repositorio.Insere(serie);
            System.Console.WriteLine("Item inserido com sucesso!");
            System.Console.WriteLine();
        }

        static void AtualizarSerie() {
            var repositorio = serieRepositorio;
            List<Serie> lista = repositorio.Lista();

            if (!SeletorSerie("Atualizar Item", lista, out int id)) return;

            Genero genero = 0;
            string titulo = string.Empty;
            string descricao = string.Empty;
            int ano = -1;

            string descricaoDaAtribuicao = $"Atualizando Item - #ID:{lista[id].retornaId()}" + Environment.NewLine + Environment.NewLine;
            descricaoDaAtribuicao += lista[id].ToString();

            if (!AtribuirValorItemSerie(descricaoDaAtribuicao, ref genero, ref titulo, ref descricao, ref ano)) return;


            Serie serie = new Serie(id, genero, titulo, descricao, ano);
            repositorio.Atualiza(id, serie);
            System.Console.WriteLine("Dados Atualizados!");
            System.Console.ReadKey();


        }

        static void ExcluirSerie() {
            var repositorio = serieRepositorio;
            List<Serie> lista = repositorio.Lista();

            if (!SeletorSerie("Excluir Item", lista, out int id)) return;

            while (true) {
                System.Console.Clear();

                System.Console.WriteLine($"Item: #ID:{lista[id].retornaId()}");
                System.Console.WriteLine();
                System.Console.WriteLine(lista[id].ToString());
                System.Console.WriteLine("Você tem certeza que deseja deletar esse item? (S/N)");

                string opcao = System.Console.ReadLine();
                if (opcao.ToUpper() == "N" || opcao.ToUpper() == "X") {
                    return;

                } else if (opcao.ToUpper() == "S") {
                    repositorio.Exclui(id);
                    System.Console.WriteLine("Item excluído!");
                    System.Console.ReadKey();
                    return;
                }

                System.Console.WriteLine("Porfavor informe uma opção válida!");
                System.Console.ReadKey();


            }


        }

        static void VisualizarSerie() {
            var repositorio = serieRepositorio;
            List<Serie> lista = repositorio.Lista();

            if (!SeletorSerie("Visualizar Item", lista, out int id)) return;

            System.Console.Clear();

            System.Console.WriteLine($"Item: #ID:{lista[id].retornaId()}");
            System.Console.WriteLine();
            System.Console.WriteLine(lista[id].ToString());
            System.Console.ReadKey();
        }





        static bool AtribuirValorItemSerie(string descricaoDaAtribuicao, ref Genero genero, ref string titulo, ref string descricao, ref int ano) {
            System.Console.Clear();

            System.Console.WriteLine(descricaoDaAtribuicao);
            System.Console.WriteLine();

            System.Console.WriteLine("Gêneros ");
            foreach (var gen in Enum.GetValues(typeof(Genero))) {
                System.Console.WriteLine($"{(int)gen} - {gen}");
            }
            System.Console.WriteLine();
            System.Console.Write("Número do Gênero: ");

            try {
                genero = (Genero)Convert.ToInt32(System.Console.ReadLine());
            } catch {
                System.Console.WriteLine("[ERRO] Valor informado inválido! Cancelando Pedido.");
                System.Console.ReadKey();
                return false;
            }
            System.Console.Write("Título: ");
            titulo = System.Console.ReadLine();

            System.Console.Write("Descrição: ");
            descricao = System.Console.ReadLine();

            System.Console.Write("Ano do Filme: ");

            try {
                ano = Convert.ToInt32(System.Console.ReadLine());
            } catch {
                System.Console.WriteLine("[ERRO] Valor informado inválido! Cancelando Pedido.");
                System.Console.ReadKey();
                return false;
            }

            return true;
        }




        static bool SeletorSerie(string info, List<Serie> lista, out int id) {
            int itensPorPagina = 5;
            int paginaAtual = 1;
            int numPaginas = (int)Math.Ceiling((decimal)lista.Count / (decimal)itensPorPagina);

            while (true) {
                System.Console.Clear();
                System.Console.WriteLine(info);

                if (lista.Count == 0) {
                    System.Console.WriteLine("Nenhuma série cadastrada");
                    System.Console.ReadKey();
                    id = -1;
                    return false;
                }

                for (int i = (itensPorPagina * (paginaAtual - 1)); i < lista.Count; i++) {

                    if (lista[i].foiExcluido()) System.Console.WriteLine($"#{lista[i].retornaId()} - [ITEM EXCLUÍDO]");
                    else System.Console.WriteLine($"#{lista[i].retornaId()} - {lista[i].retornaTitulo()}");

                    if (i >= (itensPorPagina * paginaAtual) - 1) break;
                }
                System.Console.WriteLine();
                System.Console.WriteLine($"Página {paginaAtual}/{numPaginas} (Mudar página: -p <página>)");
                System.Console.WriteLine("Digite \"x\" para cancelar");
                System.Console.WriteLine();
                System.Console.Write("Digite o número desejado: ");
                string[] opcao = System.Console.ReadLine().Split(" ");

                if (opcao[0].ToUpper() == "X") {
                    id = -1;
                    return false;
                }

                // verifica se o usuário utilizou o comando "--p <int>"
                if (opcao[0] == "-p" && opcao.Length > 1) {
                    if (int.TryParse(opcao[1], out int arg)) {
                        if (arg > 0 && arg <= numPaginas) paginaAtual = arg;
                        continue;
                    }
                    System.Console.WriteLine("Comando usando incorretamente");
                    System.Console.ReadKey();
                    continue;
                }

                if (int.TryParse(opcao[0], out id)) {
                    if (id < 0 || id > lista.Count) {
                        System.Console.WriteLine("O item que você está tentando acessar não existe!");
                        System.Console.ReadKey();
                        continue;
                    } else if (lista[id].foiExcluido()) {
                        System.Console.WriteLine("O item que você está tentando acessar foi Excluído!");
                        System.Console.ReadKey();
                        continue;
                    }
                    return true;
                }

            }





        }


    }
}
