namespace SortingApp.SortingAlgorithms
{
    public static class SortingAlgorithms
    {
        // Método principal para ordenar o array com base no algoritmo escolhido
        public static void Ordenar(AlgoritmoEscolhido algoritmo, int[] array)
        {
            switch (algoritmo)
            {
                case AlgoritmoEscolhido.BubbleSort:
                    BubbleSort(array);
                    break;
                case AlgoritmoEscolhido.SelectionSort:
                    SelectionSort(array);
                    break;
                case AlgoritmoEscolhido.InsertionSort:
                    InsertionSort(array);
                    break;
                case AlgoritmoEscolhido.MergeSort:
                    MergeSort(array, 0, array.Length - 1);
                    break;
                case AlgoritmoEscolhido.QuickSort:
                    QuickSort(array);
                    break;
                default:
                    Console.WriteLine("Opção inválida."); // Caso de opção inválida
                    break;
            }
        }

        // Implementação do algoritmo Bubble Sort
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1]) // Troca se o elemento atual for maior que o próximo
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
        }

        // Implementação do algoritmo Selection Sort
        public static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i; // Inicializa o índice do menor elemento
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex]) // Encontra o menor elemento
                    {
                        minIndex = j;
                    }
                }
                Swap(array, i, minIndex); // Troca o elemento atual com o menor encontrado
            }
        }

        // Implementação do algoritmo Insertion Sort
        public static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i]; // Elemento a ser inserido
                int j = i - 1;
                // Move elementos que são maiores que key para uma posição à frente
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key; // Insere key na posição correta
            }
        }

        // Implementação do algoritmo Merge Sort
        public static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2; // Divide o array ao meio
                MergeSort(array, left, mid); // Ordena a primeira metade
                MergeSort(array, mid + 1, right); // Ordena a segunda metade
                Merge(array, left, mid, right); // Combina as duas metades
            }
        }

        // Método auxiliar para combinar duas metades ordenadas
        private static void Merge(int[] array, int left, int mid, int right)
        {
            int[] leftArray = new int[mid - left + 1]; // Cria array para a metade esquerda
            int[] rightArray = new int[right - mid]; // Cria array para a metade direita

            Array.Copy(array, left, leftArray, 0, mid - left + 1); // Copia elementos para o array da esquerda
            Array.Copy(array, mid + 1, rightArray, 0, right - mid); // Copia elementos para o array da direita

            int i = 0, j = 0, k = left;
            while (i < leftArray.Length && j < rightArray.Length)
            {
                // Adiciona o menor elemento de volta ao array original
                if (leftArray[i] <= rightArray[j])
                {
                    array[k] = leftArray[i];
                    i++;
                }
                else
                {
                    array[k] = rightArray[j];
                    j++;
                }
                k++;
            }

            // Copia os elementos restantes da metade esquerda, se houver
            while (i < leftArray.Length)
            {
                array[k] = leftArray[i];
                i++;
                k++;
            }

            // Copia os elementos restantes da metade direita, se houver
            while (j < rightArray.Length)
            {
                array[k] = rightArray[j];
                j++;
                k++;
            }
        }

        // Implementação do algoritmo Quick Sort
        public static void QuickSort(int[] array, int left = 0, int? right = null)
        {
            if (right == null) right = array.Length - 1; // Define o valor padrão para right
            if (left < right)
            {
                int pivotIndex = Partition(array, left, right.Value); // Encontra o índice do pivô
                QuickSort(array, left, pivotIndex - 1); // Ordena a parte esquerda
                QuickSort(array, pivotIndex + 1, right.Value); // Ordena a parte direita
            }
        }

        // Método para particionar o array
        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right]; // Escolhe o último elemento como pivô
            int i = left;
            for (int j = left; j < right; j++)
            {
                if (array[j] <= pivot) // Move os elementos menores ou iguais ao pivô
                {
                    Swap(array, i, j);
                    i++;
                }
            }
            Swap(array, i, right); // Troca o pivô para a posição correta
            return i; // Retorna o índice do pivô
        }

        // Implementação da busca binária
        public static int BinarySearch(int[] array, int item, int begin = 0, int? end = null)
        {
            if (end == null) end = array.Length - 1; // Define o valor padrão para end
            if (begin <= end)
            {
                int mid = (begin + end.Value) / 2; // Encontra o meio do array
                if (array[mid] == item)
                    return mid; // Retorna o índice se o item for encontrado
                if (item < array[mid])
                    return BinarySearch(array, item, begin, mid - 1); // Busca na metade esquerda
                else
                    return BinarySearch(array, item, mid + 1, end); // Busca na metade direita
            }
            return -1; // Retorna -1 se o item não for encontrado
        }

        // Método auxiliar para trocar elementos de posição no array
        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

// Enum para os algoritmos
public enum AlgoritmoEscolhido
{
    BubbleSort = 1,
    SelectionSort = 2,
    InsertionSort = 3,
    MergeSort = 4,
    QuickSort = 5
}
