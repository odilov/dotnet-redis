using System.ComponentModel.DataAnnotations;

namespace DotnetRedis.Models
{
    public class Item
    {
        [Required]
        public string Id { get; set; } = $"item:{Guid.NewGuid().ToString()}";

        [Required]
        public string name { get; set; } = String.Empty;
    }
}
