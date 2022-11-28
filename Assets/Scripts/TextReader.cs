using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public class TextReader : MonoBehaviour
{
    static string splite_read = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string splite_read_line = @"\r\n|\n\r|\n|\r";

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
                if (values[j] != String.Empty)
                {
                    text.Add(values[j]);
                }
            }
        }
    }

    /// <summary>
    /// sentences in TextData file
    /// 0 ~ 3 == correct sentence
    /// 4 ~ 7 == incorrect sentence
    /// </summary>
    /// <param name="index"> 가져올 text line의 index값 </param>
    /// <returns> 해당 index에 적힌 문구를 string으로 리턴한다 </returns>

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
            case 6:
                t = text[6];
                break;
            case 7:
                t = text[7];
                break;
            default:
                t = "none";
                break;
        }

        return t;
    }

}
