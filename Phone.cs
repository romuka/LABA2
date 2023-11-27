namespace LR2
{
    /// <summary>
    /// Телефонный контакт.
    /// </summary>
    public class Phone
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// Телефонный номер.
        /// </summary>
        public string brend { get; set; }
        /// <summary>
        /// Заметка.
        /// </summary>
        public string specs { get; set; }
        /// <summary>
        /// Важный контакт.
        /// </summary>
        public double price { get; set; }
        /// <summary>
        /// Приведение объекта к строке.
        /// </summary>
        /// <returns> Имя. </returns>
        public override string ToString()
        {
            return Model;
        }
    }
}