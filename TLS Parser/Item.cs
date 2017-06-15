using System.Runtime.Serialization;

namespace TLS_Parser
{
    /// <summary>
    /// Представление товара
    /// </summary>
    [DataContract(Name = "item")]
    public sealed class Item
    {
        #region CONSTRUCTORS
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name">Наименование</param>
        /// <param name="price">Цена</param>
        /// <param name="description">описание</param>
        /// <param name="reviewsNumber">Количество обзоров</param>
        public Item(string name, float price, string description, int reviewsNumber)
        {
            Name = name;
            Price = price;
            Description = description;
            ReviewsNumber = reviewsNumber;
        }
        #endregion

        #region PROPERTIES
        /// <summary>
        /// Наименование
        /// </summary>
        [DataMember(Name = "name")]
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Цена
        /// </summary>
        [DataMember(Name = "price")]
        public float Price
        {
            get;
            set;
        }
        /// <summary>
        /// Описание
        /// </summary>
        [DataMember(Name = "description")]
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// Количество обзоров
        /// </summary>
        [DataMember(Name = "reviews")]
        public int ReviewsNumber
        {
            get;
            set;
        }
        #endregion
    }
}
