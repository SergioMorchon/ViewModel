using ViewModel;
using Xunit;

namespace Tests
{
    public class BindableBaseTest
    {
        [Fact]
        public void TestAll() 
        {
            var called = false;
            var calledPropertyName = "";
            var puppy = new Pet();
            puppy.PropertyChanged += (sender, e) =>
            {
                called = true;
                calledPropertyName = e.PropertyName;
            };
            Assert.False(called);
            var newName = "Tutupa";
            puppy.Name = newName;
            Assert.True(called);
            Assert.Equal(nameof(puppy.Name), calledPropertyName);
            Assert.Equal(newName, puppy.Name);
        }

        private class Pet : BindableBase
        {
            private string name;
            public string Name { get { return name; } set { Set(ref name, value); } }
        }
    }
}