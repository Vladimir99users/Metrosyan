using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using DialogControl.Item;

public class ViewDialog : Menu
{
    [Header("Компоненты для визуального отображения диалога")]
    [SerializeField] private TextMeshProUGUI _dialogTextMeshPro;
    [SerializeField] private Button _prefabsButton;
    [SerializeField] private RectTransform _positionOfResponses;
    [SerializeField] private Slider _timerSlider;
    

    [Space] [Header("Найстрока таймера ответа")]
    [Tooltip("Время через которое, игрок перейдёт на следующий Node")][SerializeField][Range(0,100)] private int _timeToThink = 5;
    [Tooltip("Если нужен таймер не раз в секунду")] [SerializeField][Range(0f,2f)] private float _interval = 1;
    [Tooltip("Сколько секунд надо ждать (по умолчанию равна _interval)")] [SerializeField] [Range(0f,2f)] private float _sumInterval = 1;


    public static Action<Conversation> OnStartConfigurationDialog;
    public static Action OnCloseConfigurationDialog;

    private Dictionary<string,Node> _selectedPart;
    private Node _nextNode;
    private readonly int STARTINDEX = 0;

    private void OnEnable()
    {
        _timerSlider.maxValue = _timeToThink;
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
        ResetTimeSlider();
    }


    private void ViewNodes(Node _currentNode)
    {

        DeleteAllChild(_positionOfResponses);
        StopAllCoroutines();

        _nextNode = _currentNode;

        

        _dialogTextMeshPro.text = _currentNode.MainText;
        if(_currentNode.Responce.Length != 0)
        {
            StartCoroutine(PausedToReply());
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
        ResetTimeSlider();
        ViewNodes(_selectedPart[content]);
    }
    

    private void ResetTimeSlider()
    {
        _timerSlider.value = _timerSlider.maxValue;
    }

    private IEnumerator PausedToReply()
    {
        while(true)
        {
            if(_timerSlider.value == _timerSlider.minValue)
            {
                SelectedNode(_nextNode.Responce[_nextNode.Responce.Length-1].Id.ToLower());
                yield return null;
            }
            _timerSlider.value -= _sumInterval;
            yield return new WaitForSeconds(_interval);
        }
    }


    private IEnumerator CloseDialogPanel()
    {
        while(true)
        {
            if(_timerSlider.value == _timerSlider.minValue)
            {
                yield return new WaitForSeconds(_interval);
                StopAllCoroutines();
                Close();
            }
            _timerSlider.value -= _sumInterval;
            yield return new WaitForSeconds(_interval);
        }     
    }


    [ContextMenu("Change value")]
    public void Changed()
    {
       _timerSlider.value = _timerSlider.maxValue;
    }
}
