using UnityEngine;
using System.Collections;

public class ParamKontrol_Bool : ParamKontrol
{
    public override object GetParameterValue()
    {
        return (GetMidiValue() > 0.5 ? true : false);
    }
}
