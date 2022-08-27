using UnityEngine;

public class CoreColorFactory
{
    public Color Get(Core core) =>
    
        core.Stats.Type switch
        {
            ElementType.Fire => core.Color,
            _ => new Color(0, 0, 0, 255),
        };

}