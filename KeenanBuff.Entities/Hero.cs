using System;
using System.ComponentModel.DataAnnotations;

namespace KeenanBuff.Entities
{
    public class Hero
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string localized_name { get; set; }
    }
}