using System;
using System.Collections.Generic;
using System.Linq;
using WindowsFormsApp1.Model;
using Kompas6API5;
using Kompas6Constants3D;

namespace WindowsFormsApp1.Kompas
{
    public partial class KompasWrapper
    {
        /// <summary>
        /// Базовая команда для создания эскиза
        /// </summary>
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

        /// <summary>
        /// Составная команда инициалищируею и исполняет вложенные команды
        /// </summary>
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

        /// <summary>
        /// Базовый класс для одиночной команды
        /// </summary>
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
}