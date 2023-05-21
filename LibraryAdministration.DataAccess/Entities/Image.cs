using System.ComponentModel.DataAnnotations;

namespace LibraryAdministration.DataAccess.Entities
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Relative path
        /// </summary>
        [Required]
        public string Path { get; set; }
        public string OriginalName { get; set; }
    }
}
