using System;
using System.Collections.Generic;

namespace AppSeries
{
    class Program
    {
        static void Main(string[] args)
        {
            //Descomente o método abaixo se quiser testar já com algum valor definido
            //ValoresTeste();

            string opcao = ObterOpcaoUsuario();
            while(opcao != "X"){               
                switch(opcao){
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
                        Console.WriteLine("Informe uma opção válida");
                        Console.ReadKey();
                        break;
                }

                opcao = ObterOpcaoUsuario();

            }

            
        }

        static void ValoresTeste(){
            var temp = SerieRepositorio.GetInstance();
            temp.Insere(new Serie(0, Genero.Aventura, "Homem Aranha","Já nos cinemas", 2010));
            temp.Insere(new Serie(1, Genero.Aventura, "Homem Aranha 2","Já nos cinemas", 2011));
            temp.Insere(new Serie(2, Genero.Aventura, "Homem Aranha 3","Já nos cinemas", 2012));
            temp.Insere(new Serie(3, Genero.Aventura, "Homem Aranha 4","Já nos cinemas", 2013));
            temp.Insere(new Serie(4, Genero.Aventura, "Homem Aranha 5","Já nos cinemas", 2014));
            temp.Insere(new Serie(5, Genero.Aventura, "Homem Aranha 6","Já nos cinemas", 2015));
        }

        static string ObterOpcaoUsuario(){
            Console.Clear();
            Console.WriteLine("Series e tudo mais");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1- Listar Séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("X- Sair");

            Console.WriteLine();
            return Console.ReadLine().ToUpper();

        }

        static void ListarSeries(){
            Console.Clear();
            Console.WriteLine("Listar Séries");

            var repositorio = SerieRepositorio.GetInstance();
            List<Serie> lista = repositorio.Lista();

            if(lista.Count == 0){
                Console.WriteLine("Nenhuma série cadastrada");
                Console.ReadKey();
                return;
            }

            foreach(var item in lista){
                Console.WriteLine($"#ID {item.retornaId()}: - {item.retornaTitulo()}");
            }
            Console.ReadKey();

        }

        static void InserirSerie(){
            Console.Clear();
            var repositorio = SerieRepositorio.GetInstance();

             Genero genero = 0;
             string titulo = string.Empty;
             string descricao = string.Empty;
             int ano = -1;


            if(!AtribuirValorItemSerie($"Inserir Item", ref genero, ref titulo, ref descricao, ref ano)) return;


            Serie serie = new Serie(repositorio.ProximoId(), genero, titulo, descricao, ano);
            repositorio.Insere(serie);
            Console.WriteLine("Item inserido com sucesso!");
            Console.WriteLine();
        }

        static void AtualizarSerie(){
            var repositorio = SerieRepositorio.GetInstance();
            List<Serie> lista = repositorio.Lista();

            if(!SeletorSerie("Atualizar Item", lista, out int id)) return;

             Genero genero = 0;
             string titulo = string.Empty;
             string descricao = string.Empty;
             int ano = -1;

            string descricaoDaAtribuicao = $"Atualizando Item - #ID:{lista[id].retornaId()}" + Environment.NewLine + Environment.NewLine;
            descricaoDaAtribuicao += lista[id].ToString();

            if(!AtribuirValorItemSerie(descricaoDaAtribuicao, ref genero, ref titulo, ref descricao, ref ano)) return;


            Serie serie = new Serie(id, genero, titulo, descricao, ano);
            repositorio.Atualiza(id, serie);
            Console.WriteLine("Dados Atualizados!");
            Console.ReadKey();


        }

        static void ExcluirSerie(){
            var repositorio = SerieRepositorio.GetInstance();
            List<Serie> lista = repositorio.Lista();
           
            if(!SeletorSerie("Excluir Item", lista, out int id)) return;

            while(true){
                Console.Clear();

                Console.WriteLine($"Item: #ID:{lista[id].retornaId()}");
                Console.WriteLine();
                Console.WriteLine(lista[id].ToString());
                Console.WriteLine("Você tem certeza que deseja deletar esse item? (S/N)");

                string opcao = Console.ReadLine();
                if(opcao.ToUpper() == "N" || opcao.ToUpper() == "X"){
                    return;

                }else if(opcao.ToUpper() == "S"){
                    repositorio.Exclui(id);
                    Console.WriteLine("Item excluído!");
                    Console.ReadKey();
                    return;
                }

                Console.WriteLine("Porfavor informe uma opção válida!");
                Console.ReadKey();

               
            }


        }

        static void VisualizarSerie(){
            var repositorio = SerieRepositorio.GetInstance();
            List<Serie> lista = repositorio.Lista();
           
            if(!SeletorSerie("Visualizar Item", lista, out int id)) return;

            Console.Clear();

            Console.WriteLine($"Item: #ID:{lista[id].retornaId()}");
            Console.WriteLine();
            Console.WriteLine(lista[id].ToString());
            Console.ReadKey();
        }





        static bool AtribuirValorItemSerie(string descricaoDaAtribuicao, ref Genero genero, ref string titulo, ref string descricao, ref int ano){
            Console.Clear();

            Console.WriteLine(descricaoDaAtribuicao);
            Console.WriteLine();

            Console.WriteLine("Gêneros ");
            foreach(var gen in Enum.GetValues(typeof(Genero))){
                Console.WriteLine($"{(int) gen} - {gen}");
            }
            Console.WriteLine();
            Console.Write("Número do Gênero: ");

            try{
               genero = (Genero) Convert.ToInt32(Console.ReadLine());
            } catch{
                Console.WriteLine("[ERRO] Valor informado inválido! Cancelando Pedido.");
                Console.ReadKey();
                return false;
            }
            Console.Write("Título: ");
            titulo = Console.ReadLine();

            Console.Write("Descrição: ");
            descricao = Console.ReadLine();

            Console.Write("Ano do Filme: ");

            try{
                ano = Convert.ToInt32(Console.ReadLine());
            }catch{
                Console.WriteLine("[ERRO] Valor informado inválido! Cancelando Pedido.");
                Console.ReadKey();
                return false;                
            }

            return true;
        }




        static bool SeletorSerie(string info, List<Serie> lista, out int id){          
            int itensPorPagina = 5;
            int paginaAtual = 1;
            int numPaginas = (int) Math.Ceiling((decimal) lista.Count/ (decimal) itensPorPagina);

            while(true){
                Console.Clear();
                Console.WriteLine(info);

                if(lista.Count == 0){
                    Console.WriteLine("Nenhuma série cadastrada");
                    Console.ReadKey();
                    id = -1;
                    return false;
                }

                for(int i = (itensPorPagina * (paginaAtual - 1)); i < lista.Count; i++){

                    if(lista[i].foiExcluido()) Console.WriteLine($"#{lista[i].retornaId()} - [ITEM EXCLUÍDO]");
                    else Console.WriteLine($"#{lista[i].retornaId()} - {lista[i].retornaTitulo()}");

                    if(i >= (itensPorPagina * paginaAtual) -1) break;
                }
                Console.WriteLine();
                Console.WriteLine($"Página {paginaAtual}/{numPaginas} (Mudar página: -p <página>)");
                Console.WriteLine("Digite \"x\" para cancelar");  
                Console.WriteLine();
                Console.Write("Digite o número desejado: ");
                string[] opcao = Console.ReadLine().Split(" ");

                if(opcao[0].ToUpper() == "X"){
                    id = -1;
                    return false;
                }

                // verifica se o usuário utilizou o comando "--p <int>"
                if(opcao[0] == "-p" && opcao.Length > 1){
                    if(int.TryParse(opcao[1], out int arg)){
                        if(arg > 0 && arg <= numPaginas) paginaAtual = arg;
                        continue;
                    }
                    Console.WriteLine("Comando usando incorretamente"); 
                    Console.ReadKey();
                    continue;   
                }

                if(int.TryParse(opcao[0], out id)){
                    if(id < 0 || id > lista.Count){
                        Console.WriteLine("O item que você está tentando acessar não existe!");
                        Console.ReadKey();
                        continue;
                    }else if(lista[id].foiExcluido()){
                        Console.WriteLine("O item que você está tentando acessar foi Excluído!");
                        Console.ReadKey();
                        continue;
                    }
                    return true;
                }

            }



            

        }


    }
}
