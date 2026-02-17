using System.ComponentModel.DataAnnotations;

namespace BincomProjectApi.Model.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        [MaxLength(500)]
        public string Url { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } 
    }
}
