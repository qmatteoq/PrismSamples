using HelloMvvm.Repositories;
using HelloMvvm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prism.Events;
using Prism.Regions;

namespace HelloMvvm.Tests
{
    [TestClass]
    public class EmployeeEditorViewModelUnitTests
    {
        [TestMethod]
        public void AddCommand_CannotExecute_WithInvalidProperties()
        {
            // Arrange.
            var repoMock = new Mock<IEmployeeRepository>(MockBehavior.Loose);
            var navigationMock = new Mock<IRegionManager>(MockBehavior.Loose);
            var eventAggregatorMock = new Mock<IEventAggregator>(MockBehavior.Loose);
            var sut = new EmployeeEditorViewModel(repoMock.Object, navigationMock.Object, eventAggregatorMock.Object);
            // Act.
            sut.Firstname = "";
            sut.Lastname = "";
            // Assert.
            Assert.IsTrue(sut.HasErrors);
            Assert.IsFalse(sut.AddCommand.CanExecute());
        }

        [TestMethod]
        public void AddCommand_CanExecute_WithValidProperties()
        {
            // Arrange.
            var repoMock = new Mock<IEmployeeRepository>(MockBehavior.Loose);
            var navigationMock = new Mock<IRegionManager>(MockBehavior.Loose);
            var eventAggregatorMock = new Mock<IEventAggregator>(MockBehavior.Loose);
            var sut = new EmployeeEditorViewModel(repoMock.Object, navigationMock.Object, eventAggregatorMock.Object);
            // Act.
            sut.Firstname = "John";
            sut.Lastname = "Doe";
            // Assert.
            Assert.IsFalse(sut.HasErrors);
            Assert.IsTrue(sut.AddCommand.CanExecute());
        }
    }
}
