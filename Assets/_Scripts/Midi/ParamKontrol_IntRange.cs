using UnityEngine;
using System.Collections;

public class ParamKontrol_IntRange : ParamKontrol_Range
{
    public override object GetParameterValue()
    {
        return ((int) Mathf.Lerp(FloatRange.Min, FloatRange.Max, GetMidiValue()));
    }
}
