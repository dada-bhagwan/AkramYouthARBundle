using System;
using System.Collections.Generic;
[Serializable]
public class MagazineList
{
    public Magazine[] data;
}
[Serializable]
public class Magazine
{
    public double index;
    public string name;
    public double size;
    public string url;
    public string fileName {

        get {
            return name.Replace(" ", "_") + ".dlc";
        }
    }

}