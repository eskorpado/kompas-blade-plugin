using Kompas6API5;
using Kompas6Constants3D;

namespace WindowsFormsApp1.Kompas
{
    internal partial class KompasWrapper
    {
        /// <summary>
        /// Команда выполняющая вырез спуска клинка
        /// </summary>
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
    }
}