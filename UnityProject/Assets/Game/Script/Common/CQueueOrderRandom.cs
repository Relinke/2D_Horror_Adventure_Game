using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 移动的队列, 当队列的元素移动超过边界后, 会移动到队列的末尾
/// 移动到末尾后, 位置会随机变化
/// </summary>
namespace Common
{
    public class CQueueOrderRandom : CQueueOrder
    {
        [Header("Random Setting")]
        public Vector2 MaxScale;
        public Vector2 MinScale;
        public float MaxY;
        public float MinY;

        protected override void DequeueCrossOrder(SpriteRenderer SR)
        {
            base.DequeueCrossOrder(SR);
            RandomSizeAndPosition(SR);
            ResetPosition(SR);
        }

        protected virtual void RandomSizeAndPosition(SpriteRenderer SR)
        {
            SR.transform.localScale = new Vector2(Random.Range(MinScale.x, MaxScale.x), Random.Range(MinScale.y, MaxScale.y));
            SR.transform.localPosition = new Vector2(SR.transform.localPosition.x, Random.Range(MinY, MaxY));
        }

        protected virtual void ResetPosition(SpriteRenderer SR)
        {
            switch (MoveDirection)
            {
                case EDirection.LEFT:
                    SR.transform.position = new Vector2(RightBorder, SR.transform.position.y);
                    break;
                case EDirection.RIGHT:
                    SR.transform.position = new Vector2(LeftBorder, SR.transform.position.y);
                    break;
            }
        }
    }
}