using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Brown.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a year.")]
        [Range(1888, 2100, ErrorMessage = "Please enter a valid year (1888 or later).")]
        public int Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Please specify if the movie was edited.")]
        public bool Edited { get; set; }

        [Required(ErrorMessage = "Please specify if the movie was copied to Plex.")]
        public bool CopiedToPlex { get; set; }

        [StringLength(25, ErrorMessage = "Lent To must be 25 characters or fewer.")]
        public string? LentTo { get; set; }

        [StringLength(25, ErrorMessage = "Notes must be 25 characters or fewer.")]
        public string? Notes { get; set; }
    }
}
