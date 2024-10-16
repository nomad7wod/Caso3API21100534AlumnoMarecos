using PARCIAL.DOMAIN.Core.Entities;

namespace PARCIAL.DOMAIN.Core.Interfaces
{
    public interface IAttendeesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Attendees>> GetAttendees();
        Task<Attendees> GetAttendeesbyId(int id);
        Task Insert(Attendees attendees);
        Task<bool> Update(Attendees attendees);
    }
}