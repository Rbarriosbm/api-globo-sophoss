using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_globo_sophos.Models;

[Table("VILLAINS")]
public partial class Villain
{
    [Key]
    [Column("villainID")]
    public int VillainId { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("age")]
    public int? Age { get; set; }

    [Column("hability")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Hability { get; set; }

    [Column("weaknes")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Weaknes { get; set; }

    [InverseProperty("Villain")]
    public virtual ICollection<Fight> Fights { get; } = new List<Fight>();
}
