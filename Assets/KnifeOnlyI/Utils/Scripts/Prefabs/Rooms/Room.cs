using TMPro;
using UnityEngine;

namespace KnifeOnlyI.Utils.Rooms
{
    public class Room : MonoBehaviour
    {
        [SerializeField]
        private string roomName;

        [SerializeField]
        private TMP_Text roomNameComponent;

        private void Awake()
        {
            SetName(roomName);
        }

        public void SetName(string value)
        {
            roomNameComponent.text = value;
        }
    }
}