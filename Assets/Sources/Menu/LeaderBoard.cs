using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private UnitsSpawner _spawner;
    [SerializeField] private UnitInfo _prefab;

    private List<MovementObject> _units;
    private List<UnitInfo> _unitInfos;

    private void OnEnable()
    {
        _units = new List<MovementObject>();
        _unitInfos = new List<UnitInfo>();

        _spawner.CreationEnded += CreateUnitInfos;
    }

    private void OnDisable()
    {
        _spawner.CreationEnded -= CreateUnitInfos;

        foreach (var unit in _units)
            unit.MurdersCountChanged -= ChangeLeaderBoard;
    }

    public int GetPlayerPlace()
    {
        var result = _unitInfos.Where(unit => unit.Unit is PlayerView);

        return result.First().Place;
    }

    private void CreateUnitInfos(MovementObject[] units)
    {
        for(var i = 0; i < units.Length; i++)
        {
            var unitInfo = Instantiate(_prefab, transform);

            unitInfo.Init(i + 1);
            _unitInfos.Add(unitInfo);
            _units.Add(units[i]);
            units[i].MurdersCountChanged += ChangeLeaderBoard;
        }

        ChangeLeaderBoard();
    }

    private void ChangeLeaderBoard()
    {
        var leaders = _units.OrderByDescending(unit => unit.MurdersCount).ToArray();

        for (var i = 0; i < _unitInfos.Count; i++)
            _unitInfos[i].ChangeInfo(leaders[i]);
    }
}
