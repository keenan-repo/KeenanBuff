using System;
using System.ComponentModel.DataAnnotations;

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
