using UnityEngine;

public class CoreColorFactory
{
    public Color Get(Core core) =>
    
        core.Stats.Type switch
        {
            ElementType.Fire => new Color(255, 0, 0, 0),
            _ => new Color(0, 0, 0, 255),
        };

}