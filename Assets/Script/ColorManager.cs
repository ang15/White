using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorManager : MonoBehaviour
{
    public List<Sprite>Ñolors;
    public static ColorManager instanse;
    public int ÑolorCount => Ñolors.Count;
    
    public void Awake()
    {
        instanse = this;
    }

}
