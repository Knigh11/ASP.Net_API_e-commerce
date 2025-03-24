using System.ComponentModel.DataAnnotations;

namespace API_demo.DomainModels
{
    public class Province
    {
        [Key] // Đánh dấu khóa chính
        public string ProvinceName { get; set; } = string.Empty;
    }
}
