﻿using Lupi.Data.Entities;
using Lupi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lupi.BusinessLogic
{
    public class BreedsBusinessLogic : IBreedsBusinessLogic
    {
        //Posible mejora de esta clase:
        //Manejar un unico contexto para unificar las transacciones realizadas sobre Breeds a partir de una Unit Of Work

        public IBreedsRepository breedsRepository;

        public BreedsBusinessLogic(IBreedsRepository breedsRepository)
        {
            this.breedsRepository = breedsRepository;
        }

        public IEnumerable<Breed> GetAllBreeds()
        {
            return breedsRepository.GetAll();
        }

        public Breed GetByID(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return breedsRepository.GetByID(id);
        }

        public Guid Add(Breed breed)
        {
            if (breed == null)
            {
                throw new ArgumentNullException(nameof(breed));
            }
            Guid id = Guid.NewGuid();
            breed.Id = id;
            breedsRepository.Add(breed);
            return id;
        }

        public bool Delete(Guid id)
        {
            return breedsRepository.DeleteById(id);
        }

        public bool Update(Guid id, Breed newBreed)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            return breedsRepository.Update(id, newBreed);
        }
   
    }
}
