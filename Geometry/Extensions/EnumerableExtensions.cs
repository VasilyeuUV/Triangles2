namespace Geometry.Extensions
{
    /// <summary>
    /// Расширения для массивов
    /// </summary>
    internal static class EnumerableExtensions
    {

        /// <summary>
        /// Разбить список (массив) на куски определенного размера
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">Список (массив), который подлежит разбиению</param>
        /// <param name="chunkSize">Количество элементов, на которое будет разбит список (массив)</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> items, int chunkSize)
        {
            for (int i = 0; i < items.Count() / chunkSize + 1; i++)
                yield return items
                    .Skip(i * chunkSize)
                    .Take(chunkSize);
        }


        /// <summary>
        /// Преобразование в двумерный массив
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="chunkSize"></param>
        /// <returns></returns>
        public static T[,] ToArray2D<T>(this IEnumerable<T> items, int width)
        {
            var arr = items.Split(width).ToArray();
            var height = arr.Length;
            T[,] arr2d = new T[height, width];

            int h = 0, w = 0;
            foreach (var item in items)
            {
                arr2d[h, w] = item;
                if (++w >= width)
                {
                    w = 0;
                    ++h;
                }
            }
            return arr2d;
        }

    }
}
