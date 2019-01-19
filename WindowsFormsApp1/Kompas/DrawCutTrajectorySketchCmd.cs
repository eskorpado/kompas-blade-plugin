using Kompas6API5;
using Kompas6Constants3D;

namespace WindowsFormsApp1.Kompas
{
    public partial class KompasWrapper
    {
        /// <summary>
        /// Команда, создающая эскиз траектории выреза для спуска клинка
        /// </summary>
        private class DrawCutTrajectorySketchCmd : DrawSketchCmd
        {
            protected override void DrawSketch(ksDocument2D sketchEdit)
            {
                var p1 = Point.Pnt(-12, -Model.BladeHeight / 2);
                var p2 = Point.Pnt(-Model.BladeLength * .8, -Model.BladeHeight / 2);
                var p3 = Point.Pnt(-Model.BladeLength, Model.BladeHeight * .2);
                DrawLine(sketchEdit, p1, p2);
                sketchEdit.ksArcBy3Points(p2.Coordinate1, p2.Coordinate2, p2.Coordinate1 - 1, p2.Coordinate2,
                    p3.Coordinate1, p3.Coordinate2, 1);
            }

            protected override ksEntity GetPlane()
            {
                return Part.GetDefaultEntity((short) Obj3dType.o3d_planeYOZ);
            }
        }
    }
}