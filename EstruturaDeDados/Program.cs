using System.Diagnostics; // Para medir o tempo de execução
using SortingApp.Helpers; // Para usar métodos de ajuda, como gerar arrays aleatórios
using SortingApp.SortingAlgorithms; // Para acessar os algoritmos de ordenação

class Program
{
    static void Main(string[] args)
    {
        // Cabeçalho do projeto
        MostrarCabecalho();
        
        string resposta = "s"; // Inicializa a variável 'resposta' para controle do loop
        do
        {
            // Menu interativo para o usuário escolher uma opção
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1 - Gerar lista de números aleatórios");
            Console.WriteLine("2 - Ler lista de um arquivo");
            Console.WriteLine("3 - Inserir dados manualmente");
            Console.WriteLine("4 - Sair");
            int opcaoMenu = int.Parse(Console.ReadLine());

            int[] lista = null; // Declaração da lista a ser ordenada

            switch (opcaoMenu)
            {
                case 1:
                    // Geração de dados aleatórios
                    Console.WriteLine("Opção escolhida: Gerar lista de números aleatórios.");
                    lista = ArrayHelper.GenerateRandomArray(20, 1, 100); // Gera uma lista aleatória
                    Console.WriteLine("Lista gerada: " + string.Join(", ", lista));
                    break;

                case 2:
                    // Ler lista de um arquivo
                    Console.WriteLine("Opção escolhida: Ler lista de um arquivo.");
                    lista = LerListaDeArquivo(); // Chama método para ler a lista de um arquivo
                    if (lista != null)
                    {
                        Console.WriteLine("Lista lida: " + string.Join(", ", lista));
                    }
                    break;

                case 3:
                    // Inserir dados manualmente
                    Console.WriteLine("Opção escolhida: Inserir dados manualmente.");
                    lista = InserirDadosManualmente(); // Chama método para inserir dados manualmente
                    break;

                case 4:
                    Console.WriteLine("Opção escolhida: Sair do programa.");
                    Console.WriteLine("Saindo do programa.");
                    return; // Encerra o programa

                default:
                    Console.WriteLine("Opção inválida. Tente novamente."); // Mensagem para opção inválida
                    continue; // Retorna ao início do loop
            }

            // Escolher o algoritmo de ordenação
            var algoritmoEscolhido = EscolherAlgoritmo(); // Chama método para escolher o algoritmo

            // Medir o tempo de execução do algoritmo escolhido
            Stopwatch stopwatch = Stopwatch.StartNew(); // Inicia o cronômetro
            SortingAlgorithms.Ordenar(algoritmoEscolhido, lista); // Ordena a lista com o algoritmo escolhido
            stopwatch.Stop(); // Para o cronômetro

            // Mostrar a lista ordenada e o tempo de execução
            Console.WriteLine("Lista ordenada: " + string.Join(", ", lista));
            Console.WriteLine($"Tempo para ordenar: {stopwatch.ElapsedMilliseconds} ms");

            // Busca binária
            RealizarBusca(lista); // Chama método para realizar busca na lista ordenada

            // Pergunta se o usuário deseja repetir
            Console.WriteLine("Deseja fazer outra operação? (s/n)");
            resposta = Console.ReadLine().ToLower(); // Lê resposta do usuário

        } while (resposta == "s"); // Repete o loop enquanto a resposta for "s"

        Console.WriteLine("Programa encerrado."); // Mensagem de encerramento
    }

    static void MostrarCabecalho()
    {
        // Exibe o cabeçalho do projeto
        Console.WriteLine("****************************************************");
        Console.WriteLine("* Projeto: Análise de Algoritmos de Ordenação       *");
        Console.WriteLine("* Aplicado ao Geoprocessamento de Imagens da Amazônia *");
        Console.WriteLine("* Objetivo: Avaliar a eficiência dos algoritmos de  *");
        Console.WriteLine("* ordenação para o monitoramento de crimes ambientais.*");
        Console.WriteLine("****************************************************");
        Console.WriteLine();
    }

    static AlgoritmoEscolhido EscolherAlgoritmo()
    {
        // Exibe opções de algoritmos de ordenação para o usuário
        Console.WriteLine("Escolha o algoritmo de ordenação:");
        Console.WriteLine("1 - Bubble Sort");
        Console.WriteLine("2 - Selection Sort");
        Console.WriteLine("3 - Insertion Sort");
        Console.WriteLine("4 - Merge Sort");
        Console.WriteLine("5 - Quick Sort");
        int opcao = int.Parse(Console.ReadLine()); // Lê a opção do usuário

        AlgoritmoEscolhido algoritmo = (AlgoritmoEscolhido)opcao; // Converte a opção para o enum
        Console.WriteLine($"Algoritmo escolhido: {algoritmo}"); // Exibe o algoritmo escolhido
        return algoritmo; // Retorna o algoritmo escolhido
    }

    static void RealizarBusca(int[] lista)
    {
        // Lê o elemento que o usuário deseja buscar
        Console.WriteLine("Elemento a ser buscado: ");
        int e = int.Parse(Console.ReadLine()); // Lê o elemento
        int index = SortingAlgorithms.BinarySearch(lista, e); // Chama o método de busca binária
        if (index != -1)
            Console.WriteLine($"Elemento encontrado no índice: {index}"); // Exibe índice se encontrado
        else
            Console.WriteLine("Elemento não encontrado"); // Mensagem se não encontrado
    }

    static int[] LerListaDeArquivo()
    {
        // Lê a lista de um arquivo
        Console.WriteLine("Digite o caminho do arquivo: ");
        string caminho = Console.ReadLine(); // Lê o caminho do arquivo
        try
        {
            // Lê todas as linhas do arquivo e converte para um array de inteiros
            string[] linhas = File.ReadAllLines(caminho); 
            int[] lista = Array.ConvertAll(linhas, int.Parse);
            return lista; // Retorna a lista lida
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao ler o arquivo: " + ex.Message); // Mensagem de erro
            return null; // Retorna null em caso de erro
        }
    }

    static int[] InserirDadosManualmente()
    {
        // Permite ao usuário inserir dados manualmente
        Console.WriteLine("Quantos números deseja inserir?");
        int tamanho = int.Parse(Console.ReadLine()); // Lê o número de elementos
        int[] lista = new int[tamanho]; // Inicializa a lista

        for (int i = 0; i < tamanho; i++)
        {
            Console.WriteLine($"Digite o número {i + 1}:"); // Solicita cada número
            lista[i] = int.Parse(Console.ReadLine()); // Lê e armazena o número
        }

        return lista; // Retorna a lista preenchida
    }
}
