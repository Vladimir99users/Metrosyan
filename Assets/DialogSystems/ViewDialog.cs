using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class ViewDialog : Menu
{
    [Header("Компоненты для визуального отображения диалога")]
    [SerializeField] private TextMeshProUGUI _dialogTextMeshPro;
    [SerializeField] private Button _prefabsButton;
    [SerializeField] private RectTransform _positionOfResponses;

    public static Action<List<Node>> OnStartConfigurationDialog;
    public static Action OnCloseConfigurationDialog;

    private List<Node> _nodes;
    private int _startIndex = 0;

    private void OnEnable()
    {
        OnStartConfigurationDialog += ConfigurationDialog;
        OnCloseConfigurationDialog +=  Close;
    }

    private void OnDisable()
    {
        OnStartConfigurationDialog -= ConfigurationDialog;
        OnCloseConfigurationDialog -=  Close;
    }
    private void ConfigurationDialog(List<Node> anotherNode)
    {
        if(anotherNode is null) 
        {
            Open();
            _dialogTextMeshPro.text = "none dialog";
            return;
        }
        _nodes = anotherNode;
        Open();
        ViewNodes(_nodes[_startIndex]);
    }


    private void ViewNodes(Node _currentNode)
    {

        DeleteAllChild(_positionOfResponses);
        _dialogTextMeshPro.text = _currentNode.MainText;

        if(_currentNode.Responce.Length != 0)
        {
            for(int i = _currentNode.Responce.Length - 1; i >= 0; i--)
            {
                Button button = Instantiate(_prefabsButton,_positionOfResponses) as Button;
                var passage = _currentNode.Responce[i];
                button.GetComponentInChildren<TextMeshProUGUI>().text = passage.TextChoise;
                Debug.Log("next Node = " + passage.Choise );
                button.onClick.AddListener(delegate { SelectedNode(passage.Choise); });
            }
        }
        else
        {
            var button = Instantiate(_prefabsButton,_positionOfResponses);
            button.GetComponentInChildren<TextMeshProUGUI>().text = "End Dialog";
            button.onClick.AddListener(delegate { Close(); } );
        }
    }

    public void SelectedNode(int index)
    {
        Debug.Log("node = " + index);
        ViewNodes(_nodes[index]);
    }
    private void DeleteAllChild(RectTransform parent)
    {
        UnityEngine.Assertions.Assert.IsNotNull(parent);
        for (int children = parent.childCount - 1; children >= 0; children--)
        {
            Destroy(parent.GetChild(children).gameObject);
        }
    }
}
