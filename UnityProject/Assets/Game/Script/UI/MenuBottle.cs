using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Bottle in main menu
/// </summary>
public class MenuBottle : MonoBehaviour
{
    [SerializeField]
    private Animator _PaperMenuAnimator;
    [SerializeField]
    private string _PaperAppearAnimName;
    private void OnMouseDown()
    {
        _PaperMenuAnimator.Play(_PaperAppearAnimName);
        enabled = false;
    }
}