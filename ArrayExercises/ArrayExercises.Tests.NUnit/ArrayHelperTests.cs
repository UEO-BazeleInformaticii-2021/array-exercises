using NUnit.Framework;

namespace ArrayExercises.Tests.NUnit
{
    public class ArrayHelperTests
    {
        [Test]
        public void Min_WhenArrayIsNull_ExpectThatMinReturnsMinValue()
        {
            int[] array = null;
            int min = ArrayHelper.Min(array);

            Assert.AreEqual(int.MinValue, min);
        }

        [Test]
        public void Min_WhenArrayIsInitialized_ExpectThatMinIsCorrectlyCalculated()
        {
            int[] array = { 10, 5, -1, 3, -100 };
            int min = ArrayHelper.Min(array);

            Assert.AreEqual(-100, min);
        }

        [Test]
        public void Clone_WhenArrayIsInitialized_ExpectThatReturnsAnIdenticalCopy()
        {
            int[] array = { 1, 2, 3, 4 };
            int[] clone = ArrayHelper.Clone(array);

            CollectionAssert.AreEqual(array, clone);
        }
    }
}