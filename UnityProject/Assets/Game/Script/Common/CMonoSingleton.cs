using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
    public abstract class CMonoSingleton<T> : MonoBehaviour where T : CMonoSingleton<T>
    {
        protected static T s_instance = null;

        protected CMonoSingleton() { }

        public static T Instance()
        {
            if (s_instance == null)
            {
                s_instance = FindObjectOfType<T>();
                if (FindObjectsOfType<T>().Length > 0)
                {
                    Debug.LogError("There are more than 1 " + typeof(T) + "!");
                    T[] typeObjects = FindObjectsOfType<T>();
                    for (int i = typeObjects.Length - 1; i >= 0; --i)
                    {
                        if (s_instance != typeObjects[i])
                        {
                            Destroy(typeObjects[i]);
                        }
                    }
                }
                if (s_instance == null)
                {
                    GameObject targetObject = new GameObject();
                    targetObject.name = typeof(T).ToString();
                    DontDestroyOnLoad(targetObject);
                    s_instance = targetObject.AddComponent<T>();
                }
            }
            return s_instance;
        }

        protected void OnDestroy()
        {
            s_instance = null;
        }
    }
}