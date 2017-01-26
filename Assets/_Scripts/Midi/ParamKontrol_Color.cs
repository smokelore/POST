using UnityEngine;
using System.Collections;

public class ParamKontrol_Color : ParamKontrol
{
    public Color MyColor;

    public override object GetParameterValue()
    {
        return MyColor;
    }
}
