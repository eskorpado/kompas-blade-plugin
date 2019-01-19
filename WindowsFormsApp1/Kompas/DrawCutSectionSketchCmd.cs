using Kompas6API5;
using Kompas6Constants3D;

namespace WindowsFormsApp1.Kompas
{
    internal partial class KompasWrapper
    {
        /// <summary>
        /// Команда, создающая эскиз сечения спуска клинка
        /// </summary>
        private class DrawCutSectionSketchCmd : DrawSketchCmd
        {
            protected override void DrawSketch(ksDocument2D sketchEdit)
            {
                var m = Model;
                var p1 = Point.Pnt(-m.ButtWidth, m.BladeHeight / 2 + 1);
                var p2 = Point.Pnt(0, m.BladeHeight / 2 + 1);
                var p3 = Point.Pnt(0, m.BladeHeight / 2 - m.GrindHeight);
                var p4 = Point.Pnt(-m.ButtWidth / 2, m.BladeHeight / 2);
                var p5 = Point.Pnt(-m.ButtWidth, m.BladeHeight / 2 - m.GrindHeight);
                DrawLine(sketchEdit, p1, p2, p3, p4, p5, p1);
            }

            protected override ksEntity GetPlane()
            {
                ksEntity xoyPlane = Part.GetDefaultEntity((short) Obj3dType.o3d_planeXOY);
                ksEntity plane = Part.NewEntity((short) Obj3dType.o3d_planeOffset);
                ksPlaneOffsetDefinition definition = plane.GetDefinition();
                definition.direction = true;
                definition.offset = 12;
                definition.SetPlane(xoyPlane);
                plane.Create();
                return plane;
            }
        }
    }
}