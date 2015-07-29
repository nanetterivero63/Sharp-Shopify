﻿using Machine.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopifySharp.Tests
{
    [Subject(typeof(ShopifyCustomerService))]
    public class When_retrieving_a_customer_with_fields
    {
        Establish context = () =>
        {
            _Service = new ShopifyCustomerService(Utils.MyShopifyUrl, Utils.AccessToken);

            //Get a random customer ID
            _Id = _Service.ListAsync().Await().AsTask.Result.FirstOrDefault().Id;

            // # # #
            // TODO: Create a customer to ensure this test always has a customer to retrieve.
            // # # #
        };

        Because of = () =>
        {
            _Result = _Service.GetAsync(_Id, "first_name,last_name").Await().AsTask.Result;
        };

        It should_retrieve_a_customer_with_certain_fields = () =>
        {
            _Result.ShouldNotBeNull();
            string.IsNullOrEmpty(_Result.FirstName).ShouldBeFalse();
            string.IsNullOrEmpty(_Result.LastName).ShouldBeFalse();
            _Result.Addresses.ShouldBeNull();
            _Result.DefaultAddress.ShouldBeNull();
        };

        Cleanup after = () =>
        {

        };

        static long _Id;
        static ShopifyCustomerService _Service;
        static ShopifyCustomer _Result;
    }
}
