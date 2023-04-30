using System.Collections.Generic;
using SABI.SOA;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Trigger/Trigger_OnActionExecuted")]
    public class Trigger_OnActionExecuted : SerializedMonoBehaviour 
    {
        [Space(10)] [SerializeField] private bool isActive = true;

        [Space(10)] [EnableIf("isActive")] [SerializeField]
        List<ActionReference> actions;

        [Space(10)] [EnableIf("isActive")] [SerializeField]
        private UnityEvent whatToInvoke;
        
        [Space(10)] [EnableIf("isActive")] [SerializeField]
        private IExecutable whatToExecute;

        private void OnEnable()
        {
            foreach (var VARIABLE in actions)
            {
                VARIABLE.SetAction(VARIABLE.GetAction() + InvokeIt);
            }
        }

        private void OnDisable()
        {
            foreach (var VARIABLE in actions)
            {
                VARIABLE.SetAction(VARIABLE.GetAction() - InvokeIt);
            }
        }

        [Button]
        [PropertySpace(10)]
        private void InvokeIt()
        {
            if (isActive)
            {
                whatToInvoke.Invoke();
                if(whatToExecute != null) whatToExecute.Execute();
            }
        }

        
    }
}