using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Quest
{
    [CreateAssetMenu(fileName = "New Quest", menuName = "Create Quest/Quest")]
    public class Quest : ScriptableObject
    {
        

        public InfoQuest Info = new InfoQuest();

        public QuestCompletedEvent OnCompleteQuest;

        public bool _isCompleted ;

        public int ID = 0;

        public abstract class QuestGoal : ScriptableObject
        {

            public LocalizationDescriptionQuest _description;

            public int _requiredAmount = 1;
            public int _currentAmount ;

            public bool Completed ;

            [HideInInspector]
            public UnityEvent GoalCompleted;

            public virtual string GetDescription()
            {
                return _description.GetTextFile().Description;
            }

            public virtual void Initialize()
            {
                ResetAllProperty();
                GoalCompleted = new UnityEvent();
            }

            internal void ResetAllProperty()
            {
                _currentAmount = 0;
                Completed = false;
            }

            protected virtual void Evaluate()
            {
                if (_currentAmount >= _requiredAmount)
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
        }

        public List<QuestGoal> Goals;

        public virtual void InitializationQuest()
        {
            _isCompleted = false;
            OnCompleteQuest = new QuestCompletedEvent();
            foreach (var goal in Goals)
            {
                goal.ResetAllProperty();
            }
            Debug.Log("Вы взяли квест из линейки: "  + Info._nameQuest);

            ID = 0;
            InitializeQuestGoalUnderTheNumber(ID);
        }

        private void CheckGoals()
        {
            ID++;
            if (ID < Goals.Count) 
            {
                InitializeQuestGoalUnderTheNumber(ID);
            }

            _isCompleted = Goals.All(g => g.Completed);
            
            if (_isCompleted)
            {
                Debug.Log("Quest completed " + Info._nameQuest);
                OnCompleteQuest?.Invoke(this);
                OnCompleteQuest.RemoveAllListeners();
            }
        }

        private void InitializeQuestGoalUnderTheNumber(int indexQuest)
        {
            Goals[indexQuest].Initialize();
            Goals[indexQuest].GoalCompleted.AddListener(delegate()
            {
                CheckGoals();
            });
        
        }
    }

    public class QuestCompletedEvent : UnityEvent<Quest> { }


#if UNITY_EDITOR
    [CustomEditor(typeof(Quest))]
    public class QuestEditor : Editor
    {
        SerializedProperty _questInfoProperty;

        List<string> _questGoalType;

        SerializedProperty _questGoalListProperty;
        void OnEnable()
        {
            _questInfoProperty =
                serializedObject.FindProperty(nameof(Quest.Info));
            _questGoalListProperty =
                serializedObject.FindProperty(nameof(Quest.Goals));
            var lookup = typeof(Quest.QuestGoal);
            _questGoalType =
                System
                    .AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .SelectMany(assembly => assembly.GetTypes())
                    .Where(x =>
                        x.IsClass && !x.IsAbstract && x.IsSubclassOf(lookup))
                    .Select(type => type.Name)
                    .ToList();
        }

        public override void OnInspectorGUI()
        {
            var child = _questInfoProperty.Copy();
            var depth = child.depth;

            child.NextVisible(true);

            EditorGUILayout.LabelField("Quest Info", EditorStyles.boldLabel);
            while (child.depth > depth)
            {
                EditorGUILayout.PropertyField(child, true);
                child.NextVisible(false);
            }

            EditorGUILayout.Space();

            EditorGUILayout
                .LabelField("Add new Quest Goal", EditorStyles.boldLabel);
            int choice =
                EditorGUILayout.Popup("Goal", -1, _questGoalType.ToArray());

            if (choice != -1)
            {
                var newInstance =
                    ScriptableObject.CreateInstance(_questGoalType[choice]);
                AssetDatabase.AddObjectToAsset(newInstance, target);

                _questGoalListProperty
                    .InsertArrayElementAtIndex(_questGoalListProperty
                        .arraySize);
                _questGoalListProperty
                    .GetArrayElementAtIndex(_questGoalListProperty.arraySize -
                    1)
                    .objectReferenceValue = newInstance;
            }

            Editor ed = null;
            int toDelete = -1;
            int toSwapUp = -1;
            int toSwapDown = -1;

            for (int i = 0; i < _questGoalListProperty.arraySize; ++i)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.BeginVertical();

                var item = _questGoalListProperty.GetArrayElementAtIndex(i);
                SerializedObject obj =
                    new SerializedObject(item.objectReferenceValue);

                Editor.CreateCachedEditor(item.objectReferenceValue,null,ref ed);

                ed.OnInspectorGUI();
                Texture2D texture;
                EditorGUILayout.EndVertical();
                //GUI.backgroundColor = Color.blue;
                if (GUILayout.Button("X", GUILayout.Width(32)))
                {
                    toDelete = i;
                }
                texture = Resources.Load<Texture2D>(@"ICON/Up");

                if (GUILayout.Button(texture, GUILayout.Width(32)))
                {
                    toSwapUp = i;
                }
                texture = Resources.Load<Texture2D>("Down");
                if (GUILayout.Button(texture, GUILayout.Width(32)))
                {
                    Debug.Log(texture.name);
                    toSwapDown = i;
                }
                //GUI.backgroundColor = Color.gray;
                EditorGUILayout.EndHorizontal();
            }

            if (toDelete != -1)
            {
                var item =
                    _questGoalListProperty
                        .GetArrayElementAtIndex(toDelete)
                        .objectReferenceValue;
                DestroyImmediate(item, true);

                //_questGoalListProperty.DeleteArrayElementAtIndex(toDelete);
                _questGoalListProperty.DeleteArrayElementAtIndex(toDelete);
            }

            if(toSwapUp != -1)
            {
                var item = _questGoalListProperty.GetArrayElementAtIndex(toSwapUp)
                                                 .objectReferenceValue;
                _questGoalListProperty.MoveArrayElement(toSwapUp,toSwapUp-1);
            }

            if(toSwapDown != -1)
            {
                var item = _questGoalListProperty.GetArrayElementAtIndex(toSwapDown)
                                                 .objectReferenceValue;
                _questGoalListProperty.MoveArrayElement(toSwapDown,toSwapDown+1);
            } 

            serializedObject.ApplyModifiedProperties();
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            //base.OnInspectorGUI();
        }


        private void SwapQuestElement(int action)
        {
            
        }
    }
#endif

}
