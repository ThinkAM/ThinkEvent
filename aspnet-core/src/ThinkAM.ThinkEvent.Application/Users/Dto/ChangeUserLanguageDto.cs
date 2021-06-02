using System.ComponentModel.DataAnnotations;

namespace ThinkAM.ThinkEvent.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}