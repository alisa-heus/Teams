using ClientOrdersFW;
using ClientOrdersFW.Models;

using (var context = new ClientOrdersDbContext())
{
    int orderDetailsIdIncrementor = 0;
    for (int i = 1; i <= 2; i++)
    {
        var user = new User
        {
            FirstName = $"User{i}",
            LastName = $"LastName{i}",
            Email = $"user{i}@example.com"
        };
        context.Users.Add(user);
        context.SaveChanges();
    }

    var users = context.Users.ToList();
    foreach (var user in users)
    {
        var order = new Order
        {
            UserID = user.UserID,
            OrderDate = DateTime.Now,
            TotalAmount = 100 * user.UserID
        };
        context.Orders.Add(order);
        context.SaveChanges();

    }

    var orders = context.Orders.ToList();
    foreach (var order in orders)
    {
        var product = new Product
        {
            ProductName = $"Product{order.OrderID}",
            Price = 10 * order.OrderID
        };
        context.Products.Add(product);
        context.SaveChanges();
    }

    var products = context.Products.ToList();
    Random rnd = new();
    foreach (var order in orders)
    {
        for (int k = 1; k <= 10; k++)
        {
            var product = products[rnd.Next(products.Count)];
            var quantity = rnd.Next(1, 11);

            var orderDetail = new OrderDetail
            {
                OrderDetailID = orderDetailsIdIncrementor++,
                OrderID = order.OrderID,
                ProductID = product.ProductID,
                Quantity = quantity,
                Price = product.Price * quantity
            };
            context.OrderDetails.Add(orderDetail);
        }
    }

    context.SaveChanges();
    var users1 = context.Users.ToList();
    var orders1 = context.Orders.ToList();
    var products1 = context.Products.ToList();



}