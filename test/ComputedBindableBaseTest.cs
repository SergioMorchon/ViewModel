using ViewModel;
using Xunit;

namespace Tests
{
    public class ComputedBindableBaseTest
    {
        [Fact]
        public void TestAll() 
        {
            var computedCalledTimes = 0;
            var lastFullname = "";
            var wololo = new Contact();
            wololo.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(wololo.Fullname))
                {
                    computedCalledTimes += 1;
                    lastFullname = wololo.Fullname;
                }
            };
            Assert.Equal(0, computedCalledTimes);
            Assert.Equal("", lastFullname);
            wololo.Name = "Servostasio";
            Assert.Equal(1, computedCalledTimes);
            Assert.Equal("Servostasio", lastFullname);
            wololo.Surname = "Tandori";
            Assert.Equal(2, computedCalledTimes);
            Assert.Equal("Servostasio Tandori", lastFullname);
            Assert.Equal("Servostasio Tandori", wololo.Fullname);
        }

        class Contact : ComputedBindableBase
        {
            private string name;
            public string Name { get { return name; } set { Set(ref name, value); } }

            private string surname;
            public string Surname { get { return surname; } set { Set(ref surname, value); } }

            [PropertySource(nameof(Name), nameof(Surname))]
            public string Fullname => $"{Name} {Surname}".Trim();
        }
    }
}