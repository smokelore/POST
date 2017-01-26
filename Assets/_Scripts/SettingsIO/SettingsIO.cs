using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting
{
    private string Name { get; set; }
}

public class Setting_Int : Setting
{
    private int Value { get; set; }
    public override string ToString()
    {
        return "Int(" + Value + ");";
    }

    public void FromString(string valueString)
    {
        valueString.Remove(valueString.Length - 2, 2);  // remove ");"
        valueString.Remove(0, 4);                       // remove "Int("
        Value = int.Parse(valueString);
    }
}

public class Setting_Float : Setting
{
    private float Value { get; set; }
    public override string ToString()
    {
        return "Float(" + Value + ");";
    }

    public void FromString(string valueString)
    {
        valueString.Remove(valueString.Length - 2, 2);  // remove ");"
        valueString.Remove(0, 6);                       // remove "Float("
        Value = float.Parse(valueString);
    }
}

public class Setting_Color : Setting
{
    private Color Value { get; set; }
    public override string ToString()
    {
        return "Color(" + Value.r + "," + Value.g + "," + Value.b + ");";
    }

    public void FromString(string valueString)
    {
        valueString.Remove(valueString.Length - 2, 2);  // remove ");"
        valueString.Remove(0, 6);                       // remove "Color("
        string[] rgbStrings = valueString.Split(',');
        Color newColor = new Color(float.Parse(rgbStrings[0]), float.Parse(rgbStrings[1]), float.Parse(rgbStrings[2]));
        Value = newColor;
    }
}

public class SettingsIO : MonoBehaviour
{
    private string DirectoryPath;
    private string FileName;
    public string SettingsId;

    public Component Target;

    public List<Setting> Settings;

    private StreamReader reader;
    private StreamWriter writer;

    public bool LoadNow;
    public bool ApplyNow;
    public bool SaveNow;

	void Start ()
    {
        DirectoryPath = "./Settings/";
        FileName = "" + gameObject.name + " " + SettingsId + ".txt";
        //reader = new StreamReader(DirectoryPath);
	}

    public void Save()
    {
        try
        {
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
            }
            writer = new StreamWriter(DirectoryPath + FileName, false);

            var properties = Target.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var property in properties)
            {
                if (property.FieldType == typeof(int) || property.FieldType == typeof(System.Int16) || property.FieldType == typeof(System.Int32))
                {
                    int value = 0;
                    value = (int) property.GetValue(Target);
                    writer.WriteLine("Int(" + value + ");");
                }
                else if (property.FieldType == typeof(float) || property.FieldType == typeof(System.Single) || property.FieldType == typeof(System.Double))
                {
                    float value = 0.0f;
                    value = (float) property.GetValue(value);
                    writer.WriteLine("Float(" + value + ");");
                }
                else if (property.FieldType == typeof(Color))
                {
                    Color value = new Color(0, 0, 0); ;
                    value = (Color) property.GetValue(value);
                    writer.WriteLine("Color(" + value.r + "," + value.g + "," + value.b + ");");
                }
                else
                {
                    Debug.Log("SettingsIO: unrecognized property type");
                }
            }

            writer.Close();
        }
        catch
        {
            Debug.Log("SettingsIO: writing to file failed");
        }
    }
	
	void Update ()
    {
	    if (SaveNow)
        {
            Save();
            SaveNow = false;
        }	
	}
}
