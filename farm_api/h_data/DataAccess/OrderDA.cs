using Dapper;
using h_data.DataAccessInterfaces;
using h_data.Entities;
using System.Data;

namespace h_data.DataAccess
{
    public class OrderDA : IOrderDA
    {
        private readonly STGContext _context;
        public OrderDA(STGContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Order order)
        {
            string sqlQuery = "INSERT [Order] (TotalQuantity, ListPrice, Freight, Discount, NetPrice) " +
                                "OUTPUT INSERTED.OrderId " +
                                "VALUES (@TotalQuantity, @ListPrice, @Freight, @Discount, @NetPrice)";
            var parameters = new DynamicParameters();
            parameters.Add("TotalQuantity", order.TotalQuantity, DbType.Int32);
            parameters.Add("ListPrice", order.ListPrice, DbType.Decimal);
            parameters.Add("Freight", order.Freight, DbType.Decimal);
            parameters.Add("Discount", order.Discount, DbType.Decimal);
            parameters.Add("NetPrice", order.NetPrice, DbType.Decimal);

            using var connection = _context.CreateConnection();
            var newId = await connection.QuerySingleAsync<int>(sqlQuery, parameters);
            return newId;
        }
    }
}
