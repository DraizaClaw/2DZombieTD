using UnityEngine;
using UnityEngine.UI;

public class BuildTowerUIcontroller : MonoBehaviour
{


    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject InformationPanel;
    [SerializeField] private Text TowerSpecs;
    [SerializeField] private Button ToggleButton;


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


        InformationPanel.SetActive(true);
    }

    public void HideTowerInformation()
    {


        InformationPanel.SetActive(false); 
    }

    public void TogglePanel() 
    {
        if (Panel.activeInHierarchy) //if it is there
        {
            Panel.SetActive(false); //hide it
            ToggleButton.transform.localPosition = new Vector2(885, -465);
            ToggleButton.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else
        {
            Panel.SetActive(true);
            ToggleButton.transform.localPosition = new Vector2(488, -465);
            ToggleButton.transform.rotation = new Quaternion(0, 0, 180, 0);

        }
    }



}
