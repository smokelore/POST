using UnityEngine;
using System.Collections;

public class ParamKontrol_Range : ParamKontrol
{
    public FloatRange FloatRange;

    public override object GetParameterValue()
    {
        return Mathf.Lerp(FloatRange.Min, FloatRange.Max, GetMidiValue());
    }
}
