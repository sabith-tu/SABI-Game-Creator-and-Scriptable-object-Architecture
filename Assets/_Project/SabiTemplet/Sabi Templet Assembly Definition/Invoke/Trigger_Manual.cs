using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Trigger/Trigger_Manual")]
    public class Trigger_Manual : SerializedMonoBehaviour, IExecutable
    {
        [Space(10)] [SerializeField] private bool invokeOnStart = false;
        [Space(10)] [SerializeField] UnityEvent whatToInvoke;
        [Space(10)] [SerializeField] IExecutable whatToExecute;

        [Button]
        [PropertySpace(10)]
        public void InvokeIt()
        {
            whatToInvoke.Invoke();
            if (whatToExecute != null) whatToExecute.Execute();
        }

        private void Start()
        {
            if (invokeOnStart) InvokeIt();
        }

        public void Execute()
        {
            InvokeIt();
        }
    }
}