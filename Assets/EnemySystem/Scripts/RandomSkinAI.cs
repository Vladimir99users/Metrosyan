using UnityEngine;

public class RandomSkinAI : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer[] _skinCreature;
    [SerializeField] private Material[] _material;


    private void OnEnable()
    {
        RefreshSkin();
    }

    private void RefreshSkin()
    {
        int count = Random.Range(0,_material.Length);
        RandomSkin(count);
    }

    private void RandomSkin(int count)
    {
        foreach (var item in _skinCreature)
        {
            item.material = _material[count];
        }
    }
}
