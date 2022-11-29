using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace api_globo_sophos.Models;

[Table("SCHEDULE")]
public partial class Schedule
{
    [Key]
    [Column("schedule_ID")]
    public int ScheduleId { get; set; }

    [Column("activity")]
    [StringLength(70)]
    [Unicode(false)]
    public string? Activity { get; set; }

    [Column("date", TypeName = "date")]
    public DateTime? Date { get; set; }

    [Column("heroID")]
    public int HeroId { get; set; }

    [ForeignKey("HeroId")]
    [InverseProperty("Schedules")]
    public virtual Hero Hero { get; set; } = null!;
}
