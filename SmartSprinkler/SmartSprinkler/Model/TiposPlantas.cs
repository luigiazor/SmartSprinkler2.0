using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSprinkler.Model
{
    public class TiposPlantas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Nomeplantas { get; set; }
    }
}
