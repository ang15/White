using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{

    public int numberColor = 1;
    public int x;
    public int y;
    public bool Active=false;
    void Start()
    {
        SetNewCollor();
    }

    void OnMouseDown()
    {
        GameManager.instance.OnBlockClick(this);

    }
    private void Update()
    {
        GetComponent<Image>().sprite = ColorManager.instanse.Ñolors[numberColor];
    }
    public void SetNewCollor()
    {
        numberColor = Random.Range(0, ColorManager.instanse.ÑolorCount - 1);
        GetComponent<Image>().sprite= ColorManager.instanse.Ñolors[numberColor];
    }

}
