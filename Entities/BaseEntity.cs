using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBank.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime? DateLastModified { get; set; }
        public DateTime DateCreated { get; set; }

        protected BaseEntity()
        {
            DateCreated = DateTime.Now;
        }
    }
}
