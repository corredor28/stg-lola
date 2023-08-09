using h_data.DataAccess;
using h_data.Entities;

namespace h_data.DataAccessInterfaces
{
    public interface IAnimalDA
    {
        public Task Create(Animal animal);
        public Task Update(Animal animal, int animalId);
        public Task Delete(int animalId);
        public Task<IEnumerable<Animal>> Filter(int? animalId = null, string? name = null, string? sex = null, string? status = null);
    }
}
