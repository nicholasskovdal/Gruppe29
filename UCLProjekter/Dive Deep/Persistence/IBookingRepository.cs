using Dive_Deep.Models;
namespace Dive_Deep.Persistence
{
    public interface IBookingRepository
    {
        
        Task AddAsync(Booking booking);

        //Read
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<Booking?> GetByIdAsync(int bookingId);
        //Task<IEnumerable<T>> GetAllOfTypeAsync<T>() where T : Booking; //Asynchronous GetAll of specified class that inherits from Product

        //Update
        Task UpdateAsync(Booking booking);

        //Delete
        Task DeleteAsync(int bookingId);

    }
}
