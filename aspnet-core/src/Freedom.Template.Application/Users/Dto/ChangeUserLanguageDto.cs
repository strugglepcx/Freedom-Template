using System.ComponentModel.DataAnnotations;

namespace Freedom.Template.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}