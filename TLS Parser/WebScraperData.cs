using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TLS_Parser
{
    [DataContract]
    public sealed class WebScraperData
    {
        #region PROPERTIES
        [DataMember(Name = "top_phones")]
        public List<Item> TopPhones
        {
            get;
            set;
        }
        [DataMember(Name = "top_computers")]
        public List<Item> TopComputers
        {
            get;
            set;
        }
        [DataMember(Name = "laptops")]
        public List<Item> Laptops
        {
            get;
            set;
        }
        [DataMember(Name = "tablets")]
        public List<Item> Tablets
        {
            get;
            set;
        }
        [DataMember(Name = "touch_phones")]
        public List<Item> TouchPhones
        {
            get;
            set;
        }
        #endregion

        #region CONSTRUCTOR
        public WebScraperData(List<Item> topPhones, List<Item> topComputers, 
            List<Item> laptops, List<Item> tablets, List<Item> touchPhones)
        {
            TopPhones = topPhones;
            TopComputers = topComputers;
            Laptops = laptops;
            Tablets = tablets;
            TouchPhones = touchPhones;
        }
        public WebScraperData()
        {
        }
        #endregion
    }
}
