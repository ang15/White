using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public List<Sprite>�olors;
    public static ColorManager instanse;
    public int �olorCount => �olors.Count;
    
    public void Awake()
    {
        instanse = this;
    }

}
