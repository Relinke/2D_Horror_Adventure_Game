using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Simple moveable background.
/// </summary>
public class CSimpleMoveBG : MonoBehaviour
{
    public enum EMoveDirectionType
    {
        RIGHT,
        LEFT,
        UP,
        DOWN
    }

    public enum EOrderType
    {
        ORDERED,
        DISORDERED
    }
    public EMoveDirectionType MoveDirection;
    public EOrderType OrderType;
    public List<GameObject> MoveableBGList = new List<GameObject>();

    public float MinX;
    public float MaxX;
    public float MinY;
    public float MaxY;

    public float MinScaleX;
    public float MaxScaleX;
    public float MinScaleY;
    public float MaxScaleY;

    public float Speed;
    public float OrderSpace;

    private void Awake()
    {
        InitList();
        InitScale();
    }

    private void InitList(){
        if(MoveableBGList.Count == 0){
            for(int i = 0; i < transform.childCount; ++i){
                MoveableBGList.Add(transform.GetChild(i).gameObject);
            }
        }
    }

    private void InitScale()
    {
        for (int i = 0; i < MoveableBGList.Count; ++i)
        {
            MoveableBGList[i].transform.localScale = GetRandomSize();
        }
    }

    private void Update()
    {
        for (int i = 0; i < MoveableBGList.Count; ++i)
        {
            Vector2 pos = MoveableBGList[i].transform.localPosition;
            switch (MoveDirection)
            {
                case EMoveDirectionType.RIGHT:
                    if (pos.x > MaxX)
                    {
                        ResetSingleBG(MoveableBGList[i]);
                    }
                    else
                    {
                        pos.x += Time.deltaTime * Speed;
                        MoveableBGList[i].transform.localPosition = pos;
                    }
                    break;
                case EMoveDirectionType.LEFT:
                    if (pos.x < MinX)
                    {
                        ResetSingleBG(MoveableBGList[i]);
                    }
                    else
                    {
                        pos.x -= Time.deltaTime * Speed;
                        MoveableBGList[i].transform.localPosition = pos;
                    }
                    break;
                case EMoveDirectionType.UP:
                    if (pos.y > MaxY)
                    {
                        ResetSingleBG(MoveableBGList[i]);
                    }
                    else
                    {
                        pos.y += Time.deltaTime * Speed;
                        MoveableBGList[i].transform.localPosition = pos;
                    }
                    break;
                case EMoveDirectionType.DOWN:
                    if (pos.y > MinY)
                    {
                        ResetSingleBG(MoveableBGList[i]);
                    }
                    else
                    {
                        pos.y -= Time.deltaTime * Speed;
                        MoveableBGList[i].transform.localPosition = pos;
                    }
                    break;
            }

        }
    }

    private Vector3 GetRandomSize()
    {
        Vector3 randomSize = new Vector3(0, 0, 1);
        randomSize.x = Random.Range(MinScaleX, MaxScaleX);
        randomSize.y = Random.Range(MinScaleY, MaxScaleY);
        return randomSize;
    }

    private void ResetSingleBG(GameObject target)
    {
        switch (OrderType)
        {
            case EOrderType.ORDERED:
                ResetOrderedBG(target);
                break;
            case EOrderType.DISORDERED:
                ResetDisorderedBG(target);
                break;
        }
    }

    private void ResetOrderedBG(GameObject target)
    {
        Vector2 pos = GetLastBG().transform.localPosition;
        switch (MoveDirection)
        {
            case EMoveDirectionType.RIGHT:
                pos.x -= OrderSpace;
                target.transform.localPosition = pos;
                target.transform.localScale = GetRandomSize();
                break;
            case EMoveDirectionType.LEFT:
                pos.x += OrderSpace;
                target.transform.localPosition = pos;
                target.transform.localScale = GetRandomSize();
                break;
            case EMoveDirectionType.UP:
                pos.y -= OrderSpace;
                target.transform.localPosition = pos;
                target.transform.localScale = GetRandomSize();
                break;
            case EMoveDirectionType.DOWN:
                pos.y += OrderSpace;
                target.transform.localPosition = pos;
                target.transform.localScale = GetRandomSize();
                break;
        }
    }

    private void ResetDisorderedBG(GameObject target)
    {
        Vector2 pos = target.transform.localPosition;
        switch (MoveDirection)
        {
            case EMoveDirectionType.RIGHT:
                pos = new Vector2(MinX, pos.y);
                target.transform.localPosition = pos;
                target.transform.localScale = GetRandomSize();
                break;
            case EMoveDirectionType.LEFT:
                pos = new Vector2(MaxX, pos.y);
                target.transform.localPosition = pos;
                target.transform.localScale = GetRandomSize();
                break;
            case EMoveDirectionType.UP:
                pos = new Vector2(pos.x, MinY);
                target.transform.localPosition = pos;
                target.transform.localScale = GetRandomSize();
                break;
            case EMoveDirectionType.DOWN:
                pos = new Vector2(pos.x, MaxY);
                target.transform.localPosition = pos;
                target.transform.localScale = GetRandomSize();
                break;
        }
    }

    private GameObject GetLastBG()
    {
        GameObject BG = null;
        if (MoveableBGList.Count == 0)
        {
            return null;
        }
        BG = MoveableBGList[1];
        for (int i = 1; i < MoveableBGList.Count; ++i)
        {
            Vector2 posA = BG.transform.localPosition;
            Vector2 posB = MoveableBGList[i].transform.localPosition;
            switch (MoveDirection)
            {
                case EMoveDirectionType.RIGHT:
                    if (posA.x > posB.x)
                    {
                        BG = MoveableBGList[i];
                    }
                    break;
                case EMoveDirectionType.LEFT:
                    if (posA.x < posB.x)
                    {
                        BG = MoveableBGList[i];
                    }
                    break;
                case EMoveDirectionType.UP:
                    if (posA.y > posB.y)
                    {
                        BG = MoveableBGList[i];
                    }
                    break;
                case EMoveDirectionType.DOWN:
                    if (posA.y < posB.y)
                    {
                        BG = MoveableBGList[i];
                    }
                    break;
            }
        }
        return BG;
    }
}
