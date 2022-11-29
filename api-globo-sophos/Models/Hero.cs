using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_globo_sophos.Models;

[Table("HEROES")]
public partial class Hero
{
    [Key]
    [Column("heroID")]
    public int HeroId { get; set; }

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

    [Column("weakness")]
    [StringLength(50)]
    [Unicode(false)]
    public string? Weakness { get; set; }

    [Column("hero_relation")]
    [StringLength(5)]
    [Unicode(false)]
    public string? HeroRelation { get; set; }

    [InverseProperty("Hero")]
    public virtual ICollection<Fight> Fights { get; } = new List<Fight>();

    [InverseProperty("Hero")]
    public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>();

    [InverseProperty("Hero")]
    public virtual ICollection<Sponsor> Sponsors { get; } = new List<Sponsor>();
}
