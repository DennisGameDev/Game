using System.Collections.Generic;
using UnityEngine;

namespace Game.Utility
{
    public class DisableEntity : MonoBehaviour
    {
        [SerializeField] private List<MonoBehaviour> listToDisable;

        public void DisableList()
        {
            for (int i = 0; i < listToDisable.Count; i++)
            {
                listToDisable[i].enabled = false;
            }
        }
    }
}
