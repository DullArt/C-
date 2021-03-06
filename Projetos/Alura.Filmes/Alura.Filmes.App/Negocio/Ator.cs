﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alura.Filmes.App.Negocio
{
    [Table("actor")]
    public class Ator
    {
        //Data Annotations
        [Column("actor_id")]
        public int Id { get; set; }
        [Required]
        [Column("first_name", TypeName="varchar(45)")]
        public string PrimeiroNome { get; set; }
        [Required]
        [column("last_name", TypeName="varchar(45)")]
        public string UltimoNome { get; set; }
        public IList<FilmeAtor> Filmografia { get; set; }

        public Ator()
        {
            Filmografia = new List<FilmeAtor>();
        }

        public override string ToString()
        {
            return $"Ator ({Id}): {PrimeiroNome} {UltimoNome}";
        }
    }
}
