using EndedTask.Models;
using EndedTask.Repositories;
using System;
using System.Linq;

namespace EndedTask.Mocks
{
    static public class BuyingProduct
    {

        static  public void AddToCan(UnitOfWork context,Client client,Product product )
        {
            var h =  context.Orders.Get(client);
            if ( h == null) {


                Order order = new Order
                {
                    ClientId = client.Id,
                    OrderDate = DateTime.Today.Date,
                    OrderNumber = 0,
                    ShipmentDate = DateTime.Today.AddDays(14).Date,
                    Status = "New"
                };
                 context.Orders.Create(order);
                OrderItem orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = product.Id,
                    ItemsCount = 1,
                    ItemPrice = product.Price

                };
                context.OrderItems.Create(orderItem);
                context.Save();
            }
            else if(h!=null && h.OrderNumber==0)
            {

                var g = context.OrderItems.Get(product.Id, h.Id);
                
                if (g == null) {
                    OrderItem orderItem = new OrderItem
                    {
                        OrderId = h.Id,
                        ProductId = product.Id,
                        ItemsCount = 1,
                        ItemPrice = product.Price

                    };
                    context.OrderItems.Create(orderItem);
                    context.Save();
                    
                } else {
                    g.ItemsCount++;
                    context.OrderItems.Update(g);
                    context.Save();
                }
            }
            else { }
            }
        }
    }

