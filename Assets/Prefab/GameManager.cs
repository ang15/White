using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private Blocks blocks;
    public Block FirstBlock;
    public Block SecondBlock;
    private void Awake()
    {
        instance = this;
    }

    public void OnBlockClick(Block Block)
    {
        if (blocks.OnClick == true)
        {
            if (FirstBlock == null)
            {
                FirstBlock = Block;
                Block.transform.localScale = new Vector2(Block.transform.localScale.x *0.7f, Block.transform.localScale.y*0.7f);
            }
            else if (FirstBlock != null && SecondBlock == null && FirstBlock != Block)
            {
                blocks.moves -= 1;
                Block.transform.localScale = new Vector2(Block.transform.localScale.x * 0.7f, Block.transform.localScale.y * 0.7f);
                blocks.OnClick = false;
                SecondBlock = Block;
                OnBlock();
            }
        }
    }
    public void OnBlock()
    {
        OnBlockTwo(FirstBlock, SecondBlock);
        OnBlockTwo(SecondBlock, FirstBlock);
        FirstBlock.transform.localScale = new Vector2(FirstBlock.transform.localScale.x / 0.7f, FirstBlock.transform.localScale.y / 0.7f);
        SecondBlock.transform.localScale = new Vector2(SecondBlock.transform.localScale.x / 0.7f, SecondBlock.transform.localScale.y / 0.7f);
        blocks.OnClick = true;
        FirstBlock = null;
        SecondBlock = null;
    }


    public void OnBlockTwo(Block first, Block second)
    {

        if ((second.x ==first.x && second.y ==first.y + 1) || (second.x ==first.x && second.y ==first.y - 1))
        {

            if ((first.x + 2 < blocks.amountX && second.numberColor == blocks.pozitionBlock[first.x + 1,first.y].numberColor
                    && second.numberColor == blocks.pozitionBlock[first.x + 2,first.y].numberColor)
                || (first.x + 1 < blocks.amountX && first.x > 0 && second.numberColor == blocks.pozitionBlock[first.x + 1,first.y].numberColor
                    && second.numberColor == blocks.pozitionBlock[first.x - 1,first.y].numberColor)
                || (first.x - 1 > 0 && second.numberColor == blocks.pozitionBlock[first.x - 1,first.y].numberColor
                    && second.numberColor == blocks.pozitionBlock[first.x - 2,first.y].numberColor)
                    || (first.y > second.y && first.y + 2 < blocks.amountX && second.numberColor == blocks.pozitionBlock[first.x,first.y + 1].numberColor
                    && second.numberColor == blocks.pozitionBlock[first.x,first.y + 2].numberColor)
                    || (first.y < second.y && first.y - 1 > 0 && second.numberColor == blocks.pozitionBlock[first.x,first.y - 1].numberColor
                    && second.numberColor == blocks.pozitionBlock[first.x,first.y - 2].numberColor)
                    )
            { 
                blocks.monets += 200;
                int color =first.numberColor;
               first.numberColor = second.numberColor;
                second.numberColor = color;
               
            

            }
        }
        else
        if ((second.y ==first.y && second.x ==first.x + 1)   || (second.y ==first.y && second.x ==first.x - 1))
        {
            if ((first.y + 2 < blocks.amountY && second.numberColor == blocks.pozitionBlock[first.x,first.y + 1].numberColor
                    && second.numberColor == blocks.pozitionBlock[first.x,first.y + 2].numberColor)
                || (first.y + 1 < blocks.amountY && first.y > 0 && second.numberColor == blocks.pozitionBlock[first.x,first.y + 1].numberColor
                    && second.numberColor == blocks.pozitionBlock[first.x,first.y - 1].numberColor)
                || (first.y - 1 > 0 && second.numberColor == blocks.pozitionBlock[first.x,first.y - 1].numberColor
                    && second.numberColor == blocks.pozitionBlock[first.x,first.y - 2].numberColor)
                      || (first.x > second.x && first.x + 2 < blocks.amountX && second.numberColor == blocks.pozitionBlock[first.x+ 1,first.y ].numberColor
                    && second.numberColor == blocks.pozitionBlock[first.x+ 2,first.y ].numberColor)
                    || (first.x< second.x &&first.x - 1 > 0 && second.numberColor == blocks.pozitionBlock[first.x- 1,first.y ].numberColor
                    && second.numberColor == blocks.pozitionBlock[first.x - 2,first.y].numberColor)
                 )
            { 
                blocks.monets +=400;
                int color =first.numberColor;
               first.numberColor = second.numberColor;
                second.numberColor = color;
              

            }
        }
    }
            
    

 
    }
