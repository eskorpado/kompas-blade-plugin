using System;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApp1.Model;
using Kompas6API5;
using Kompas6Constants3D;
using static WindowsFormsApp1.Kompas.Point;

namespace WindowsFormsApp1.Kompas
{
    internal partial class KompasWrapper
    {
        private class ExtrudeCmd : CompositeCommand
        {
            private readonly IKompasCommand _drawSketchCommand;

            public ExtrudeCmd(IKompasCommand drawSketchCommand) : base(drawSketchCommand)
            {
                _drawSketchCommand = drawSketchCommand;
            }

            public override ksEntity Execute()
            {
                ksEntity extrusion = Part.NewEntity((short) Obj3dType.o3d_baseExtrusion);
                ksBaseExtrusionDefinition definition = extrusion.GetDefinition();
                definition.SetSideParam(true, 0, Model.ButtWidth, 0, true);
                definition.SetSketch(_drawSketchCommand.Execute());
                extrusion.Create();
                return extrusion;
            }
        }

        private class ExtrudeGripCmd : CompositeCommand
        {
            private readonly IKompasCommand _drawSketchCommand;

            public ExtrudeGripCmd(IKompasCommand drawSketchCommand) : base(drawSketchCommand)
            {
                _drawSketchCommand = drawSketchCommand;
            }

            public override ksEntity Execute()
            {
                ksEntity extrusion = Part.NewEntity((short) Obj3dType.o3d_baseExtrusion);
                ksBaseExtrusionDefinition definition = extrusion.GetDefinition();
                definition.SetSideParam(true, 0, Model.GripLength, 0, true);
                definition.SetSketch(_drawSketchCommand.Execute());
                extrusion.Create();
                return extrusion;
            }
        }

        private class CutCmd : CompositeCommand
        {
            private readonly IKompasCommand _drawSectionCmd;
            private readonly IKompasCommand _drawTrajectoryCmd;

            public CutCmd(IKompasCommand drawSectionCmd, IKompasCommand drawTrajectoryCmd) : base(drawSectionCmd,
                drawTrajectoryCmd)
            {
                _drawSectionCmd = drawSectionCmd;
                _drawTrajectoryCmd = drawTrajectoryCmd;
            }

            public override ksEntity Execute()
            {
                ksEntity cut = Part.NewEntity((short) Obj3dType.o3d_cutEvolution);
                ksCutEvolutionDefinition definition = cut.GetDefinition();
                definition.cut = true;
                definition.sketchShiftType = 1;
                definition.SetSketch(_drawSectionCmd.Execute());

                ksEntityCollection entityCollection = definition.PathPartArray();
                entityCollection.Clear();
                entityCollection.Add(_drawTrajectoryCmd.Execute());
                cut.Create();
                return cut;
            }
        }

        private class FilletGripFacesCmd : CompositeCommand
        {
            private readonly IKompasCommand _extrudeHandleCmd;

            public FilletGripFacesCmd(IKompasCommand extrudeHandleCmd) : base(extrudeHandleCmd)
            {
                _extrudeHandleCmd = extrudeHandleCmd;
            }

            public override ksEntity Execute()
            {
                _extrudeHandleCmd.Execute();
                ksEntity fillet = Part.NewEntity((short) Obj3dType.o3d_fillet);
                ksFilletDefinition filletDefinition = fillet.GetDefinition();
                filletDefinition.radius = 1;
                filletDefinition.tangent = false;
                ksEntityCollection facesToFillet = filletDefinition.array();
                facesToFillet.Clear();
                ksEntityCollection partFaces = Part.EntityCollection((short) Obj3dType.o3d_face);
                for (int i = 0; i < partFaces.GetCount(); i++)
                {
                    facesToFillet.Add(partFaces.GetByIndex(i));
                }

                fillet.Create();
                return fillet;
            }
        }

        private class DrawExtrusionSketchCmd : DrawSketchCmd
        {
            protected override void DrawSketch(ksDocument2D sketchEdit)
            {
                var m = Model;
                var p1 = Pnt(-m.BladeLength * .8, m.BladeHeight / 2);
                var p2 = Pnt(0, m.BladeHeight / 2);
                var p3 = Pnt(0, m.BladeHeight * .34);
                var p4 = Pnt(m.HandleLength, m.BladeHeight * .1);
                var p5 = Pnt(m.HandleLength, -m.BladeHeight * .1);
                var p6 = Pnt(0, -m.BladeHeight * .34);
                var p7 = Pnt(0, -m.BladeHeight / 2);
                var p8 = Pnt(-m.BladeLength * .8, -m.BladeHeight / 2);
                var p9 = Pnt(-m.BladeLength, m.BladeHeight * .2);
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

        private class DrawCutSectionSketchCmd : DrawSketchCmd
        {
            protected override void DrawSketch(ksDocument2D sketchEdit)
            {
                var m = Model;
                var p1 = Pnt(-m.ButtWidth, m.BladeHeight / 2 + 1);
                var p2 = Pnt(0, m.BladeHeight / 2 + 1);
                var p3 = Pnt(0, m.BladeHeight / 2 - m.GrindHeight);
                var p4 = Pnt(-m.ButtWidth / 2, m.BladeHeight / 2);
                var p5 = Pnt(-m.ButtWidth, m.BladeHeight / 2 - m.GrindHeight);
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

        private class DrawGripSketchCmd : DrawSketchCmd
        {
            protected override void DrawSketch(ksDocument2D sketchEdit)
            {
                var m = Model;
                var p1 = Pnt(-m.GripWidth / 2 - m.ButtWidth / 2, -m.GripHeight / 2);
                var p2 = Pnt(-m.GripWidth / 2 - m.ButtWidth / 2, m.GripHeight / 2);
                var p3 = Pnt(m.GripWidth / 2 - m.ButtWidth / 2, m.GripHeight / 2);
                var p4 = Pnt(m.GripWidth / 2 - m.ButtWidth / 2, -m.GripHeight / 2);
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

        private class DrawCutTrajectorySketchCmd : DrawSketchCmd
        {
            protected override void DrawSketch(ksDocument2D sketchEdit)
            {
                var p1 = Pnt(-12, -Model.BladeHeight / 2);
                var p2 = Pnt(-Model.BladeLength * .8, -Model.BladeHeight / 2);
                var p3 = Pnt(-Model.BladeLength, Model.BladeHeight * .2);
                DrawLine(sketchEdit, p1, p2);
                sketchEdit.ksArcBy3Points(p2.Coordinate1, p2.Coordinate2, p2.Coordinate1 - 1, p2.Coordinate2,
                    p3.Coordinate1, p3.Coordinate2, 1);
            }

            protected override ksEntity GetPlane()
            {
                return Part.GetDefaultEntity((short) Obj3dType.o3d_planeYOZ);
            }
        }

        private abstract class DrawSketchCmd : SingleCommand
        {
            protected static void DrawLine(ksDocument2D sketchEdit, params Point[] points)
            {
                if (points.Length < 2)
                {
                    throw new ArgumentException("At least two points required");
                }

                for (var i = 1; i < points.Length; i++)
                {
                    var p1 = points[i - 1];
                    var p2 = points[i];
                    sketchEdit.ksLineSeg(p1.Coordinate1, p1.Coordinate2, p2.Coordinate1, p2.Coordinate2, 1);
                }
            }

            public override ksEntity Execute()
            {
                ksEntity sketch = Part.NewEntity((short) Obj3dType.o3d_sketch);
                ksSketchDefinition definition = sketch.GetDefinition();
                definition.SetPlane(GetPlane());
                sketch.Create();
                DrawSketch(definition.BeginEdit());
                definition.EndEdit();
                return sketch;
            }

            protected abstract void DrawSketch(ksDocument2D sketchEdit);

            protected abstract ksEntity GetPlane();
        }

        private class RootCommand : CompositeCommand
        {
            public RootCommand(params IKompasCommand[] commands) : base(commands)
            {
            }

            public IKompasCommand Init(KompasObject kompas, Blade model)
            {
                kompas.ActivateControllerAPI();
                ksDocument3D document3D = kompas.Document3D();
                document3D.Create();
                ksPart part = document3D.GetPart((short) Part_Type.pTop_Part);
                Init(part, model);
                return this;
            }
        }

        private abstract class CompositeCommand : IKompasCommand
        {
            private readonly List<IKompasCommand> _commands;
            protected ksPart Part;
            protected Blade Model;

            protected CompositeCommand(params IKompasCommand[] commands)
            {
                _commands = commands.ToList();
            }

            public virtual ksEntity Execute()
            {
                _commands.ForEach(cmd => cmd.Execute());
                return default(ksEntity);
            }

            public void Init(ksPart shared, Blade model)
            {
                Part = shared;
                Model = model;
                _commands.ForEach(cmd => cmd.Init(shared, model));
            }
        }

        private abstract class SingleCommand : IKompasCommand
        {
            protected ksPart Part;
            protected Blade Model;

            public abstract ksEntity Execute();

            public void Init(ksPart part, Blade model)
            {
                Part = part;
                Model = model;
            }
        }

        private interface IKompasCommand
        {
            ksEntity Execute();

            void Init(ksPart part, Blade model);
        }
    }

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