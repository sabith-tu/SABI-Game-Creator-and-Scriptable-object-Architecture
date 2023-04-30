using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Trigger/Trigger_OnKeyPress")]
    public class Trigger_OnKeyPress : SerializedMonoBehaviour, IExecutable
    {
        [Space(10)] [SerializeField] private KeyCode key;
        [Space(10)] [SerializeField] UnityEvent whatToInvoke;
        [Space(10)] [SerializeField] IExecutable whatToExecute;

        private void Update()
        {
            if (Input.GetKeyDown(key)) InvokeIt();
        }

        [Button]
        [PropertySpace(10)]
        public void InvokeIt()
        {
            whatToInvoke.Invoke();
            if (whatToExecute != null) whatToExecute.Execute();
        }

        public void Execute()
        {
            InvokeIt();
        }
    }
}