using System;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace SABI.SOA
{
    [System.Serializable]
    public class IntReference : BaseReferenceValue
    {
        [ShowIf("@mode == AllReferenceTypesEnum.Scene_Value")]
        public IntSceneVariable SceneVariable;

        [ShowIf("@mode == AllReferenceTypesEnum.Constant_Value")]
        public int ConstantValue;

        [PropertySpace(SpaceAfter = 10)] [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        public IntValueSO SO_Variable;

        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")] [FoldoutGroup("Create")]
        public string NewVaraibleName;

        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")] [FoldoutGroup("Create")]
        public bool ShouldNotifyChanges;

        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")] [FoldoutGroup("Create")]
        public int DefaultValue;


        [Button]
        [FoldoutGroup("Create")]
        [ShowIf("@mode == AllReferenceTypesEnum.SO_Value")]
        public void CreateAndAssignNewSO()
        {
#if UNITY_EDITOR
            IntValueSO valueSO = ScriptableObject.CreateInstance<IntValueSO>();

            valueSO.name = NewVaraibleName;
            valueSO.SetNotifyOnChange(ShouldNotifyChanges);
            valueSO.SetValue(DefaultValue);

            AssetDatabase.CreateAsset(valueSO, "Assets/_Project/Data/" + "SO_INT_" + valueSO.name + ".asset");

            AssetDatabase.SaveAssets();

            SO_Variable = valueSO;
#endif
        }

        public int GetValue()
        {
            switch (mode)
            {
                case AllReferenceTypesEnum.Constant_Value:
                    return ConstantValue;
                    break;
                case AllReferenceTypesEnum.SO_Value:
                    return SO_Variable.GetValue();
                    break;
                case AllReferenceTypesEnum.Scene_Value:
                    return SceneVariable.GetValue();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SetValue(int newValue)
        {
            if (base.NotifyOnChange) base.OnValueChange?.Invoke();
            switch (mode)
            {
                case AllReferenceTypesEnum.Constant_Value:
                    ConstantValue = newValue;
                    break;
                case AllReferenceTypesEnum.SO_Value:
                    SO_Variable.SetValue(newValue);
                    break;
                case AllReferenceTypesEnum.Scene_Value:
                    SceneVariable.SetValue(newValue);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}