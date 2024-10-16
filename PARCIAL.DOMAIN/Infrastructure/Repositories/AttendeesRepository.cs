using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using PARCIAL.DOMAIN.Core.Entities;
using PARCIAL.DOMAIN.Core.Interfaces;
using PARCIAL.DOMAIN.Data;

namespace PARCIAL.DOMAIN.Infrastructure.Repositories
{
    public class AttendeesRepository : IAttendeesRepository
    {
        private readonly EventManagementDbContext _context; // con esto ya no se necesita el var data = new EventManagement();

        public AttendeesRepository(EventManagementDbContext context)
        {
            _context = context;
        }
        //public IEnumerable<Attendees> GetAttendees()
        //{
        //    var data = new EventManagementDbContext();

        //    return data.Attendees.ToList();
        //}



        public async Task<IEnumerable<Attendees>> GetAttendees()
        {
            //var data = new EventManagementDbContext(); 

            return await _context.Attendees.ToListAsync(); //comente data y ahora lo cambio por context
        }


        public async Task<Attendees> GetAttendeesbyId(int id)
        {
            var data = new EventManagementDbContext();

            return await _context.Attendees.FirstOrDefaultAsync(a => a.Id == id);
        }


        public async Task Insert(Attendees attendees)
        {
            //var data = new EventManagementDbContext();
            await _context.Attendees.AddAsync(attendees);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> Update(Attendees attendees)
        {
            _context.Attendees.Update(attendees);
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var attendees = await _context.Attendees.FindAsync(id);
            _context.Attendees.Remove(attendees);
            if (attendees == null)
            {
                return false;
            }
            int countRows = await _context.SaveChangesAsync();
            return countRows > 0;
        }






    }
}
