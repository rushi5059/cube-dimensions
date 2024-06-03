using System.ComponentModel.DataAnnotations;


namespace cube_dimensions.Models
{
    public class Cube
    {
        [Key]
        public int Id { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
    }
}
