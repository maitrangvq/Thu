using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Student
    {
        //Định nghĩa tên
        [Display (Name="Mã sinh viên")]
        [Required(ErrorMessage="Chưa nhâp")]
        public string MaSV { get; set; }
        [Display (Name="Họ tên sinh viên")]
        [Required(ErrorMessage = "Chưa nhập")]
        public string HoTen { get; set; }
        [Display(Name = "Điểm")]
        [Range(0, 10, ErrorMessage = "Điểm từ 0 ..10")]
        public double Diem { get; set; }
        
        public string XepLoai
        {
            get
            {
                if (Diem < 4.0) return "Kém";
                if (Diem < 7.8) return "Trung bình";
                if (Diem < 8.5) return "Khá";
                return "Xuất sắc";

            }
        }
    }
}
