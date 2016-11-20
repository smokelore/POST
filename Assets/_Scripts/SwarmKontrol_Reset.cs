using UnityEngine;
using System.Collections;

public class SwarmKontrol_Reset : MonoBehaviour
{
    public MIDIKONTROL KontrolInput;
    public bool KontrolInputShifted;

    public void Update()
    {
        if (MidiJack.MidiKontrol.GetKontrolValue(KontrolInput, KontrolInputShifted) > 0.5f)
        {
            this.GetComponent<Kvant.Swarm>().Restart();
        }
    }
}
