using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Invoke/InvokeInFlipFlop")]
    public class InvokeInFlipFlop : SerializedMonoBehaviour, IExecutable
    {
        [DisplayAsString] [SerializeField] private bool isOnFirstState = true;
        [Space(10)] [SerializeField] private UnityEvent stateA;
        [Space(10)] [SerializeField] private IExecutable stateAexecuteble;
        [Space(10)] [SerializeField] private UnityEvent stateB;
        [Space(10)] [SerializeField] private IExecutable stateBexecutable;


        public void InvokeIt()
        {
            if (isOnFirstState)
            {
                stateA.Invoke();
                if (stateAexecuteble != null) stateAexecuteble.Execute();
                isOnFirstState = false;
            }
            else
            {
                stateB.Invoke();
                if (stateBexecutable != null) stateBexecutable.Execute();
                isOnFirstState = true;
            }
        }

        public void Execute()
        {
            InvokeIt();
        }
    }
}