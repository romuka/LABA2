using System.Collections.Generic;
namespace LR2
{
    /// <summary>
    /// Каталог телефонных номеров.
    /// </summary>
    public class Catalog
    {
        /// <summary>
        /// Список телефонных номеров.
        /// </summary>
        public List<Phone> Phones { get; set; } = new List<Phone>();
    }
}
