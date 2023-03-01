using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP1st.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("รูปภาพ")]
        [NotMapped]
        public IFormFile Image { get; set; }

        [Required(ErrorMessage ="กรุณาใส่ชื่อ")]
        [DisplayName("ชื่อ")]
        public string Name { get; set; }
        [DisplayName("รายละเอียด")]
        public string Description { get; set; }
        
        [DisplayName("ราคา")]
        [Range(0,10000,ErrorMessage ="ห้ามป้อนค่าน้อยกว่า 0")]
        public int Price { get; set; }


    }
}
