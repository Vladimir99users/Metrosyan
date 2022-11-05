using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogControl
{
    using Item;
    interface ICanTalk
    {
        List<LocalizationTextFile<Conversation>> Conversation { get; set; }
        void StartDialog();
    }

}