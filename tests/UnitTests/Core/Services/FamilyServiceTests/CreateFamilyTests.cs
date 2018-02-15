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

        #region CreateFamily_AddExistingFamily_Pass()
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateFamily_AddExistingFamily_Pass()
        {
            //Arrange.
            var mockRepo = new Mock<IFamilyRepository>();
            var service = new FamilyService(mockRepo.Object);

            mockRepo.Setup(x => x.Add(It.IsAny<Family>()));

            //Act.
            service.CreateAsync(Mock.Of<Family>(c => c.Name == "Wolfs" && c.Id == 15));

            //Assert - no assert.
        }
        #endregion

    }
}
