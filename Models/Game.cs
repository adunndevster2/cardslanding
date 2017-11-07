using System;
using System.ComponentModel.DataAnnotations;

namespace cardslanding.Models
{
    public class Game
    {
        public int ID { get; set; }
        
        public string Title { get; set; }
        
        public string Description {get; set;}
        public string LongDescription {get; set;}
        public string ImageURL {get; set;}
        public bool IsPublic { get; set; }

        [StringLength(150) ]
        public string Slug {get; set;}
        
    }
}