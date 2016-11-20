using UnityEngine;
using System.Collections;

public class SwarmKontrol_Color : MonoBehaviour
{
    public int RandomSeedFactor = 1;

    public void Update()
    {
        for (MIDIKONTROL i = MIDIKONTROL.PAD_11; i <= MIDIKONTROL.PAD_44; i++)
        {
            int input = (int) i;
            int shiftInput = (int) MidiJack.MidiKontrol.Shift(i);

            float value = MidiJack.MidiKontrol.GetKontrolValue(i);
            float shiftValue = MidiJack.MidiKontrol.GetKontrolValue(i, true);
            
            if (shiftValue > 0.5f)
            {
                this.GetComponent<Kvant.Swarm>().color2 = Extensions.GetRandomPastelColor(input * RandomSeedFactor);
                break;
            }
            else if (value > 0.5f)
            {
                this.GetComponent<Kvant.Swarm>().color = Extensions.GetRandomPastelColor(input * RandomSeedFactor);
                break;
            }
        }
    }
}
