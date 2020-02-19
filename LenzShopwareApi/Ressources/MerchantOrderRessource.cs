using Lenz.ShopwareApi.Models.Orders;
using RestSharp;
using System;
using System.Collections.Generic;

namespace Lenz.ShopwareApi.Ressources
{
    public class MerchantOrderRessource : SuperRessource<MerchantOrder>, IMerchantOrderRessource
    {
        public MerchantOrderRessource(IRestClient client)
            : base (client)
        {
            ressourceUrl = "MerchantOrders";
        }

        public new List<MerchantOrder> getAll()
        {
            ApiRequest request = new ApiRequest(this.ressourceUrl, Method.GET);
            ApiRequestExecutor executor = new ApiRequestExecutor();

            ApiResponse<List<MerchantOrder>> response = executor.execute<List<MerchantOrder>>(client, request);

            return response.data;
        }

        public List<MerchantOrder> getByShip(bool ship)
        {
            ApiRequest request = new ApiRequest(this.ressourceUrl, Method.GET);
            request.addParameter("ship", ship ? "1" : "0");
            ApiRequestExecutor executor = new ApiRequestExecutor();

            ApiResponse<List<MerchantOrder>> response = executor.execute<List<MerchantOrder>>(client, request);

            return response.data;
        }

        public List<MerchantOrder> getByDate(DateTime date)
        {
            ApiRequest request = new ApiRequest(this.ressourceUrl, Method.GET);
            request.addParameter("date", date.ToString("yyyy-MM-dd"));
            ApiRequestExecutor executor = new ApiRequestExecutor();

            ApiResponse<List<MerchantOrder>> response = executor.execute<List<MerchantOrder>>(client, request);

            return response.data;
        }

        public List<MerchantOrder> getByDateAndShip(DateTime date, bool ship)
        {
            ApiRequest request = new ApiRequest(this.ressourceUrl, Method.GET);
            request.addParameter("ship", ship ? "1" : "0");
            request.addParameter("date", date.ToString("yyyy-MM-dd"));
            ApiRequestExecutor executor = new ApiRequestExecutor();

            ApiResponse<List<MerchantOrder>> response = executor.execute<List<MerchantOrder>>(client, request);

            return response.data;
        }

        public void add()
        {
            throw new NotImplementedException("It is not allowed to add merchant orders via Shopware REST API.");
        }

        public void delete()
        {
            throw new NotImplementedException("It is not allowed to delete merchant orders via Shopware REST API.");
        }
    }
}
