using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Test
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void Employee_LessThanEighteenYearsOld_ShouldThrowExceptionOnCalculatingSalary()
        {
            var builder = new EmployeeTestBuilder();

            var employee = builder
                .WithName("John")
                .HasAge(16)
                .HasGrossSalaryOf(1000)
                .Build();

            Action calculateSalaryAction = () => employee.CalculateNetSalary();
            calculateSalaryAction.ShouldThrow<InvalidOperationException>().WithMessage("Age less than 18");
        }

        [TestMethod]
        public void Employee_Between18And30YearsOld_ShouldHave80PercentOfHisGrossSalary()
        {
            var builder = new EmployeeTestBuilder();

            var employee = builder
                .WithName("Mary")
                .HasAge(23)
                .HasGrossSalaryOf(1000)
                .Build();

            employee.CalculateNetSalary().Should().Be(800);
        }

        [TestMethod]
        public void Employee_WithMoreThan30YearsOld_ShouldHave85PercentOfHisGrossSalary()
        {
            var builder = new EmployeeTestBuilder();

            var employee = builder
                .WithName("Samuel")
                .HasAge(35)
                .HasGrossSalaryOf(1000)
                .Build();

            employee.CalculateNetSalary().Should().Be(850);
        }
    }
}
