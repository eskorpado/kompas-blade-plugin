using Kompas6API5;
using Kompas6Constants3D;

namespace WindowsFormsApp1.Kompas
{
    internal partial class KompasWrapper
    {
        /// <summary>
        /// Команда, выполняющая выдавливание профильного эскиза клинка
        /// </summary>
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
    }
}