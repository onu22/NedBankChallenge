using System.ComponentModel.DataAnnotations;

namespace NedbankTest.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}