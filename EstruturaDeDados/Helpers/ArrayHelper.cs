using System;

namespace SortingApp.Helpers
{
    public static class ArrayHelper
    {
        /// <summary>
        /// Gera um array de números aleatórios.
        /// </summary>
        /// <param name="size">Tamanho do array.</param>
        /// <param name="min">Valor mínimo para os números gerados.</param>
        /// <param name="max">Valor máximo para os números gerados.</param>
        /// <returns>Array de inteiros aleatórios.</returns>
        public static int[] GenerateRandomArray(int size, int min, int max)
        {
            Random rand = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(min, max);
            }
            return array;
        }
    }
}
