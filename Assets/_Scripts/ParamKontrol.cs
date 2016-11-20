using UnityEngine;
using System.Collections;
using System.Reflection;

public class ParamKontrol : MonoBehaviour
{
    public Component KontrolComponent;

    public MIDIKONTROL  KontrolInput;
    public bool         KontrolInputShifted;

    public string       KontrolParameterName;

    public float GetMidiValue()
    {
        return MidiJack.MidiKontrol.GetKontrolValue(KontrolInput, KontrolInputShifted);
    }

    public virtual object GetParameterValue()
    {
        return GetMidiValue();
    }

    public void SetParameterValue()
    {
        if (KontrolComponent != null && KontrolParameterName != "")
        {
            System.Type fType = KontrolComponent.GetType();
            FieldInfo fInfo = fType.GetField(KontrolParameterName, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            fInfo.SetValue(KontrolComponent, GetParameterValue());
            
        }
    }
    	
	public void Update ()
    {
        SetParameterValue();
    }
}
