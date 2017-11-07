using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration; 

namespace cardslanding.Models
{
    public class GamesViewModel
    {
        public List<Game> Games {get; set;}
        public string GameURL {get; set;}
    }
}
