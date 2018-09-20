using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvinceApi.Models
{
    public class Province
    {
        public Province(int id, string Name)
        {
            this.Id = id;
            this.Name = Name;
        }
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên tỉnh thành")]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
