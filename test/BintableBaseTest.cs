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
            var someViewModel = new SomeViewModel();
            someViewModel.PropertyChanged += (sender, e) =>
            {
                called = true;
                calledPropertyName = e.PropertyName;
            };
            Assert.False(called);
            var someNewValue = "some new value";
            someViewModel.SomeProperty = someNewValue;
            Assert.True(called);
            Assert.Equal(nameof(someViewModel.SomeProperty), calledPropertyName);
            Assert.Equal(someNewValue, someViewModel.SomeProperty);
        }

        private class SomeViewModel : BindableBase
        {
            private string someProperty;
            public string SomeProperty { get { return someProperty; } set { Set(ref someProperty, value); } }
        }
    }
}