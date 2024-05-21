using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorMangaer 
{
    public static Color StringToColor(string coloreStringa)
    {

        coloreStringa = coloreStringa.ToLower();


        switch (coloreStringa)
        {
            case "red":
                return Color.red;
            case "green":
                return Color.green;
            case "blue":
                return Color.blue;
            case "yellow":
                return Color.yellow;
            case "cyan":
                return Color.cyan;
            case "magenta":
                return Color.magenta;
            case "white":
                return Color.white;
            case "black":
                return Color.black;
            case "gray":
                return Color.gray;
            default:
                return Color.clear;
        }
    }


    public static Color StringCodeToColor(string coloreCodice)
    {

        string codice = coloreCodice.Substring(0, 1);


        switch (codice)
        {
            case "01":
                return Color.red;
            case "02":
                return Color.green;
            case "03":
                return Color.blue;
            case "04":
                return Color.yellow;
            case "05":
                return Color.cyan;
            case "06":
                return Color.magenta;
            case "07":
                return Color.white;
            case "08":
                return Color.black;
            case "09":
                return Color.gray;
            default:

                return Color.clear;
        }
    }

    public static int Color_EnumTOIDMaterial(string colore)
    {
        switch (colore)
        {
            case "red":
                return 1; 
            case "green":
                return 2;
            case "blue":
                return 3;
            case "yellow":
                return 4;
            case "cyan":
                return 5;
            case "magenta":
                return 6;
            case "white":
                return 7;
            case "black":
                return 8;
            case "gray":
                return 9;
            default:
                return 0;
        }
    }
}
