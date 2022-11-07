using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LORViewer : Menu
{

    [SerializeField] private TextMeshProUGUI _titel;
    [SerializeField] private TextMeshProUGUI _text;
    public static Action<Narration> OnStartLORViewer;
    public static Action OnCloseLORViewer;

    private void OnEnable()
    {

        OnStartLORViewer += ConfigurationLor;
        OnCloseLORViewer +=  Close;
    }

    private void OnDisable()
    {
        OnStartLORViewer -= ConfigurationLor;
        OnCloseLORViewer -=  Close;
        
    }

    private void ConfigurationLor(Narration CurrentNarration)
    {
        Open();
        
        ClearLor();
        _titel.text = CurrentNarration.Titel;
        _text.text = CurrentNarration.Narrations;
    }

    private void ClearLor()
    {
        _titel.text = String.Empty;
        _text.text = String.Empty;
    }

    public void CloseNarration()
    {
        Close();
    }
    
}
