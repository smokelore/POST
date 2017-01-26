using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MidiJack;

public enum MIDIKONTROL
{
    UNUSED_0,   // 0
    UNUSED_1,

    KNOB_1,
    KNOB_2,
    KNOB_3,
    KNOB_4,     // 5

    SLIDER_1,
    SLIDER_2,
    SLIDER_3,
    SLIDER_4,

    PAD_11,     // 10
    PAD_12,
    PAD_13,
    PAD_14,
    PAD_21,
    PAD_22,     // 15
    PAD_23,
    PAD_24,
    PAD_31,
    PAD_32,
    PAD_33,     // 20
    PAD_34,
    PAD_41,
    PAD_42,
    PAD_43,
    PAD_44,     // 25

    UNUSED_2,
    UNUSED_3,
    UNUSED_4,
    UNUSED_5,
    UNUSED_6,   // 30
    UNUSED_7,
    UNUSED_8,
    UNUSED_9,
    UNUSED_10,
    UNUSED_11,   // 35
    UNUSED_12,

    CHANNEL_1,
    CHANNEL_2,
    CHANNEL_3,
    CHANNEL_4,  // 40

    DECODER_TURN,
    DECODER_PRESS,

    MAX,
}

namespace MidiJack
{
    public static class MidiKontrol
    {
        //// Debug
        //public MIDIKONTROL      DebugKontrol;
        //private float           DebugKontrolValue;

        //private Dictionary<MIDIKONTROL, float> Channels;

        //void Start()
        //{
        //    Channels = new Dictionary<MIDIKONTROL, float>();
        //}

        public static MIDIKONTROL Shift(MIDIKONTROL shiftedInput)
        {
            if (shiftedInput < MIDIKONTROL.CHANNEL_1)
            {
                return shiftedInput + 41;
            }
            else
            {
                return shiftedInput + 37;
            }
        }

        public static float GetKontrolValue(MIDIKONTROL input, bool bShifted = false)
        {
            //if (Channels.ContainsKey(input))
            //{
            //    return Channels[input];
            //}
            //else
            //{
            //    return 0f;
            //}

            if (bShifted)
            {
                input = Shift(input);
            }

            return MidiMaster.GetKnob((int)input);
        }

        //void Update ()
        //{
        //    UpdateAllChannels();
        //    UpdateDebug();
        //}

        //void UpdateAllChannels()
        //{
        //    var knobs = MidiMaster.GetKnobNumbers();

        //    for (int i = 0; i < knobs.Length; i++)
        //    {
        //        if (!Channels.ContainsKey((MIDIKONTROL) knobs[i]))
        //        {
        //            Channels.Add((MIDIKONTROL) knobs[i], 0);
        //        }

        //        Channels[(MIDIKONTROL) knobs[i]] = MidiMaster.GetKnob(knobs[i]);
        //    }
        //}

        //void UpdateDebug()
        //{
        //    if (DebugKontrolValue != GetKontrolValue(DebugKontrol))
        //    {
        //        DebugKontrolValue = GetKontrolValue(DebugKontrol);
        //        Debug.Log(DebugKontrolValue);
        //    }
        //}
    }
}