using Core.Interfaces;
using Core.Model;
using Core.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Core.Services.FamilyServiceTests
{
    [TestClass]
    public class CreateFamilyTests
    {
        #region CreateFamily_CheckIf_RepositoryAddAsyncMethod_IsCalled()
        [TestMethod]
        public void CreateFamily_CheckIf_RepositoryAddAsyncMethod_IsCalled()
        {
            //Arange.
            var repoMock = new Mock<IFamilyRepository>();
            repoMock.Setup(c => c.AddAsync(It.IsAny<Family>()));

            var service = new FamilyService(repoMock.Object);

            //Act.
            service.CreateAsync(new Family());

            //Assert.
            repoMock.VerifyAll();
        }
        #endregion

        #region CreateFamily_CheckIf_RepositoryAddMethod_IsCalled_Failed()
        [TestMethod]
        public void CreateFamily_CheckIf_RepositoryAddMethod_IsCalled_Failed()
        {
            //Arange.
            var repoMock = new Mock<IFamilyRepository>();
            repoMock.Setup(c => c.Add(It.IsAny<Family>()));

            var service = new FamilyService(repoMock.Object);

            //Act.
            service.CreateAsync(new Family());

            //Assert.
            repoMock.VerifyAll();
        }
        #endregion

    }
}
