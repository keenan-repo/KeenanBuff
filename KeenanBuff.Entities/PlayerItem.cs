using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeenanBuff.Entities
{
    public class PlayerItem
    {
        public PlayerItem()
        {
            Id = Guid.NewGuid();
        }     
        
        public virtual MatchDetail MatchDetail { get; set; }
        public Guid Id { get; set; }
        public Int64 ItemId { get; set; }
        public string localized_name { get; set; }
        public string url { get; set; }
        
    }
}
