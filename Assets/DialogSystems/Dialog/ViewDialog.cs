using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using DialogSystem.Item;

public class ViewDialog : Menu
{
    [Header("Компоненты для визуального отображения диалога")]
    [SerializeField] private TextMeshProUGUI _dialogTextMeshPro;
    [SerializeField] private Button _prefabsButton;
    [SerializeField] private RectTransform _positionOfResponses;

    public static Action<Conversation> OnStartConfigurationDialog;
    public static Action OnCloseConfigurationDialog;

    private Dictionary<string,Node> _selectedPart;
    private Node _nextNode;
    private readonly int STARTINDEX = 0;

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
    private void ConfigurationDialog(Conversation anotherNode)
    {
        if(anotherNode is null) 
        {
            Open();
            _dialogTextMeshPro.text = "none dialog";
            return;
        }

        _selectedPart = new Dictionary<string, Node>();
        foreach (var item in anotherNode.Nodes)
        {
            _selectedPart.Add(item.Contens.ToLower(),item);
        }

        Open();
        ViewNodes(anotherNode.Nodes[STARTINDEX]);
    }


    private void ViewNodes(Node _currentNode)
    {

        DeleteAllChild(_positionOfResponses);
        StopAllCoroutines();

        _nextNode = _currentNode;
        _dialogTextMeshPro.text = _currentNode.MainText;
        if(_currentNode.Responce.Length != 0)
        {
            for(int i = _currentNode.Responce.Length - 2; i >= 0; i--)
            {
                Button button = Instantiate(_prefabsButton,_positionOfResponses) as Button;
                var passage = _currentNode.Responce[i];
                button.GetComponentInChildren<TextMeshProUGUI>().text = passage.Name;
                button.onClick.AddListener(delegate { SelectedNode(passage.Id.ToLower()); });
               
            }
        }
        else
        {
            Close();      
        }
    }
    private void DeleteAllChild(RectTransform parent)
    {
        UnityEngine.Assertions.Assert.IsNotNull(parent);
        for (int children = parent.childCount - 1; children >= 0; children--)
        {
            Destroy(parent.GetChild(children).gameObject);
        }
    }

    private void SelectedNode(string content)
    {
        ViewNodes(_selectedPart[content]);
    }
    

    
}
