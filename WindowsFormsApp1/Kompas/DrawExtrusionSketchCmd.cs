using Kompas6API5;
using Kompas6Constants3D;

namespace WindowsFormsApp1.Kompas
{
    public partial class KompasWrapper
    {
        /// <summary>
        /// Команда, создающая профильный эскиз клинка
        /// </summary>
        private class DrawExtrusionSketchCmd : DrawSketchCmd
        {
            protected override void DrawSketch(ksDocument2D sketchEdit)
            {
                var m = Model;
                var p1 = Point.Pnt(-m.BladeLength * .8, m.BladeHeight / 2);
                var p2 = Point.Pnt(0, m.BladeHeight / 2);
                var p3 = Point.Pnt(0, m.BladeHeight * .34);
                var p4 = Point.Pnt(m.HandleLength, m.BladeHeight * .1);
                var p5 = Point.Pnt(m.HandleLength, -m.BladeHeight * .1);
                var p6 = Point.Pnt(0, -m.BladeHeight * .34);
                var p7 = Point.Pnt(0, -m.BladeHeight / 2);
                var p8 = Point.Pnt(-m.BladeLength * .8, -m.BladeHeight / 2);
                var p9 = Point.Pnt(-m.BladeLength, m.BladeHeight * .2);
                DrawLine(sketchEdit, p1, p2, p3, p4, p5, p6, p7, p8);
                sketchEdit.ksArcBy3Points(p8.Coordinate1, p8.Coordinate2, p8.Coordinate1 - 1, p8.Coordinate2,
                    p9.Coordinate1, p9.Coordinate2, 1);
                sketchEdit.ksArcBy3Points(p9.Coordinate1, p9.Coordinate2, p9.Coordinate1 + 1, p9.Coordinate2,
                    p1.Coordinate1, p1.Coordinate2, 1);
                sketchEdit.ksCircle(m.HandleLength / 2, 0, m.HandleBoreDiameter / 2, 1);
            }

            protected override ksEntity GetPlane()
            {
                return Part.GetDefaultEntity((short) Obj3dType.o3d_planeYOZ);
            }
        }
    }
}