﻿using CRUD.Core.Entities.Base;
using System;

namespace CRUD.Core.Entities
{
    public class Customer : Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public char Gender { get; set; }

        public string Cep { get; set; }

        public string Address { get; set; }

        public string AddressNumber { get; set; }

        public string Complement { get; set; }

        public string Neighborhood { get; set; }

        public string State { get; set; }

        public string City { get; set; }
    }
}
