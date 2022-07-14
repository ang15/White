
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blocks : MonoBehaviour
{
    public bool OnClick = true;
    [SerializeField]
    public Block[,] pozitionBlock;
    public int amountX;
    public int amountY;
    [SerializeField]
    private Text monetsText;
    public int monets = 0;
    [SerializeField]
    private Text movesText;
    public int moves = 31;
    [SerializeField]
    private GameObject won;

    void Start()
    {
        int i = 1;
        pozitionBlock = new Block[amountX, amountY];
         for (int y = 0; y < amountY; y++)
            {
            for (int x = 0; x < amountX; x++)
            {
          
                pozitionBlock[x, y] = transform.GetChild(i).gameObject.GetComponent<Block>();
                i++;
                pozitionBlock[x, y].x = x;
                pozitionBlock[x, y].y = y;
            }
        }
        moves = 40;
        monets = 0;
    }
    

    void Update()
    {
        movesText.text = "" + moves;
        monetsText.text = "" + monets;
        if (PlayerPrefs.HasKey("Monets"))
        {
            if (PlayerPrefs.GetInt("Monets") < monets)
            {
                PlayerPrefs.SetInt("Monets", monets);
            }

        }
        else if (PlayerPrefs.HasKey("Monets") == false)
        {
            PlayerPrefs.SetInt("Monets", monets);
        }


    }


    void FixedUpdate()
    {
        if (moves > 0)
        {
            DownBlocks();
        }
        else
        {
            won.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    private void DownBlocks()
    {
        if (OnClick == true)
        {  
            OnClick = false;
            int zX;
        int zY;
        for (int i = 0; i < amountX; i++)
        {
            for (int j = 0; j < amountY - 2; j++)
            {
                zX = 0;
                zY = 0;
                if (pozitionBlock[i, j].numberColor == pozitionBlock[i, j + 1].numberColor
                    && pozitionBlock[i, j].numberColor == pozitionBlock[i, j + 2].numberColor
                    && pozitionBlock[i, j].numberColor != 5)
                {
                    zY = Y(i, j + 2);
                    if (zY >= 0)
                    {
                        MoveY(i, j, zY + 2);
                    }
                }

            }
        }

        for (int j = 0; j < amountY; j++)
        {
            for (int i = 0; i < amountX - 2; i++)
            {
                zX = 0;
                zY = 0;

                if (pozitionBlock[i, j].numberColor == pozitionBlock[i + 1, j].numberColor
                    && pozitionBlock[i, j].numberColor == pozitionBlock[i + 2, j].numberColor
                    && pozitionBlock[i, j].numberColor != 5)
                {
                    zX = X(i + 2, j);

                    if (zX >= 0)
                    {
                        MoveX(i, j, zX + 2);

                    }
                }
            }
        }

         

            for (int m = 0; m < amountY; m++)
            {
                for (int l = 0; l < amountX ; l++)
                {
                    if (pozitionBlock[l, m].Active == true) { 
                        for (int i = 0; i < amountX; i++)
                        {

                            for (int j = amountY - 1; j >= 0; j--)
                            {
                                if (pozitionBlock[i, j].Active == true)
                                {
                                    for (int z = j; z > 0; z--)
                                    {
                                        Debug.Log(i + " i " + z + " z");
                                        pozitionBlock[i, z].numberColor = pozitionBlock[i, z - 1].numberColor;
                                        pozitionBlock[i, z].Active = pozitionBlock[i, z - 1].Active;

                                    }
                                    Debug.Log(i + " I " + 0);
                                    pozitionBlock[i, 0].SetNewCollor();
                                    pozitionBlock[i, 0].Active = false;
                                   
                                }
                            }

                        }
                    }
                }
            }
            OnClick = true;
        }
    }


  private void MoveX(int x, int y, int z)
    {
        for (int k = z; k >=0; k--)
        {
            pozitionBlock[x+ k, y ].Active = true;
         //   Debug.Log("i "+(x+k)+" j "+y );
        }
    }

    private void MoveY(int x, int y, int z )
    {
        for (int k = z ; k >= 0; k--)
        {
            pozitionBlock[x, y + k].Active = true;
          //  Debug.Log("i " + x  + " j " + (y+ k));
        }
    }
    private int X(int x, int y)
    {
        int kolX = 0;
        for (int z = x+1; z < amountX; z++)
        {
            if (pozitionBlock[x, y].numberColor == pozitionBlock[z, y].numberColor)
                
            {
                kolX++;
            }
            else
            {
                return kolX;
            }

        }
        return kolX;
    }
    private int Y(int x, int y)
    {
        int kolY = 0;
        for (int z = y+1; z < amountY; z++)
        {
            if (pozitionBlock[x, y].numberColor == pozitionBlock[x, z].numberColor)
            {
                kolY++;
            }
            else
            {
                return kolY;
            }

        }
        return kolY;
    }

   
}
