﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSocialNetwork.DomainModel.Entities
{
    public class Group : EntityBase
    {
        public string Name { get; set; }
        [NotMapped]
        public bool Actived { get; set; }
    }
}
