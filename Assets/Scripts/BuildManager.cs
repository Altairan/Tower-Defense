
using UnityEngine;

public class BuildManager : MonoBehaviour
{

	public static BuildManager instance;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}


	public GameObject buildEffect;

	private TurretBlueprint turretToBuild;

	public bool CanBuild { get { return turretToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }

	public void BuildTurretOn(Node node)
    {
		if(PlayerStats.Money < turretToBuild.cost)
        {
			Debug.Log("NOT");
			return;
        }

		PlayerStats.Money -= turretToBuild.cost;

		GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
		node.turret = turret;
		Debug.Log("Turret Built Money Left: " + PlayerStats.Money);
		GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
		Destroy(effect, 5f);
    }

	public void SelectTurretToBuild (TurretBlueprint turret)
    {
		turretToBuild = turret;
    }
}
