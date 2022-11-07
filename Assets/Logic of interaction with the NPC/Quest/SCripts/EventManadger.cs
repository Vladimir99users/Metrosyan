using UnityEngine.Events;
using Quest.ItemConfiguration;
using DialogSystem;

public class EventManadger
{
    public static TalkWithNPC OnNPCTalk = new TalkWithNPC();
    public static AnEnemyWasKilled OnKillSendMessage = new AnEnemyWasKilled();
    public static QuestIsDone OnComletedMessegaQuest = new QuestIsDone();
    public static DragItem OnDragItem = new DragItem();

    public static DialogueIsEnd OnDialogEnd = new DialogueIsEnd();
    public static DialogueIsStarted OnDialogStarted = new DialogueIsStarted();


    public static void SendWithNPC(CreateNewNPC nameNPC)
    {
        OnNPCTalk?.Invoke(nameNPC);
    }

    public static void SendMessageKillEnemy(EnemyType type)
    {
        OnKillSendMessage?.Invoke(type);
    }
    public static void SendComletedMessageQuest()
    {
        OnComletedMessegaQuest?.Invoke();
    }

    public static void SendDragItem(Configuration item)
    {
        OnDragItem?.Invoke(item);
    }
    public static void SendAboutDialogueHasStarted(Dialog _dialog)
    {
        OnDialogStarted?.Invoke(_dialog);
    }

    public static void SendAboutDialogueHasEnded()
    {
        OnDialogEnd?.Invoke();
    }

}


public class DialogueIsStarted : UnityEvent<Dialog> { }
public class DialogueIsEnd : UnityEvent { }
public class TalkWithNPC :  UnityEvent<CreateNewNPC>{}
public class AnEnemyWasKilled :  UnityEvent<EnemyType>{}
public class QuestIsDone :  UnityEvent{}
public class DragItem :  UnityEvent<Configuration>{}