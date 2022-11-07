using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOR : MonoBehaviour
{
    [SerializeField]private LocalizationTextFile<Narration> _narration;
    private bool _isLorRead = false;

    public void StartLor()
    {
        OnFirstNarrationEnter();
    }

    private void OnFirstNarrationEnter()
    {
        _isLorRead = true;
        LORViewer.OnStartLORViewer?.Invoke(_narration.GetText());
    }

    public void EndLor()
    {
        DestroyChest();
    }

    private void DestroyChest()
    {
        if(_isLorRead == true)
        {
            Destroy(gameObject);
        }
    }
}
