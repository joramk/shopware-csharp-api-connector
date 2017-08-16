using Lenz.ShopwareApi.Models.Orders;
using RestSharp;
using System;

namespace Lenz.ShopwareApi.Ressources
{
    public class OrderResource : SuperRessource<Order>, IOrderResource
    {
        public OrderResource(IRestClient client)
            : base (client)
        {
            ressourceUrl = "orders";
        }

        public new void add(Order o)
        {
            if (o.customerId != null && o.paymentId != null && o.dispatchId != null && o.paymentStatusId != null
                && o.shopId != null && o.invoiceAmount != null && o.invoiceAmountNet != null && o.invoiceShipping != null
                && o.invoiceShippingNet != null && o.net != null && o.taxFree != null && o.currencyFactor != null
                && o.remoteAddress != null && o.details != null && o.billing != null && o.shipping != null)
            {
                base.add(o);
            }
            throw new Exception("Some required data is missing to add the new order via Shopware REST API.");
        }

        public void delete()
        {
            throw new NotImplementedException("It is not allowed to delete orders via Shopware REST API.");
        }

        public new void update(Order o)
        {
            if (o.id != null)
            {   // make new 'order' containing only REST API updateable fields
                Order o_update = new Order() {
                    paymentStatusId = o.paymentStatusId,
                    orderStatusId = o.orderStatusId,
                    trackingCode = o.trackingCode,
                    comment = o.comment,
                    transactionId = o.transactionId,
                    clearedDate = o.clearedDate
                };
                base.executeUpdate(o_update, o.id.ToString());
                return;
            }
            throw new Exception("Minimum required fields for order update: order.id");
        }

    }
}
