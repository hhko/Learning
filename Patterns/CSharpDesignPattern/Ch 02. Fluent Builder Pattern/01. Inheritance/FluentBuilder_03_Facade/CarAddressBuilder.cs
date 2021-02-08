using System;
using System.Collections.Generic;
using System.Text;

namespace FluentBuilder_03_Facade
{
    // 상속?
    public class CarAddressBuilder : CarBuilderFacade
    {
        public CarAddressBuilder(Car car)
        {
            Car = car;
        }

        public CarAddressBuilder InCity(string city)
        {
            Car.City = city;
            return this;
        }

        public CarAddressBuilder AtAddress(string address)
        {
            Car.Address = address;
            return this;
        }
    }
}
