using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_UTS.Model
{
    [Table("tb_user")]
    public class User
    {
        [Column("user_id")]
        [Key]
        public int Id { get; set; }
        [Column("user_name")]
        public string Username { get; set; }
        [Column("user_pass")]
        public string Password { get; set; }
    }
}
