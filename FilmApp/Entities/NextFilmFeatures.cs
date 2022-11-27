using System.ComponentModel.DataAnnotations;

namespace FilmApp.Entities
{
    public class NextFilmFeatures
    {
       
            [Key]
            public int NextFilmId { get; set; }
            public string NextFilmName { get; set; }
            public bool watched { get; set; } = false;

        
    }
}
