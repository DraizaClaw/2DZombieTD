using UnityEngine;

[CreateAssetMenu(fileName = "NewTower", menuName = "New Tower", order = 0)]
public class TowerInformation : ScriptableObject
{
    
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _cost;
    [SerializeField] private int _damage;
    [SerializeField] private int _attackSpeed;
    [SerializeField] private int _range;

    public string Name => _name;
    public string Description => _description;
    public int Cost => _cost;
    public int Damage => _damage;
    public int AttackSpeed => _attackSpeed;
    public int Range => _range;
}
