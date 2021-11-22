using System.ComponentModel.DataAnnotations;

namespace ABPCommerce.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}