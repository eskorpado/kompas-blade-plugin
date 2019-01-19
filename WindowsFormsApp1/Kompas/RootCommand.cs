using WindowsFormsApp1.Model;
using Kompas6API5;
using Kompas6Constants3D;

namespace WindowsFormsApp1.Kompas
{
    internal partial class KompasWrapper
    {
        /// <summary>
        /// Команда, инициализируюзая документ Компас и исполняющая все вложенные команды
        /// </summary>
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
    }
}