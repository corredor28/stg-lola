using h_data;
using h_data.DataAccessInterfaces;
using h_data.DTOs;
using h_data.Entities;

namespace m_business
{
    public class OrderBO
    {
        private readonly IOrderDA _orderDA;
        private readonly IAnimalDA _animalDA;

        public OrderBO(IOrderDA orderDA, IAnimalDA animalDA)
        {
            _orderDA = orderDA;
            _animalDA = animalDA;
        }

        public async Task<Order> Create(IEnumerable<OrderAnimal> orderAnimals)
        {
            var idsInOrder = new List<int>();
            int totalQuantity = 0;
            decimal listPrice = 0;
            decimal discount = 0;
            foreach (var orderAnimal in orderAnimals)
            {
                // It is not allowed to duplicate the animal in the Order. If you identify the duplicate animal,
                // the API should return an error message displaying the reason.
                if (idsInOrder.Contains(orderAnimal.AnimalId))
                {
                    throw new Exception($"The animal with id {orderAnimal.AnimalId} is duplicated in the Order.");
                }
                idsInOrder.Add(orderAnimal.AnimalId);

                // Get animal by id
                var animals = await _animalDA.Filter(animalId: orderAnimal.AnimalId);
                if (animals.FirstOrDefault() == null)
                {
                    throw new Exception($"The animal with id {orderAnimal.AnimalId} does not exist.");
                }
                
                totalQuantity += orderAnimal.Quantity;

                var item = new OrderItem();
                var animal = animals.FirstOrDefault()!;

                item.UnitPrice = animal.Price;
                item.Quantity = orderAnimal.Quantity;

                // If the customer adds an animal with a quantity greater than 50 in the cart,
                // we must apply a 5% discount on the value of this animal. 
                if (item.Quantity > 50)
                {
                    item.Discount = item.UnitPrice * 0.05m * item.Quantity;
                }
                else
                {
                    item.Discount = 0;
                }

                item.Price = item.UnitPrice * item.Quantity - item.Discount;
                listPrice += item.Price;
            }

            // If the customer buys more than 200 animals in the order, an additional 3% discount
            // will be added to the total purchase price.
            if (totalQuantity > 200)
            {
                discount = listPrice * 0.03m;
            }

            // If the customer buys more than 300 animals in the order, the freight value must be free,
            // otherwise it will charge $1,000.00 for freight.
            decimal freight;
            if (totalQuantity > 300)
            {
                freight = 0;
            }
            else
            {
                freight = 1000m;
            }

            // Build order
            var order = new Order {
                TotalQuantity = totalQuantity,
                ListPrice = listPrice,
                Discount = discount,
                Freight = freight,
                NetPrice = listPrice - discount + freight
            };

            order.OrderId = await _orderDA.Create(order);

            return order;
        }
    }
}