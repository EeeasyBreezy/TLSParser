using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLS_Parser
{
    /// <summary>
    /// Представление товара
    /// </summary>
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
        public Item(string name, int price, string description, int reviewsNumber)
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
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Цена
        /// </summary>
        public int Price
        {
            get;
            set;
        }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description
        {
            get;
            set;
        }
        /// <summary>
        /// Количество обзоров
        /// </summary>
        public int ReviewsNumber
        {
            get;
            set;
        }
        #endregion
    }
}
