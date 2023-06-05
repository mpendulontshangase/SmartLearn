using System.ComponentModel.DataAnnotations;

namespace SmartLearn.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}