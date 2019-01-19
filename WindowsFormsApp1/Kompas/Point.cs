namespace WindowsFormsApp1.Kompas
{
    /// <summary>
    /// Вспомогательный класс для создания эскизов
    /// </summary>
    internal class Point
    {
        private Point(double coordinate1, double coordinate2)
        {
            Coordinate1 = coordinate1;
            Coordinate2 = coordinate2;
        }

        public double Coordinate1 { get; }
        public double Coordinate2 { get; }

        public static Point Pnt(double x, double y)
        {
            return new Point(x, y);
        }
    }
}