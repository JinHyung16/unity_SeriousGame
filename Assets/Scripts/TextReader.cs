using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class TextReader : MonoBehaviour
{
    static string splite_read = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string splite_read_line = @"\r\n|\n\r|\n|\r";
    // static char[] TRIM_CHARS = { '\"' };

    [SerializeField] private List<string> text;

    private void Start()
    {
        text = new List<string>();
        TextRead();
    }

    private void TextRead()
    {
        TextAsset textData = Resources.Load("TextData") as TextAsset;
        var lines = Regex.Split(textData.text, splite_read_line);

        for (int i = 0; i < lines.Length; i++)
        {
            var values = Regex.Split(lines[i], splite_read);

            for (int j = 0; j < values.Length; j++)
            {
                //string value = values[j];
                //value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                if(values[j] != String.Empty)
                {
                    text.Add(values[j]);
                }
            }
        }
    }

    public string TextReturn(int index)
    {
        string t = string.Empty;

        switch(index)
        {
            case 0:
                t = text[0];
                break;
            case 1:
                t = text[1];
                break;
            case 2:
                t = text[2];
                break;
            case 3:
                t = text[3];
                break;
            case 4:
                t = text[4];
                break;
            case 5:
                t = text[5];
                break;
            default:
                t = "none";
                break;
        }

        return t;
    }

}
