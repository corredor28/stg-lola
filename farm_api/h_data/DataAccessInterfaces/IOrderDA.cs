using h_data.DataAccess;
using h_data.Entities;

namespace h_data.DataAccessInterfaces
{
    public interface IOrderDA
    {
        public Task<int> Create(Order order);
    }
}
