using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniBank.Entities
{
    [Table("Images")]
    public class Image : BaseEntity
    {
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }
        public long FileSize { get; set; }
    }
}