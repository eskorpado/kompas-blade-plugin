using Kompas6API5;
using Kompas6Constants3D;

namespace WindowsFormsApp1.Kompas
{
    public partial class KompasWrapper
    {
        /// <summary>
        /// Команда, создающая эскиз ручки ножа
        /// </summary>
        private class DrawGripSketchCmd : DrawSketchCmd
        {
            protected override void DrawSketch(ksDocument2D sketchEdit)
            {
                var m = Model;
                var p1 = Point.Pnt(-m.GripWidth / 2 - m.ButtWidth / 2, -m.GripHeight / 2);
                var p2 = Point.Pnt(-m.GripWidth / 2 - m.ButtWidth / 2, m.GripHeight / 2);
                var p3 = Point.Pnt(m.GripWidth / 2 - m.ButtWidth / 2, m.GripHeight / 2);
                var p4 = Point.Pnt(m.GripWidth / 2 - m.ButtWidth / 2, -m.GripHeight / 2);
                DrawLine(sketchEdit, p1, p2, p3, p4, p1);
            }

            protected override ksEntity GetPlane()
            {
                ksEntity xoyPlane = Part.GetDefaultEntity((short) Obj3dType.o3d_planeXOY);
                ksEntity plane = Part.NewEntity((short) Obj3dType.o3d_planeOffset);
                ksPlaneOffsetDefinition definition = plane.GetDefinition();
                definition.direction = false;
                definition.offset = Model.GripLength;
                definition.SetPlane(xoyPlane);
                plane.Create();
                return plane;
//                return Part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            }
        }
    }
}