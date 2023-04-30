using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Trigger/Trigger_OnEnableAndDisable")]
    public class Trigger_OnEnableAndDisable : SerializedMonoBehaviour
    {
        [Space(10)] [SerializeField] private bool isActive = true;

        [Space(10)] [EnableIf("isActive")] [SerializeField]
        private bool shouldInvokeOnEnable = false;

        [Space(10)] [ShowIf("shouldInvokeOnEnable")] [EnableIf("shouldInvokeOnEnable")] [SerializeField]
        private UnityEvent whatToInvokeOnEnable;

        [Space(10)] [ShowIf("shouldInvokeOnEnable")] [EnableIf("shouldInvokeOnEnable")] [SerializeField]
        private IExecutable whatToExecuteOnEnable;

        [Space(10)] [EnableIf("isActive")] [SerializeField]
        private bool shouldInvokeOnDisable = false;

        [Space(10)] [ShowIf("shouldInvokeOnDisable")] [EnableIf("shouldInvokeOnDisable")] [SerializeField]
        private UnityEvent whatToInvokeOnDisable;

        [Space(10)] [ShowIf("shouldInvokeOnDisable")] [EnableIf("shouldInvokeOnDisable")] [SerializeField]
        private IExecutable whatToExecuteOnDisable;


        private void OnEnable()
        {
            if (isActive && shouldInvokeOnEnable)
            {
                whatToInvokeOnEnable.Invoke();
                if (whatToExecuteOnEnable != null) whatToExecuteOnEnable.Execute();
            }
        }

        private void OnDisable()
        {
            if (isActive && shouldInvokeOnDisable)
            {
                whatToInvokeOnDisable.Invoke();
                if (whatToExecuteOnDisable != null) whatToExecuteOnDisable.Execute();
            }
        }
    }
}