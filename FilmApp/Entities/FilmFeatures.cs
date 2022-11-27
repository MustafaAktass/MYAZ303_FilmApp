using System.ComponentModel.DataAnnotations;

namespace FilmApp.Entities
{
    public class FilmFeatures
    {
        [Key]
        public int FilmId { get; set; }
        public string FilmName { get; set; }
        public bool watched { get; set; } = false;
        public string FilmComment { get; set; }
    }
}
