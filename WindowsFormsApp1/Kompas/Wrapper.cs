using System;
using System.Runtime.InteropServices;
using System.Threading;
using WindowsFormsApp1.Model;
using Kompas6API5;

namespace WindowsFormsApp1.Kompas
{
    partial class KompasWrapper
    {
        private KompasObject _kompas;

        public KompasWrapper()
        {
            Init();
        }

        public void BuildPart(Blade model)
        {
            if (!IsCompassRunning())
            {
                Init();
            }
            new RootCommand(
                new FilletGripFacesCmd(new ExtrudeGripCmd(new DrawGripSketchCmd())),
                new ExtrudeCmd(new DrawExtrusionSketchCmd()),
                new CutCmd(new DrawCutSectionSketchCmd(), new DrawCutTrajectorySketchCmd())
            ).Init(_kompas, model).Execute();
            _kompas.Visible = true;
        }

        public void CloseInvisible()
        {
            if (IsCompassRunning() && !_kompas.Visible)
            {
                _kompas.Quit();
            }
        }

        private bool IsCompassRunning()
        {
            try
            {
                var kompasVisible = _kompas.Visible;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void Init()
        {
            Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");
            _kompas = (KompasObject)Activator.CreateInstance(type);
        }
    }
}