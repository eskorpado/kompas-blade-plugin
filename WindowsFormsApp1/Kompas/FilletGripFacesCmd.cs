using Kompas6API5;
using Kompas6Constants3D;

namespace WindowsFormsApp1.Kompas
{
    internal partial class KompasWrapper
    {
        /// <summary>
        /// Комада, выполняющая скругление граней ручки ножа
        /// </summary>
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
    }
}