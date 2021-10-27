using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_UTS.Model
{
    [Table("tb_buku")]
    public class Buku
    {
        [Column("buku_id")]
        [Key]
        public int Id { get; set; }
        [Column("buku_nama")]
        public string NamaBuku { get; set; }
        [Column("buku_author")]
        public string AuthorBuku { get; set; }
    }
}
