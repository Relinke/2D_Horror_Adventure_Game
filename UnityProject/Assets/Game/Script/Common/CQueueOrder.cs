using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 移动的队列, 当队列的元素移动超过边界后, 会移动到队列的末尾
/// 移动到末尾后仍然会整齐地排成一排
/// </summary>
namespace Common
{
    public class CQueueOrder : CMoveQueue
    {
        protected override void CheckQueue()
        {
            if (ObjectQueue.Count != 0)
            {
                SpriteRenderer SR = ObjectQueue.Peek();
                bool HasCrossBorder = false;
                switch (MoveDirection)
                {
                    case EDirection.LEFT:
                        if (SR.transform.position.x <= LeftBorderX)
                        {
                            HasCrossBorder = true;
                        }
                        break;
                    case EDirection.RIGHT:
                        if (SR.transform.position.x >= RightBorderX)
                        {
                            HasCrossBorder = true;
                        }
                        break;
                }
                if (HasCrossBorder)
                {
                    DequeueCrossOrder(SR);
                }
            }
        }

        protected virtual void DequeueCrossOrder(SpriteRenderer SR)
        {
            int MoveDir = 0;
            switch (MoveDirection)
            {
                case EDirection.LEFT:
                    if (SR.transform.position.x <= LeftBorderX)
                    {
                        MoveDir = -1;
                    }
                    break;
                case EDirection.RIGHT:
                    if (SR.transform.position.x >= RightBorderX)
                    {
                        MoveDir = 1;
                    }
                    break;
            }
            float SpriteWidth = SR.sprite.bounds.size.x;
            SpriteWidth *= SR.transform.localScale.x;
            Vector3 PosDelta = new Vector3(1, 0, 0) * SpriteWidth * (ObjectQueue.Count) * (-MoveDir);
            SR.transform.position += PosDelta;
            ObjectQueue.Dequeue();
            ObjectQueue.Enqueue(SR);
        }
    }
}