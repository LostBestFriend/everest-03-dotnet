using System.ComponentModel.DataAnnotations;

namespace _01_Back_End_Criação_de_Usuário
{
    public abstract class BaseModel
    {
        [Key]
        public long Id { get; set; }
    }
}
