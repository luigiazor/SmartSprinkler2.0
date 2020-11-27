using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartSprinkler.Model
{
    public class TiposPlantas
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        [MaxLength(30)]
        public string Nomeplantas { get; set; }
        public int Water { get; set; }

        public string UserId { get; set; }
    }
}
