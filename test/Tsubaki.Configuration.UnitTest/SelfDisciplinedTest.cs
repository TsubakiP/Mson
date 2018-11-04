// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.UnitTest
{
    using NUnit.Framework;

    using System;

    [TestFixture]
    public class SelfDisciplinedTest
    {
        [TestCase]
        public void SerializeAndDeserialize()
        {
            var guid = Guid.NewGuid().ToString();
            var model = TestModel.Load();
            model.GuidString = guid;
            model.Save();

            model = TestModel.Load();
            Assert.AreEqual(guid, model.GuidString);
        }
    }
}
// Author: Viyrex(aka Yuyu)
// Contact: mailto:viyrex.aka.yuyu@gmail.com
// Github: https://github.com/0x0001F36D

namespace Tsubaki.Configuration.UnitTest
{
}