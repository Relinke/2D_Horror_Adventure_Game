using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Common
{
    public abstract class CSingleton<T> where T : CSingleton<T>
    {
		protected static T s_instance;
        protected CSingleton(){}

        public static T Instance(){
            if(s_instance == null){
                ConstructorInfo[] ctors = 
                typeof(T).GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);
                ConstructorInfo ctor = Array.Find(ctors, c => c.GetParameters().Length == 0);
                if (ctor == null){
                    Debug.LogError("Canot find non-public constructor in " + typeof(T) + "!");
                }
                s_instance = ctor.Invoke(null) as T;
            }
            return s_instance;
        }
    }
}