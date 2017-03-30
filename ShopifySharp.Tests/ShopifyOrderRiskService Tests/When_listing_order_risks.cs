﻿using Machine.Specifications;
using System.Collections.Generic;
using System.Linq;

namespace ShopifySharp.Tests.ShopifyOrderRiskService_Tests
{
    [Subject(typeof(OrderRiskService))]
    class When_listing_order_risks
    {
        Establish context = () =>
        {
            OrderId = RiskUtils.GetOrderId().Await().AsTask.Result;
        };

        Because of = () =>
        {
            Risks = Service.ListAsync(OrderId).Await().AsTask.Result;
        };

        It should_list_order_risks = () =>
        {
            Risks.ShouldNotBeNull();
            
            // Not all orders have a risk
            if (Risks.Count() >= 1)
            {
                Risks.All(r => r.OrderId.HasValue).ShouldBeTrue();
                Risks.All(r => string.IsNullOrEmpty(r.Message) == false).ShouldBeTrue();
                Risks.All(r => r.Id.HasValue).ShouldBeTrue();
            }
        };

        Cleanup after = () =>
        {

        };

        static long OrderId { get; set; }

        static OrderRiskService Service = new OrderRiskService(Utils.MyShopifyUrl, Utils.AccessToken);

        static IEnumerable<OrderRisk> Risks;
    }
}
