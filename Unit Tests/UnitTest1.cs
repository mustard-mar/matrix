using NUnit.Framework;


namespace Unit_Tests
{
    public class Matrix
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void Add()
        {
            StepByStep.Matrix a = new StepByStep.Matrix(2, 2, new double[] { 1, 2, 3, 4 });
            StepByStep.Matrix b = new StepByStep.Matrix(2, 2, new double[] { 4, 3, 2, 1 });

            StepByStep.Matrix c = a + b;

            StepByStep.Matrix d = new StepByStep.Matrix(2, 2, new double[] { 5, 3, 5, 5 });

            for(int i = 0; i < c.GetSizeY(); i++)
            {
                for (int j = 0; j < c.GetSizeX(); j++)
                {
                    Assert.AreEqual(c.GetValue(i, j), d.GetValue(i, j), "[" + i + "," + j + "]");
                }
            }
            Assert.Pass();
        }
    }
}