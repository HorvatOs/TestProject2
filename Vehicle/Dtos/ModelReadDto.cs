using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.WebAPI.Dtos
{
    public class ModelReadDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public int MakeId { get; set; }
    }
}

