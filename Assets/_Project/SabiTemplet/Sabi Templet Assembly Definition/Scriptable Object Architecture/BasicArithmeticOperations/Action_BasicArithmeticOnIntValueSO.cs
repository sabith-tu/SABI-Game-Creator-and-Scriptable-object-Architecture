using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.SOA.BasicArithmeticOperations
{
    [AddComponentMenu("_SABI/Action/BasicArithmetic/BasicArithmeticOnIntValueSO")]
    public class Action_BasicArithmeticOnIntValueSO : SerializedMonoBehaviour, IExecutable
    {
        [Space(5)] [SerializeField] private IntReference firstVariable;

        [Space(5)] [SerializeField]
        private BasicArithmeticForNumbers arithmeticForNumbersOperation = BasicArithmeticForNumbers.Multiplication;

        [Space(5)] [SerializeField] private IntReference secondVariable;

        [PropertySpace(SpaceAfter = 5)] [SerializeField]
        private IntReference resultVariable;

        [PropertySpace(SpaceAfter = 5)] [SerializeField]
        private UnityEvent OnComplete;

        [PropertySpace(SpaceAfter = 5)] [SerializeField]
        private IExecutable OnCompleteExecutable;

        [Button]
        public void DoBasicArithmetic()
        {
            switch (arithmeticForNumbersOperation)
            {
                case BasicArithmeticForNumbers.Addition:
                    resultVariable.SetValue(firstVariable.GetValue() + secondVariable.GetValue());
                    break;
                case BasicArithmeticForNumbers.Subtraction:
                    resultVariable.SetValue(firstVariable.GetValue() - secondVariable.GetValue());
                    break;
                case BasicArithmeticForNumbers.Multiplication:
                    resultVariable.SetValue(firstVariable.GetValue() * secondVariable.GetValue());
                    break;
                case BasicArithmeticForNumbers.Division:
                    resultVariable.SetValue(firstVariable.GetValue() / secondVariable.GetValue());
                    break;
                case BasicArithmeticForNumbers.Modulus:
                    resultVariable.SetValue(firstVariable.GetValue() % secondVariable.GetValue());
                    break;
            }

            OnComplete.Invoke();
            if(OnCompleteExecutable != null) OnCompleteExecutable.Execute();
        }

        public void Execute()
        {
            DoBasicArithmetic();
        }
    }
}