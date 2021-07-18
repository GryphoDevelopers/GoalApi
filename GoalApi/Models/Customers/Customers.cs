using Interface;
using System.ComponentModel.DataAnnotations;

namespace GoalApi.Models.Customers
{
    public class Customers
    {
        [Required]
        [Display(Name = "User id")]
        [CompileFinder("USER_ID")]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "User name")]
        [MaxLength(60, ErrorMessage = "Nome deve ter no máximo 60 caracteres")]
        [MinLength(4, ErrorMessage = "Nome deve ter no mínimo 4 caracteres")]
        [CompileFinder("USER_NAME")]
        public string Name { get; set; } 
        
        [Required]
        [Display(Name = "User surname")]
        [MaxLength(200, ErrorMessage = "Sobrenome deve ter no máximo 200 caracteres" )]
        [MinLength(4, ErrorMessage = "Sobrenome deve ter no mínimo 4 caracteres" )]
        [CompileFinder("USER_SURNAME")]
        public string Surname { get; set; }


        [Required]
        [Display(Name = "User email")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [CompileFinder("USER_EMAIL")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "User password")]
        [DataType(DataType.Password)]
        [CompileFinder("USER_PASSWORD")]
        [MaxLength(16, ErrorMessage = "Senha deve ter no máximo 16 caracteres")]
        [MinLength(8, ErrorMessage = "Senha deve ter no mínimo 8 caracteres")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "User phone")]
        [StringLength(18, MinimumLength = 12, ErrorMessage = "Número de telefone deve estar no modelo +(XXX) DDD XXXXX-XXXX")]
        [CompileFinder("USER_PHONE")]
        public string Phone { get; set; }

        [Display(Name = "User address id")]
        [CompileFinder("ADR_ID")]
        public int AddressId { get; set; }
    }
}
