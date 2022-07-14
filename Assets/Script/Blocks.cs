
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
    //private bool onGame = false;
    [SerializeField]
    private Text monetsText;
    public int monets = 0;
    [SerializeField]
    private Text movesText;
    public int moves = 31;
    //[SerializeField]
    //private RectTransform rectT;
    //[SerializeField]
    //private float space;
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
   //     DownBlocks();
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

   //     DownBlocks();

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
        //Debug.Log(0);
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
                    //XallY(i, j, zY+3);
                    //Debug.Log(zY + " z");
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
                    //Debug.Log(zX + " z");
                    zX = X(i + 2, j);
                    //  Debug.Log("z " + zX);

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

    //private void XallY(int i, int j, int z)
    //{
    ////    int zX;
    ////    Debug.Log("i " + i + " j " + j + " z " + z);
    ////    for (int k = 0; k < z; k++)
    ////    {
    ////        Debug.Log("i " + i + " j " + j + " z " + z);
    ////        if (pozitionBlock[i, j+k].numberColor == pozitionBlock[i + 1, j + k].numberColor
    ////                       && pozitionBlock[i, j + k].numberColor == pozitionBlock[i + 2, j + k].numberColor
    ////                       && pozitionBlock[i, j + k].numberColor != 5)
    ////        {
    ////            zX = 0;
    ////            zX = X(i + 2, j+k);
    ////            Debug.Log("i " + i + " j " + j +" z "+zX);
    ////            if (zX >= 0)
    ////            {
    ////                MoveX(i, j, zX + 1);
    ////            }
    ////        }
    ////    }
    ////}

    ////private void XallY2(int i, int j, int z)
    ////{
    //    //Debug.Log("i " + i + " j " + j + " z " + z);
    //    for (int k = 0; k < z; k++)
    //    {
    //        Debug.Log("i " + i + " j " + (j+k) + " z " + z);
    //        if (i<amountX-2 &&
    //            pozitionBlock[i, j + k].numberColor == pozitionBlock[i + 1, j + k].numberColor
    //                       && pozitionBlock[i, j + k].numberColor == pozitionBlock[i + 2, j + k].numberColor
    //                       && pozitionBlock[i, j + k].numberColor != 5)
    //        {
    //            Debug.Log(0);
    //            MoveX(i+1, j + k, 1);
    //        }
    //        else
    //        if( i > 0 &&i < amountX && pozitionBlock[i, j + k].numberColor == pozitionBlock[i + 1, j + k].numberColor
    //                       && pozitionBlock[i, j + k].numberColor == pozitionBlock[i - 1, j + k].numberColor
    //                       && pozitionBlock[i, j + k].numberColor != 5)
    //        {
    //            Debug.Log(1);
    //            MoveX(i + 1, j + k, 0);
    //            MoveX(i - 1, j + k, 0);
    //        }
    //        else
    //        if (i > 1&& pozitionBlock[i, j + k].numberColor == pozitionBlock[i - 1, j + k].numberColor
    //                       && pozitionBlock[i, j + k].numberColor == pozitionBlock[i - 2, j + k].numberColor
    //                       && pozitionBlock[i, j + k].numberColor != 5)
    //        {
    //            Debug.Log(2);
    //            MoveX(i -2, j + k, 1);
                
    //        }
    //    }
    //}

  

    //        onGame = false;
    //        for (int i = 0; i < amount - 1; i++)
    //        {
    //            for (int j = 0; j < amount; j++)
    //            {
    //                if ((j + 3 < amount && pozitionBlock[i, j].numberColor == pozitionBlock[i, j + 2].numberColor
    //                    && pozitionBlock[i, j].numberColor == pozitionBlock[i, j + 3].numberColor)
    //                     || (j - 3 >= 0 && pozitionBlock[i, j].numberColor == pozitionBlock[i, j - 2].numberColor
    //                    && pozitionBlock[i, j].numberColor == pozitionBlock[i, j - 3].numberColor)
    //                  )
    //                {
    //                    onGame = true;
    //                    break;
    //                }
    //                if (
    //                    (i + 1 < amount - 1
    //                    &&
    //                      ((j - 1 >= 0 && j + 1 < amount && pozitionBlock[i, j].numberColor == pozitionBlock[i + 1, j + 1].numberColor
    //                  && pozitionBlock[i, j].numberColor == pozitionBlock[i + 1, j - 1].numberColor)
    //                   || (j + 2 < amount && pozitionBlock[i, j].numberColor == pozitionBlock[i + 1, j + 1].numberColor
    //                  && pozitionBlock[i, j].numberColor == pozitionBlock[i + 1, j + 2].numberColor)
    //                  || (j - 2 >= 0 && pozitionBlock[i, j].numberColor == pozitionBlock[i + 1, j - 1].numberColor
    //                  && pozitionBlock[i, j].numberColor == pozitionBlock[i + 1, j - 2].numberColor)
    //                  )
    //                  )
    //                   || (i - 1 >= 0 &&
    //                      ((j - 1 >= 0 && j + 1 < amount && pozitionBlock[i, j].numberColor == pozitionBlock[i - 1, j + 1].numberColor
    //                   && pozitionBlock[i, j].numberColor == pozitionBlock[i - 1, j - 1].numberColor)
    //                    || (j + 2 < amount && pozitionBlock[i, j].numberColor == pozitionBlock[i - 1, j + 1].numberColor
    //                   && pozitionBlock[i, j].numberColor == pozitionBlock[i - 1, j + 2].numberColor)
    //                   || (j - 2 >= 0 && pozitionBlock[i, j].numberColor == pozitionBlock[i - 1, j - 1].numberColor
    //                   && pozitionBlock[i, j].numberColor == pozitionBlock[i - 1, j - 2].numberColor)))
    //                   )
    //                {
    //                    onGame = true;

    //                    break;
    //                }


    //                if ((i + 3 < amount - 1 && pozitionBlock[i, j].numberColor == pozitionBlock[i + 2, j].numberColor
    //                               && pozitionBlock[i, j].numberColor == pozitionBlock[i + 3, j].numberColor)
    //                                || (i - 3 >= 0 && pozitionBlock[i, j].numberColor == pozitionBlock[i - 2, j].numberColor
    //                               && pozitionBlock[i, j].numberColor == pozitionBlock[i - 3, j].numberColor)
    //                               )
    //                {
    //                    onGame = true;
    //                    break;

    //                }
    //                if ((j + 1 < amount &&
    //                      ((i - 1 >= 0 && i + 1 < amount - 1 && pozitionBlock[i, j].numberColor == pozitionBlock[i + 1, j + 1].numberColor
    //                  && pozitionBlock[i, j].numberColor == pozitionBlock[i - 1, j + 1].numberColor)
    //                   || (i + 2 < amount - 1 && pozitionBlock[i, j].numberColor == pozitionBlock[i + 1, j + 1].numberColor
    //                  && pozitionBlock[i, j].numberColor == pozitionBlock[i + 2, j + 1].numberColor)
    //                  || (i - 2 >= 0 && pozitionBlock[i, j].numberColor == pozitionBlock[i - 1, j + 1].numberColor
    //                  && pozitionBlock[i, j].numberColor == pozitionBlock[i - 2, j + 1].numberColor))
    //                  )

    //                  || (j - 1 >= 0 &&
    //                    ((i - 1 >= 0 && i + 1 < amount - 1 && pozitionBlock[i, j].numberColor == pozitionBlock[i + 1, j - 1].numberColor
    //                  && pozitionBlock[i, j].numberColor == pozitionBlock[i - 1, j - 1].numberColor)
    //                   || (i + 2 < amount - 1 && pozitionBlock[i, j].numberColor == pozitionBlock[i + 1, j - 1].numberColor
    //                  && pozitionBlock[i, j].numberColor == pozitionBlock[i + 2, j - 1].numberColor)
    //                  || (i - 2 >= 0 && pozitionBlock[i, j].numberColor == pozitionBlock[i - 1, j - 1].numberColor
    //                  && pozitionBlock[i, j].numberColor == pozitionBlock[i - 2, j - 1].numberColor))
    //                  )
    //                   )
    //                {
    //                    onGame = true;
    //                    break;
    //                }
    //            }
    //            if (onGame == true)
    //            {
    //                break;
    //            }
    //        }
    //        if (onGame == false)
    //        {
    //            ReplacedColor();
    //        }
    //        if (moves == 0)
    //        {
    //            OnClick = false;
    //            won.SetActive(true);
    //            gameObject.SetActive(false);

    //        }
    //        X();
    //        Y();
    //    }

    //    private void X()
    //    {
    //        if (OnClick == true)
    //        {
    //            for (int i = 0; i < amount - 3; i++)
    //            {
    //                for (int j = 0; j < amount; j++)
    //                {
    //                    MovingH(i, j);
    //                    if (OnClick == false)
    //                    {
    //                        break;
    //                    }
    //                }

    //                if (OnClick == false)
    //                {
    //                    break;
    //                }
    //            }
    //        }
    //}



    //    private void MovingH(int i, int j)
    //    {
    //        if (pozitionBlock[i, j].IsSame(pozitionBlock[i + 1, j]) && pozitionBlock[i + 1, j].IsSame(pozitionBlock[i + 2, j]))
    //        {
    //            MovingStart(i, j);
    //        }

    //    }
    //    private void MovingStart(int startXPosition, int yPositition)
    //    {
    //        OnClick = false;

    //        WhiteH(startXPosition, yPositition);

    //        int first = pozitionBlock[startXPosition, yPositition].numberColor;
    //        for (int z = startXPosition; z < amount - 1; z++)
    //        {
    //            if (first == pozitionBlock[z, yPositition].numberColor)
    //            {

    //                int l = yPositition + 1;
    //                for (int i = yPositition + 1; i < amount; i++)
    //                {
    //                    monets += 1;
    //                    pozitionBlock[z, i - 1].MergeBlock(pozitionBlock[z, i]);
    //                    l = i;

    //                }
    //                bool trueL = false;
    //                for (int j = l; j < amount; j++)
    //                {
    //                    trueL = true;
    //                    pozitionBlock[z, j].SetNewCollor();

    //                }
    //                if (trueL == false)
    //                {

    //                    pozitionBlock[z, amount - 1].SetNewCollor();
    //                }


    //            }
    //            else
    //            {
    //                break;
    //            }
    //        }
    //        OnClick = true;
    //    }
    //    public void WhiteH(int startXPosition, int yPositition)
    //    {

    //        for (int z = startXPosition + 1; z < amount - 1; z++)
    //        {
    //            if (pozitionBlock[startXPosition, yPositition].IsSame(pozitionBlock[z, yPositition]))
    //            {
    //                OnMovingV(pozitionBlock[z, yPositition]);
    //                pozitionBlock[z, yPositition].SetCollor(5);

    //            }
    //            else
    //            {
    //                break;
    //            }
    //        }
    //        OnMovingV(pozitionBlock[startXPosition, yPositition]);
    //        pozitionBlock[startXPosition, yPositition].SetCollor(5);

    //    }


    //    private void Y()
    //    {
    //        if (OnClick == true)
    //        {
    //            bool trueTree = false;
    //            for (int i = 0; i < amount - 1; i++)
    //            {
    //                for (int j = 0; j < amount; j++)
    //                {
    //                    MovingV(i, j, trueTree);
    //                }
    //            }
    //        }
    //    }

    //    private void MovingV(int i, int j, bool trueTree)
    //    {
    //        int k = 0;
    //        for (int v = j + 1; v < amount; v++)
    //        {
    //            if (pozitionBlock[i, j].IsSame(pozitionBlock[i, v]))
    //            {
    //                k++;
    //            }
    //            else
    //            {
    //                if (trueTree == false && k >= 2)
    //                {
    //                    trueTree = true;
    //                    MovingDownV(i, j, k);
    //                    break;
    //                }
    //                else
    //                {
    //                    k = 0;
    //                }
    //            }
    //            if (trueTree != true && k >= 2)
    //            {
    //                trueTree = true;
    //                MovingDownV(i, j, k);

    //            }
    //        }
    //    }

    //    public void WhiteV(int x, int y, int k)
    //    {
    //        for (int l = y; l <= y + k; l++)
    //        {
    //            pozitionBlock[x, l].SetCollor(5);

    //        }
    //    }

    //    private void MovingDownV(int x, int y, int k)
    //    {
    //        OnClick = false;
    //        WhiteV(x, y, k);

    //        int i = y;
    //        for (int l = y + k + 1; l < amount; l++)
    //        {
    //            for (int z = y + k; z >= i; z--)
    //            {
    //                monets += 1;
    //                pozitionBlock[x, z].MergeBlock(pozitionBlock[x, l]);

    //            }
    //            i++;
    //        }

    //        for (int j = i; j < amount; j++)
    //        {
    //            pozitionBlock[x, j].SetNewCollorNew(pozitionBlock[x, j].numberColor);
    //        }
    //        OnClick = true;

    //    }

    //    public bool OnChecked(Block first, Block second, int SecondNumber)
    //    {
    //        if ((first.x == (second.x - 1) && first.y == second.y)
    //            || (first.x == (second.x + 1) && first.y == second.y)
    //            || (first.y == (second.y - 1) && first.x == second.x)
    //           || (first.y == (second.y + 1) && first.x == second.x))
    //        {
    //            if (
    //               (second.y + 1 < amount &&
    //                pozitionBlock[second.x, second.y + 1].numberColor == SecondNumber
    //               && second.y - 1 >= 0 && pozitionBlock[second.x, second.y - 1].numberColor == SecondNumber)
    //               ||
    //               (second.y + 2 < amount && pozitionBlock[second.x, second.y + 1].numberColor == SecondNumber
    //                && pozitionBlock[second.x, second.y + 2].numberColor == SecondNumber)

    //                || (second.y - 2 >= 0 && pozitionBlock[second.x, second.y - 1].numberColor == SecondNumber
    //                && pozitionBlock[second.x, second.y - 2].numberColor == SecondNumber)

    //            || (second.x + 1 < amount - 1 && pozitionBlock[second.x + 1, second.y].numberColor == SecondNumber
    //                && second.x - 1 >= 0 && pozitionBlock[second.x - 1, second.y].numberColor == SecondNumber)

    //                || (second.x + 2 < amount - 1 && pozitionBlock[second.x + 1, second.y].numberColor == SecondNumber
    //                 && pozitionBlock[second.x + 2, second.y].numberColor == SecondNumber)

    //                 || (second.x - 2 >= 0 && pozitionBlock[second.x - 1, second.y].numberColor == SecondNumber
    //                 && pozitionBlock[second.x - 2, second.y].numberColor == SecondNumber))
    //            {
    //                return true;
    //            }
    //        }
    //        return false;

    //    }
    //    private void OnMovingV(Block first)
    //    {
    //        if (first.y + 1 < amount && first.y - 1 >= 0 && first.IsSame(pozitionBlock[first.x, first.y - 1]) && first.IsSame(pozitionBlock[first.x, first.y + 1]))
    //        {
    //            monets += 5;
    //            MovingV(pozitionBlock[first.x, first.y].x, pozitionBlock[first.x, first.y].y - 1, false);
    //        }
    //        else
    //      if (first.y + 2 < amount && first.IsSame(pozitionBlock[first.x, first.y + 1]) && first.IsSame(pozitionBlock[first.x, first.y + 2]))
    //        {
    //            MovingV(pozitionBlock[first.x, first.y].x, pozitionBlock[first.x, first.y].y, false);
    //        }
    //        else
    //       if (first.y - 2 >= 0 && first.IsSame(pozitionBlock[first.x, first.y - 1]) && first.IsSame(pozitionBlock[first.x, first.y - 2]))
    //        {
    //            MovingV(pozitionBlock[first.x, first.y].x, pozitionBlock[first.x, first.y].y - 2, false);
    //        }
    //    }

    private void ReplacedColor()
    {
        for (int i = 0; i < amountX; i++)
        {
            for (int j = 0; j < amountY; j++)
            {
                pozitionBlock[i, j].SetNewCollor();
            }
        }
    }
}
