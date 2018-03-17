using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KeenanBuff.Entities
{
    public class PlayerItem
    {
        public PlayerItem()
        {
            PlayerItemId = Guid.NewGuid();
        }

        [Key]
        public Guid PlayerItemId { get; set; }
        public Guid MatchDetailId { get; set; }
        public int ItemId { get; set; }

        public virtual MatchDetail MatchDetail { get; set; }
        public virtual Item Item { get; set; }

        
    }
}
