using BookWave.Entity.Entities;
using BookWave.Repository.Abstract;
using BookWave.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWave.Repository.Concrete;
public class PublisherRepository(AppDbContext context) : GenericRepository<Publisher>(context), IPubLisherRepository
{
}
