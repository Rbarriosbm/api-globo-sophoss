using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_globo_sophos.Models;

[Table("FIGHTS")]
public partial class Fight
{
    [Key]
    [Column("fightID")]
    public int FightId { get; set; }

    [Column("status_fight")]
    public bool? StatusFight { get; set; }

    [Column("heroID")]
    public int HeroId { get; set; }

    [Column("villainID")]
    public int VillainId { get; set; }

    [ForeignKey("HeroId")]
    [InverseProperty("Fights")]
    public virtual Hero Hero { get; set; } = null!;

    [ForeignKey("VillainId")]
    [InverseProperty("Fights")]
    public virtual Villain Villain { get; set; } = null!;
}
