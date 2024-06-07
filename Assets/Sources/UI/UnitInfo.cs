using BattleIsland.Infrastructure.View;
using TMPro;
using UnityEngine;

namespace BattleIsland.UI
{
    public class UnitInfo : MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _murdersCount;
        [SerializeField] private TMP_Text _place;

        public int Place { get; private set; }
        public MovementObject Unit { get; private set; }

        public void Init(int place)
        {
            Place = place;
            _place.text = place.ToString();
        }

        public void ChangeInfo(MovementObject unit)
        {
            _name.text = unit.Name;
            _murdersCount.text = unit.MurdersCount.ToString();
            Unit = unit;
        }
    }
}