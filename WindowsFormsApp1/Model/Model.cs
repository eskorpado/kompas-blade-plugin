using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WindowsFormsApp1.Model
{
    public class Blade : IValidatableObject
    {
        [Range(100, 150, ErrorMessage = "Длина клинка должна быть от 100 до 150 мм")]
        public double BladeLength { get; }
        [Range(100, 150, ErrorMessage = "Длина рукояти должна быть от 100 до 150 мм")]
        public double HandleLength { get; }
        [Range(4, 8, ErrorMessage = "Диаметр отверстия рукояти должен быть от 4 до 8 мм")]
        public double HandleBoreDiameter { get; }
        [Range(3, 6, ErrorMessage = "Ширина обуха должна быть от 3 до 6 мм")]
        public double ButtWidth { get; }
        [Range(15, 30, ErrorMessage = "Высота клинка должна быть от 15 - до 30 мм")]
        public double BladeHeight { get; }
        [Range(10, 15, ErrorMessage = "Высота спуска должна быть от 10 до 20 мм")]
        public double GrindHeight { get; }
        public double GripLength { get; }
        public double GripWidth { get; }
        public double GripHeight { get; }

        public Blade(double bladeLength, double handleLength, double handleBoreDiameter, double buttWidth, 
            double bladeHeight, double grindHeight, double gripLength, double gripWidth, double gripHeight)
        {
            BladeLength = bladeLength;
            HandleLength = handleLength;
            HandleBoreDiameter = handleBoreDiameter;
            ButtWidth = buttWidth;
            BladeHeight = bladeHeight;
            GrindHeight = grindHeight;
            GripLength = gripLength;
            GripWidth = gripWidth;
            GripHeight = gripHeight;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!IsGridHeightValid())
            {
                yield return new ValidationResult("Высота спуска не может составлять больше 60% от высоты клинка");
            }
            if (!IsGripLengthValid())
            {
                yield return new ValidationResult("Длина ручки ножа должна быть больше длины рукояти клинка");
            }
            if (!IsGripWidthValid())
            {
                yield return new ValidationResult("Ширина ручки ножа должна быть больше ширины обуха");
            }
            if (!IsGripHeightValid())
            {
                yield return new ValidationResult("Высота ручки ножа должна быть больше высоты клинка");
            }
        }

        private bool IsGridHeightValid()
        {
            return GrindHeight / BladeHeight <= 0.6;
        }

        private bool IsGripLengthValid()
        {
            return GripLength > HandleLength;
        }

        private bool IsGripHeightValid()
        {
            return GripHeight > BladeHeight;
        }

        private bool IsGripWidthValid()
        {
            return GripWidth > ButtWidth;
        }
        
    }
}
