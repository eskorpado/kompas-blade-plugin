using WindowsFormsApp1.Model;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ModelTests
    {
        [TestCase(100, 100, 4, 4, 20, 10, 101, 30, TestName = "Модель должна быть валидной")]
        public void ModelShouldBeValid(
            double bladeLength, double handleLength, double handleBoreDiameter, double buttWidth, double bladeHeight,
            double grindHeight, double gripLength, double gripDiagonal)
        {
            var model = new Blade(bladeLength, handleLength, handleBoreDiameter, buttWidth,
                bladeHeight, grindHeight, gripLength, gripDiagonal);
            ModelValidator.Validate(model);
        }

        [TestCase(0, 0, 0, 0, 0, 0, 0, 0, TestName = "Модель должна быть невалидной, если параметры не заданы")]
        [TestCase(99, 99, 3, 2, 14, 7, 99, 3, TestName =
            "Модель должна быть невалидной, если параметры больше максимальных")]
        [TestCase(151, 151, 9, 7, 31, 16, 152, 8, TestName =
            "Модель должна быть невалидной, если параметры меньше минимальных")]
        [TestCase(99, 100, 4, 4, 20, 10, 101, 5, TestName =
            "Модель должна быть невалидной, если хотя бы один параметр невалидный")]
        public void ModelShouldBeInvalid(
            double bladeLength, double handleLength, double handleBoreDiameter,double buttWidth, double bladeHeight, 
            double grindHeight, double gripLength, double gripDiagonal)
        {
            var model = new Blade(bladeLength, handleLength, handleBoreDiameter, buttWidth,
                bladeHeight, grindHeight, gripLength, gripDiagonal);
            Assert.Throws<ValidationException>(() => ModelValidator.Validate(model));
        }
    }
}