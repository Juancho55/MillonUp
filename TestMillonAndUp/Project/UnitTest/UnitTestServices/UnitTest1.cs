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
        private PropertyImageService _propertyImageService;
        private PropertyTraceServices _propertyTraceServices;

        [SetUp]
        public void Setup()
        {
            _acctions = new Acctions();
            _traslapEntityToDictionary = new TraslapEntityToDictionary();
            _services = new OwnerService(_acctions, _traslapEntityToDictionary);
            _propertyService = new PropertyService(_acctions);
            _propertyImageService = new PropertyImageService(_acctions);
            _propertyTraceServices = new PropertyTraceServices(_acctions);
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

        [Test]
        public void TestPropertyImages()
        {
            List<PropertyImage> propertiesImages = _propertyImageService.getsImagesByPropertyId(10007);

            Assert.IsTrue(propertiesImages.Count > 0);
        }

        [Test]
        public void TestPropertyTraces()
        {
            List<PropertyTrace> propertiesTraces = _propertyTraceServices.GetPropertyTracesByPropertyId(10007);

            Assert.IsTrue(propertiesTraces.Count > 0);
        }
    }
}