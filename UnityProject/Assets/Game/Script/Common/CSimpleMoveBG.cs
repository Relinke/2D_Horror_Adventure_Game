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
    public EMoveDirectionType MoveDirection;
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

    private void Awake()
    {
        InitScale();
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
                    pos.x += Time.deltaTime * Speed;
                    MoveableBGList[i].transform.localPosition = pos;
                    break;
                case EMoveDirectionType.LEFT:
                    if (pos.x < MinX)
                    {
                        ResetSingleBG(MoveableBGList[i]);
                    }
                    pos.x -= Time.deltaTime * Speed;
                    MoveableBGList[i].transform.localPosition = pos;
                    break;
                case EMoveDirectionType.UP:
                    if (pos.y > MaxY)
                    {
                        ResetSingleBG(MoveableBGList[i]);
                    }
                    pos.y += Time.deltaTime * Speed;
                    MoveableBGList[i].transform.localPosition = pos;
                    break;
                case EMoveDirectionType.DOWN:
                    if (pos.y > MinY)
                    {
                        ResetSingleBG(MoveableBGList[i]);
                    }
                    pos.y -= Time.deltaTime * Speed;
                    MoveableBGList[i].transform.localPosition = pos;
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
}
