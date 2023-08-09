using Dapper;
using h_data.DataAccessInterfaces;
using h_data.Entities;
using System.Data;

namespace h_data.DataAccess
{
    public class AnimalDA : IAnimalDA
    {
        private readonly STGContext _context;
        public AnimalDA(STGContext context)
        {
            _context = context;
        }

        public async Task Create(Animal animal)
        {
            string sqlQuery = "INSERT Animal (Name, Breed, BirthDate, Sex, Price, Status) " +
                                "VALUES (@Name, @Breed, @BirthDate, @Sex, @Price, @Status)";
            var parameters = new DynamicParameters();
            parameters.Add("Name", animal.Name, DbType.String);
            parameters.Add("Breed", animal.Breed, DbType.String);
            parameters.Add("BirthDate", animal.BirthDate, DbType.DateTime);
            parameters.Add("Sex", animal.Sex, DbType.String);
            parameters.Add("Price", animal.Price, DbType.Decimal);
            parameters.Add("Status", animal.Status, DbType.String);

            using var connection = _context.CreateConnection();
            var r = await connection.ExecuteAsync(sqlQuery, parameters);
            Console.Write(r);
        }

        public async Task Update(Animal animal, int animalId)
        {
            string sqlQuery = "UPDATE Animal SET Name = @Name, Breed = @Breed, BirthDate = @BirthDate, " +
                                                "Sex = @Sex, Price = @Price, Status = @Status WHERE AnimalId = @AnimalId";
            var parameters = new DynamicParameters();
            parameters.Add("Name", animal.Name, DbType.String);
            parameters.Add("Breed", animal.Breed, DbType.String);
            parameters.Add("BirthDate", animal.BirthDate, DbType.DateTime);
            parameters.Add("Sex", animal.Sex, DbType.String);
            parameters.Add("Price", animal.Price, DbType.Decimal);
            parameters.Add("Status", animal.Status, DbType.String);
            parameters.Add("AnimalId", animalId, DbType.Int32);

            using var connection = _context.CreateConnection();
            var r = await connection.ExecuteAsync(sqlQuery, parameters);
            Console.Write(r);
        }

        public async Task Delete(int animalId)
        {
            string query = "DELETE FROM Animal WHERE AnimalId = @AnimalId";

            using var connection = _context.CreateConnection();
            await connection.ExecuteAsync(query, new { AnimalId = animalId });
        }

        public async Task<IEnumerable<Animal>> Filter(int? animalId, string? name, string? sex, string? status)
        {
            string sqlQuery = "SELECT * FROM Animal " +
                "WHERE (@AnimalId IS NULL OR AnimalId = @AnimalId)" +
                "   AND (@Name IS NULL OR Name = @Name)" +
                "   AND (@Sex IS NULL OR Sex = @Sex)" +
                "   AND (@Status IS NULL OR Status = @Status)";

            using var connection = _context.CreateConnection();
            IEnumerable<Animal> animals = await connection.QueryAsync<Animal>(sqlQuery, new
            {
                AnimalId = animalId,
                Name = name,
                Sex = sex,
                Status = status
            });
            return animals;
        }
    }
}
