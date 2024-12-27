using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.OdinInspector;
using DG.Tweening;
using UnityEngine.Events;
//using Animation_Ui;

public class UiCanvas : MonoBehaviour
{
    [SerializeField] private TypeSort typeSort;

    [SerializeField] protected TypeUi typeUi;

    public TypeUi TypeUi => typeUi;

    // tween start
    
    [SerializeField] private bool hasTweenStart;

    //[ShowIf("hasTweenStart")] 
    [SerializeField] protected List<AnimationUI> uiTweensStart;
    
    //[ShowIf("hasTweenStart")] 
    [SerializeField] protected AnimationUI uiTweensStartComplete;
    
    //[ShowIf("hasTweenStart")] 
    [SerializeField] protected UnityEvent eventStartComplete;
    
    // tween stop
    
    [SerializeField] protected bool hasTweenStop;
    
    //[ShowIf("hasTweenStop")] 
    [SerializeField] protected bool isPlayRevert;
    
    //[ShowIf("hasTweenStop")] 
    [SerializeField] protected List<AnimationUI> uiTweensStop;
    
    //[ShowIf("hasTweenStop")] 
    [SerializeField] protected AnimationUI uiTweensStopComplete;
    
    //[ShowIf("hasTweenStop")] 
    [SerializeField] protected UnityEvent eventStopComplete;

    public virtual void Show(bool _isShow)
    {
        if (_isShow)
        {
            gameObject.SetActive(_isShow);

            switch (typeSort)
            {
                case TypeSort.None:
                    break;
                case TypeSort.First:
                    transform.SetAsFirstSibling();
                    break;
                case TypeSort.Last:
                    transform.SetAsLastSibling();
                    break;
            }

            if (hasTweenStart)
            {
                if (uiTweensStart != null)
                {
                    for (int i = 0; i < uiTweensStart.Count; i++)
                    {
                        uiTweensStart[i].Play();
                    }
                }

                if (uiTweensStartComplete != null)
                {
                    uiTweensStartComplete.AddFunctionAtEnd(() => { eventStartComplete?.Invoke();});
                    uiTweensStartComplete.Play();
                }
            }
        }
        else
        {

            if (hasTweenStop)
            {
                if (isPlayRevert)
                {
                    if (uiTweensStart != null)
                    {
                        for (int i = 0; i < uiTweensStart.Count; i++)
                        {
                            uiTweensStart[i].PlayReversed();
                        }
                    }

                    if (uiTweensStartComplete != null)
                    {
                        uiTweensStartComplete.AddFunctionAtEnd(() =>
                        {
                            eventStopComplete?.Invoke();
                            gameObject.SetActive(_isShow);
                        }).Play();
                        //uiTweensStartComplete.PlayReversed();
                    }
                }
                else
                {
                    if (uiTweensStop != null)
                    {
                        for (int i = 0; i < uiTweensStop.Count; i++)
                        {
                            uiTweensStop[i].Play();
                        }
                    }

                    if (uiTweensStopComplete != null)
                    {
                        uiTweensStopComplete.AddFunctionAt(uiTweensStartComplete.TotalDuration, () =>
                        {
                            eventStopComplete?.Invoke();
                            gameObject.SetActive(_isShow);
                        });
                        uiTweensStopComplete.Play();


                    }
                }
            }
            else
            {
                gameObject.SetActive(_isShow);
            }
        }
    }
}

public enum TypeUi
{
    InstanWhenStart,
    Popup
}

public enum TypeSort
{
    None,
    First,
    Last
}

public enum TypeMoveUi
{
    X,
    Y,
    XY
}