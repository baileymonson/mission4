using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mission4.Models
{
    //page that gets and sets all of the values in the movie form 
    public class ApplicationResponse
    {
        // id to make a primary key in the main database
        // required to make sure they enter in the correct data that is needed
        [Key]
        [Required]
        public int MovieId { get; set;  }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }
        // these link my new category table
        [Required]
        public int CategoryId { get; set; }
        public Category Catagory { get; set; }
       
    }
}
