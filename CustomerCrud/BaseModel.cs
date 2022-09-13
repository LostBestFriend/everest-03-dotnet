using System.ComponentModel.DataAnnotations;

namespace CustomerCrudApi
{
    public abstract class BaseModel
    {
        [Key]
        public long Id { get; set; }
    }
}
