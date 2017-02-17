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
            var someViewModel = new SomeViewModel();
            someViewModel.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(someViewModel.Result))
                {
                    computedCalledTimes += 1;
                }
            };
            Assert.Equal(0, computedCalledTimes);
            var a = 2;
            var b = 3;
            someViewModel.A = a;
            Assert.Equal(1, computedCalledTimes);
            someViewModel.B = b;
            Assert.Equal(2, computedCalledTimes);
            Assert.Equal(a * b, someViewModel.Result);
        }

        class SomeViewModel : ComputedBindableBase
        {
            private int a;
            public int A { get { return a; } set { Set(ref a, value); } }

            private int b;
            public int B { get { return b; } set { Set(ref b, value); } }

            [PropertySource(nameof(A), nameof(B))]
            public int Result => A * B;
        }
    }
}