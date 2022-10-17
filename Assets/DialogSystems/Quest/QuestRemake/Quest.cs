using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace RemakeQuest
{
    public class Quest : ScriptableObject
    {
        [System.Serializable]
        public struct InfoQuest
        {
            public string _nameQuest;
            public string _descriptionQuest;
        }
        
        public InfoQuest Info = new InfoQuest();
        
        public string NameQuest => Info._nameQuest;
        public string DescriptionQuest => Info._descriptionQuest;

        public  QuestCompletedEvent OnCompleteQuest ;
        public bool _isCompleted {get; protected set;}
        protected bool _isGive = false;


        public abstract class QuestGoal : ScriptableObject
        {

            public string _description;
            public int _currentAmount {get;protected set;}
            public int _requiredAmount = 1;

            public bool Completed {get;protected set;}
            [HideInInspector] public UnityEvent GoalCompleted;

            public virtual string GetDescription()
            {
                return _description;
            }
            public virtual void Initialize()
            {
                Completed = false;
                GoalCompleted = new UnityEvent();
            }

            protected virtual void Evaluate()
            {
                if(_currentAmount >= _requiredAmount)
                {
                    Complete();
                }
            }

            private void Complete()
            {
                Completed = true;
                GoalCompleted.Invoke();
                GoalCompleted.RemoveAllListeners();
            }

            private void RemoveQuest()
            {
                GoalCompleted.RemoveAllListeners();
            }
        }

        public List<QuestGoal> Goals;
        
        public virtual void InitializationQuest()
        {
            _isCompleted = false;
            OnCompleteQuest = new QuestCompletedEvent();

            foreach (var goal in Goals)
            {
                //goal.Initialize();
                goal.GoalCompleted.AddListener(delegate{ChechGoals();});
            }
        }

        private void ChechGoals()
        {
            _isCompleted = Goals.All(g => g.Completed);
            if(_isCompleted)
            {
                Debug.Log("Quest completed " + Info._nameQuest);
                OnCompleteQuest?.Invoke(this);
                OnCompleteQuest.RemoveAllListeners();
            }
        }
    }

    public class QuestCompletedEvent : UnityEvent<Quest> {}

#if UNITY_EDITOR
[CustomEditor(typeof(Quest))]
public class QuestEditor : Editor
{
    SerializedProperty _questInfoProperty;
    List<string> _questGoalType;
    SerializedProperty _questGoalListProperty;

    [MenuItem("Assets/Quest",priority =0)]
    public static void CreatQuest()
    {
        var newQuest = CreateInstance<Quest>();

        ProjectWindowUtil.CreateAsset(newQuest,"quest.asset");
    }
    void OnEnable()
    {
        _questInfoProperty = serializedObject.FindProperty(nameof(Quest.Info));
        _questGoalListProperty = serializedObject.FindProperty(nameof(Quest.Goals));
        var lookup = typeof(Quest.QuestGoal);
        _questGoalType = System.AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(assembly => assembly.GetTypes())
                            .Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(lookup))
                            .Select(type=>type.Name)
                            .ToList();
        

    }

    public override void OnInspectorGUI()
    {
        var child = _questInfoProperty.Copy();
        var depth = child.depth;

        child.NextVisible(true);

        EditorGUILayout.LabelField("Quest Info", EditorStyles.boldLabel);
        while(child.depth > depth)
        {
            EditorGUILayout.PropertyField(child,true);
            child.NextVisible(false);
        }

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Add new Quest Goal", EditorStyles.boldLabel);
        int choice = EditorGUILayout.Popup("Goal",-1,_questGoalType.ToArray());

        if(choice != -1)
        {
            var newInstance = ScriptableObject.CreateInstance(_questGoalType[choice]);
            AssetDatabase.AddObjectToAsset(newInstance,target);

            _questGoalListProperty.InsertArrayElementAtIndex(_questGoalListProperty.arraySize);
            _questGoalListProperty.GetArrayElementAtIndex(_questGoalListProperty.arraySize - 1)
                    .objectReferenceValue = newInstance;
        }

        Editor ed = null;
        int toDelete = -1;

        for(int i =0; i < _questGoalListProperty.arraySize;++i)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginVertical();

            var item = _questGoalListProperty.GetArrayElementAtIndex(i);
            SerializedObject obj = new SerializedObject(item.objectReferenceValue);

            Editor.CreateCachedEditor(item.objectReferenceValue,null,ref ed);

            ed.OnInspectorGUI();
            EditorGUILayout.EndVertical();
            if(GUILayout.Button("X",GUILayout.Width(32)))
            {
                toDelete = i;
            }
            EditorGUILayout.EndHorizontal();
        }

        if(toDelete != -1)
        {
            var item = _questGoalListProperty.GetArrayElementAtIndex(toDelete).objectReferenceValue;
            DestroyImmediate(item,true);

            _questGoalListProperty.DeleteArrayElementAtIndex(toDelete);
            _questGoalListProperty.DeleteArrayElementAtIndex(toDelete);
        }

        serializedObject.ApplyModifiedProperties();
    }
}
#endif

}

