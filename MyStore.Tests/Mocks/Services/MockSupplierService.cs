using Moq;
using MyStore.Domain.Entities;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests.Mocks.Services
{
    class MockSupplierService : Mock<ISupplierService>
    {
        public MockSupplierService MockAllSuppliers(List<SupplierModel> result)
        {
            Setup(x => x.GetAll()).Returns(result);
            return this;
        }

        public MockSupplierService MockSupplierById(SupplierModel result)
        {
            Setup(x => x.GetById(It.IsAny<int>())).Returns(result);
            return this;
        }
    }
}
