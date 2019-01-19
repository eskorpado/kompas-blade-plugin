using Kompas6API5;
using Kompas6Constants3D;

namespace WindowsFormsApp1.Kompas
{
    internal partial class KompasWrapper
    {
        /// <summary>
        /// Команда, выполняющая выдавливание эскиза ручки ножа
        /// </summary>
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
    }
}