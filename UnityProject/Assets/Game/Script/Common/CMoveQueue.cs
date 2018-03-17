using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 移动的队列
/// </summary>
namespace Common
{
    public abstract class CMoveQueue : MonoBehaviour
    {
        public enum EDirection
        {
            LEFT,
            RIGHT
        }

        public EDirection MoveDirection;
        public float LeftBorderX;
        public float RightBorderX;

        public float MoveSpeed;

        protected Queue<SpriteRenderer> ObjectQueue = new Queue<SpriteRenderer>();

        protected virtual void Awake()
        {
            InitChild();
        }

        // 初始化队列列表
        protected virtual void InitChild()
        {
            int ChildCound = transform.childCount;
            List<SpriteRenderer> QueueList = new List<SpriteRenderer>();
            for (int i = 0; i < ChildCound; ++i)
            {
                Transform child = transform.GetChild(i);
                if (child.GetComponent<SpriteRenderer>())
                {
                    QueueList.Add(child.GetComponent<SpriteRenderer>());
                }
            }
            OrderQueue(QueueList);
        }

        protected void OrderQueue(List<SpriteRenderer> QueueList)
        {
            for (int i = 0; i < QueueList.Count - 1; ++i)
            {
                float Min = QueueList[i].transform.position.x;
                int Index = i;
                for (int j = Index + 1; j < QueueList.Count; ++j)
                {
                    if (QueueList[j].transform.position.x < Min)
                    {
                        Min = QueueList[j].transform.position.x;
                        Index = j;
                    }
                }
                if (Index != i)
                {
                    SpriteRenderer SR = QueueList[i];
                    QueueList[i] = QueueList[Index];
                    QueueList[Index] = SR;
                }
            }

            switch (MoveDirection)
            {
                case EDirection.LEFT:
                    for (int i = 0; i < QueueList.Count; ++i)
                    {
                        ObjectQueue.Enqueue(QueueList[i]);
                    }
                    break;
                case EDirection.RIGHT:
                    for (int i = QueueList.Count - 1; i >= 0; --i)
                    {
                        ObjectQueue.Enqueue(QueueList[i]);
                    }
                    break;
            }
        }

        protected virtual void FixedUpdate()
        {
            MoveQueue();
            CheckQueue();
        }

        protected virtual void MoveQueue()
        {
            int MoveDir = 0;
            switch (MoveDirection)
            {
                case EDirection.LEFT:
                    MoveDir = -1;
                    break;
                case EDirection.RIGHT:
                    MoveDir = 1;
                    break;
            }
            Vector3 MoveDelta = Vector2.right * MoveSpeed * Time.deltaTime * MoveDir;
            transform.position = transform.position + MoveDelta;
        }

        protected abstract void CheckQueue();
    }
}