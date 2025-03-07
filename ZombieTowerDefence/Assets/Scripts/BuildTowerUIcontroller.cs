using UnityEngine;
using UnityEngine.UI;

public class BuildTowerUIcontroller : MonoBehaviour
{


    [SerializeField] private GameObject Panel;
    [SerializeField] private Text TowerSpecs;


    private void Start()
    {
        HideTowerInformation();
    }

    public void ShowTowerInfo(TowerInformation tower)
    {
        TowerSpecs.text = ("Name: " + tower.Name)
            + ("\nAttackSpeed:" + (tower.AttackSpeed).ToString())
            + ("\nCost:" + (tower.Cost).ToString())
            + ("\n" + tower.Description)
            + ("\nRange:" + (tower.Range).ToString());

       
        Panel.SetActive(true);
    }

    public void HideTowerInformation()
    {
        

        Panel.SetActive(false); 
    }


}
