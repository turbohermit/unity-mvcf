using System;

namespace MVCF.Models
{
    public class TestValueModel : AModel
    {
        public int value = 1;

        public Action<TestValueModel> OnUpdate;

        private int valueToIncrease = 3;

        public TestValueModel(int p_initialValue)
        {
            value = p_initialValue;
        }

        public void AddValue()
        {
            value += valueToIncrease;
            OnUpdate?.Invoke(this);
        }

    }
}