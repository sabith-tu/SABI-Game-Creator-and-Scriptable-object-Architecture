using SABI.SOA;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace SABI.Invoke
{
    [AddComponentMenu("_SABI/Action/Comparison/Action_ComparisonOnInt")]
    public class Action_ComparisonOnInt : SerializedMonoBehaviour, IExecutable
    {
        [Space(10)] [SerializeField] private IntReference[] intValues;
        [Space(10)] [SerializeField] bool debugLog = false;
        [Space(10)] [SerializeField] UnityEvent InvokeOnTheyAreSame;
        [Space(10)] [SerializeField] IExecutable OnTheyAreSameExecutable;

        [PropertySpace(SpaceAfter = 10)] [SerializeField]
        UnityEvent InvokeOnTheyAreDifferent;

        [PropertySpace(SpaceAfter = 10)] [SerializeField]
        IExecutable OnTheyAreDifferentExecutable;

        [Button]
        public void RunComparison()
        {
            if (intValues.Length <= 1)
            {
                Debug.LogError("Need more than 1 value to compare on gameObject " + gameObject.name);
                return;
            }

            if (IsAllValuesSame()) SameValue();
            else NotSameValue();
        }

        bool IsAllValuesSame()
        {
            float firstValue = intValues[0].GetValue();

            foreach (var VARIABLE in intValues)
            {
                if (VARIABLE.GetValue() != firstValue)
                {
                    Debug.Log("missmatch found");
                    return false;
                }
            }

            Debug.Log("no missmatch found");
            return true;
        }

        void SameValue()
        {
            InvokeOnTheyAreSame.Invoke();
            if (OnTheyAreSameExecutable != null) OnTheyAreSameExecutable.Execute();
            if (debugLog) Debug.Log("They are same");
        }

        void NotSameValue()
        {
            InvokeOnTheyAreDifferent.Invoke();
            if (OnTheyAreDifferentExecutable != null) OnTheyAreDifferentExecutable.Execute();
            if (debugLog) Debug.Log("They are diffrent");
        }

        public void Execute()
        {
            RunComparison();
        }
    }
}