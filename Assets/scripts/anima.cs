using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class anima : MonoBehaviour
{

    public float _Speed = 1f;
    public int _FrameRate = 30;
    public bool _Loop = false;
    private Image mImage = null;

    private Sprite[] mSprites = null;
    private float mTimePerFrame = 0f;
    private float mElapsedTime = 0f;
    private int mCurrentFrame = 0;

    void Start()
    {
        mImage = GetComponent<Image>();
        enabled = false;
        LoadSpriteSheet();    
    }

    private void LoadSpriteSheet()

    {
        mSprites = Resources.LoadAll<Sprite>("Gif");
        if (mSprites != null && mSprites.Length > 0)
        {
            mTimePerFrame = 1f / _FrameRate;
            Play();
        }    
        else 
            Debug.LogError("Failed to load sprite sheet");        
}

public void Play()

{
    enabled = true;

}

void Updated()

{
    mElapsedTime += Time.deltaTime * _Speed;
    if(mElapsedTime >= mTimePerFrame)

    {
        mElapsedTime = 0f;
        ++mCurrentFrame;
        SetSprite();
        if(mCurrentFrame >= mSprites.Length)
        {
            if (_Loop)
                mCurrentFrame = 0;

            else 
                enabled = false;
        }
    }
}

private void SetSprite()
    {
        if(mCurrentFrame >= 0 && mCurrentFrame < mSprites.Length)
            mImage.sprite = mSprites[mCurrentFrame];    
    }

}