﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Persistance.Repositories;

namespace CarGo.Domain.Entities
{
    public class Model : Entity<Guid>
    {
        public Guid BrandId { get; set; }

        public Guid FuelId { get; set; }

        public Guid TransmissionId { get; set; }

        public string Name { get; set; }

        public decimal DailyPrice { get; set; }

        public string ImageUrl { get; set; }

        public virtual Brand? Brand { get; set; }

        public virtual Fuel? Fuel { get; set;}

        public virtual Transmission? Transmision { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public Model()
        {
            Cars = new HashSet<Car>();
        }

        public Model(Guid id, Guid fuelId, Guid brandId, Guid transmissionId, string name, decimal dailyPrice, string imageUrl):this()
        {
            Id = id;
            BrandId = brandId;
            TransmissionId = transmissionId;
            Name = name;
            DailyPrice = dailyPrice;
            ImageUrl = imageUrl;
            FuelId = fuelId;
        }
    }
}
