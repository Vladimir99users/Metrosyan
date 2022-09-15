using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    [SerializeField] private Player _player;

    public void Respawn()
    {
        _player.transform.position = transform.position;
        _player.EnableAllAction();
        _player.GetComponent<CreatureHealth>().RestoreHP();
    }
}