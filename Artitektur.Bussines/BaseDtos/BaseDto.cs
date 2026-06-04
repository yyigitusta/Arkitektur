using System.Text.Json.Serialization;

namespace Artitektur.Business.BaseDtos
{
    public abstract class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }
    }
}
