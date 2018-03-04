using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Topical_Humlinski.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Name cannot exceed 250 characters")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[A-Za-z]* ([0-3]|)[0-9]\, [0-9][0-9][0-9][0-9]", ErrorMessage = "Date must match format of 'Month Day, Year'")]
        public string Release { get; set; }

        [Required]
        [RegularExpression(@"\$[0-9][0-9]\.[0-9][0-9]", ErrorMessage = "Dollar value must match $00.00")]
        public string Price { get; set; }

        [Required]
        [RegularExpression(@"(P|p)(S|s)[3-4]|(S|s)(W|w)(I|i)(T|t)(C|c)(H|h)|(X|x)(B|b)(O|o)(N|n)(E|e)|(W|w)(I|i)(I|i)(U|u|)|(X|x)(B|b)(O|o)(X|x)360", 
                            ErrorMessage = "Platform does not match a supported system")]
        public string Platform { get; set; }

        [Required]
        [MaxLength(250, ErrorMessage = "Publisher name cannot exceed 250 characters")]
        public string Publisher { get; set; }

        public string Image { get; set; }


    }
}