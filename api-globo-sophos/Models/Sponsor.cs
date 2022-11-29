using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_globo_sophos.Models;

[Table("SPONSORS")]
public partial class Sponsor
{
    [Key]
    [Column("sponsorID")]
    public int SponsorId { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("money_amount")]
    public int? MoneyAmount { get; set; }

    [Column("money_origin")]
    [StringLength(50)]
    [Unicode(false)]
    public string? MoneyOrigin { get; set; }

    [Column("heroID")]
    public int HeroId { get; set; }

    [ForeignKey("HeroId")]
    [InverseProperty("Sponsors")]
    public virtual Hero Hero { get; set; } = null!;
}
