using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_UTS.Model
{
    [Table("tb_peminjaman")]
    public class Peminjaman
    {
        [Column("pinjam_id")]
        [Key]
        public int Id { get; set; }
        [Column("pinjam_buku")]
        [ForeignKey("Buku")]
        public int bukuId { get; set; }
        [Column("pinjam_user")]
        [ForeignKey("User")]
        public int userId { get; set; }
    }
}
