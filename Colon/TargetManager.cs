using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] private GameObject targetInstant;
    [SerializeField] private ColonManager colonManager;
    private List<GameObject> scars;
    private List<GameObject> targets;
    void Start()
    {
        scars = new List<GameObject>();
        targets = new List<GameObject>();
        GameObject[] scars_array = GameObject.FindGameObjectsWithTag("Scar");
        foreach(GameObject scar in scars_array)
        {
            scars.Add(scar);
            float random_x = Random.Range(-1.3f,1.3f);
            float random_z = Random.Range(-16.5f, -12.5f);
            Vector3 transform = new Vector3(random_x, 10.45f, random_z);
            GameObject target = Instantiate(targetInstant,transform,Quaternion.Euler(new Vector3(0f,0f,0f)));
            targets.Add(target);
            target.GetComponent<Target>().SetScar(scar);
            target.GetComponent<Target>().SetTargetManager(gameObject);
        }
    }


    public void DeleteObject(GameObject _scar, GameObject _target)
    {
        scars.Remove(_scar);
        targets.Remove(_target);
        Destroy(_scar);
        Destroy(_target,2.0f);
    }


    
    void Update()
    {
        if (scars.Count == 0)
        {
            colonManager.EndStage3();
            print("Game End!");
        }
    }
}
