using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOR : MonoBehaviour
{
    [SerializeField]private Narration _narration;
    public void StartLor()
    {
        OnFirstNarrationEnter();
    }
    public void OnFirstNarrationEnter()
    {
        LORViewer.OnStartLORViewer?.Invoke(_narration);
    }
}
