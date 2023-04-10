using System.Collections;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(RangedFloat), true)]
public class RangedFloatDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        label = EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, label);

        SerializedProperty minProp = property.FindPropertyRelative("minValue");
        SerializedProperty maxProp = property.FindPropertyRelative("maxValue");

        float minValue = minProp.floatValue;
        float maxValue = maxProp.floatValue;

        float rangeMin = 0;
        float rangeMax = 1;

        var ranges = (MinMaxRangeAttribute[])fieldInfo.GetCustomAttributes(typeof(MinMaxRangeAttribute), true);
        if (ranges.Length > 0)
        {
            rangeMin = ranges[0].Min;
            rangeMax = ranges[0].Max;
        }

        const float rangeBoundLableWidth = 80f;

        var rangeBoundLable1Rect = new Rect(position);
        rangeBoundLable1Rect.width = rangeBoundLableWidth;
        GUI.Label(rangeBoundLable1Rect, new GUIContent(minValue.ToString("F2")));
        position.xMin += rangeBoundLableWidth;

        var rangeBoundLable2Rect = new Rect(position);
        rangeBoundLable2Rect.width = rangeBoundLableWidth;
        GUI.Label(rangeBoundLable2Rect, new GUIContent(maxValue.ToString("F2")));
        position.xMax += rangeBoundLableWidth;

        EditorGUI.BeginChangeCheck();
        EditorGUI.MinMaxSlider(position, ref minValue, ref maxValue, rangeMin, rangeMax);
        if (EditorGUI.EndChangeCheck())
        {
            minProp.floatValue = minValue;
            maxProp.floatValue = maxValue;
        }

        EditorGUI.EndProperty();
    }
}
