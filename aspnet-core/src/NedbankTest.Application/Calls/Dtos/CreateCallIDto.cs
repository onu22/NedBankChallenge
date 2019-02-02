using System;
using System.ComponentModel.DataAnnotations;


namespace NedbankTest.Calls.Dtos
{
    public class CreateCallDto
    {

        [Required]
        [StringLength(Call.MaxCodeLength)]
        public string Code { get; set; }

        [StringLength(Call.MaxDescriptionLength)]
        public string Description { get; set; }

    }
}
