﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Lavanderia_Beatriz_App.Models;

public partial class TiposPuesto
{
    public int Id { get; set; }

    public string Descripcion { get; set; }

    public virtual ICollection<EncargadosRecep> EncargadosReceps { get; set; } = new List<EncargadosRecep>();
}