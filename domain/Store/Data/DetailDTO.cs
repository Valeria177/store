﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Data
{
    public class DetailDTO
    {
        public int Id { get; set; }

        public string Part_number { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

    }
}
