using NUnit.Framework;
using Services;
using Data;
using Services.Logic;
using Services.Filters;
using Services.Entity;
using System.Collections.Generic;

namespace UnitTestServices
{
    [TestFixture]
    public class Tests
    {
        private Acctions _acctions;
        private TraslapEntityToDictionary _traslapEntityToDictionary;
        private OwnerService _services;
        private PropertyService _propertyService;

        [SetUp]
        public void Setup()
        {
            _acctions = new Acctions();
            _traslapEntityToDictionary = new TraslapEntityToDictionary();
            _services = new OwnerService(_acctions, _traslapEntityToDictionary);
            _propertyService = new PropertyService(_acctions);
        }

        [Test]
        public void TestOwner()
        {
            FilterOwner filterOwner = new FilterOwner()
            {
                NickName = "Company",
                Password = "123456"
            };

            Owner result = _services.AuthUser(filterOwner);

            Assert.IsTrue(result != null);
        }

        [Test]
        public void TestProperty()
        {
            List<Property> properties = _propertyService.getPropertisByOwnerId(1000);

            Assert.IsTrue(properties.Count > 0);
        }
    }
}