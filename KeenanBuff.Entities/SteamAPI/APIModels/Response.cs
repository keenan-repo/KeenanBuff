using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KeenanBuff.Entites.SteamAPI.APIModels
{

    public class Response
    {
        public List<SteamPlayer> players { get; set; }
    }
}