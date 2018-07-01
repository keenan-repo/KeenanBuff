using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeenanBuff.Entities
{
    public class Hero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HeroId { get; set; }
        public string HeroName { get; set; }
        public string HeroUrl { get; set; }
    }
}