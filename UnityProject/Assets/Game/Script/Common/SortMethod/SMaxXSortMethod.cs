using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Use quicksort to sort GameObject list
/// the GameObject whose x position is the biggest will be the first.
/// </summary>

public class SMaxXSortMethod : SortMethon<GameObject>{
    public override List<GameObject> SortList(List<GameObject> target){

        return target;
    }

    private void Sort(List<GameObject> target, int left, int right){
        if(target.Count <= 1 || left >= right){
            return;
        }
        int i = left;
        int j = right;
        GameObject key = target[left];
        while(i < j){
            while(i < j && key.transform.position.x <= target[j].transform.position.x){
                j--;
            }
            target[i] = target[j];
            while(i < j && key.transform.position.x >= target[i].transform.position.x){
                i++;
            }
            target[j] = target[i];
        }
        target[i] = key;
        Sort(target, left, i - 1);
        Sort(target, i + 1, right);
    }
}