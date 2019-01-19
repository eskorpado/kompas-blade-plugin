using System.Reflection;
using WindowsFormsApp1.Kompas;
using Moq;
using NUnit.Framework;
using Kompas6API5;

namespace Tests
{
    [TestFixture]
    public class WrapperTests
    {
        [Test]
        public void ShouldCloseInvisibleKompas()
        {
            var kompasMock = new Mock<KompasObject>();
            kompasMock.Setup(mock => mock.Visible).Returns(false);
            var wrapper = new KompasWrapper();
            SetPrivateField(wrapper, "_kompas", kompasMock);
            wrapper.CloseInvisible();
            kompasMock.Verify(mock => mock.Quit());
        }

        private static void SetPrivateField(object obj, string fieldName, object value)
        {
            obj.GetType()
                .GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance)
                ?.SetValue(obj, value);
        }
    }
}