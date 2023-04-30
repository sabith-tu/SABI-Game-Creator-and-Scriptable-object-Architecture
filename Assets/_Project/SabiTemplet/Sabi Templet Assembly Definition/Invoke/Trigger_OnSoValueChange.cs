using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Trigger/Trigger_OnSoValueChange")]
    public class Trigger_OnSoValueChange : SerializedMonoBehaviour , IExecutable
    {
        [Space(10)][SerializeField] private bool invokeOnStart;
        [Space(10)] [SerializeField] private SoaBaseVariable baseSoVariable;
        [Space(10)] [SerializeField] private UnityEvent whatToInvoke; 
        [Space(10)] [SerializeField] private IExecutable whatToExecute; 
        

        private void Start()
        {
            if (invokeOnStart) InvokeIt();
        }

        private void OnEnable() => baseSoVariable.OnValueChange += InvokeIt;

        private void OnDisable() => baseSoVariable.OnValueChange -= InvokeIt;

        [Button] [PropertySpace(10)]
        void InvokeIt()
        {
            whatToInvoke.Invoke();
            if(whatToExecute != null) whatToExecute.Execute();
        }

        public void Execute()
        {
            InvokeIt();
        }
    }
}