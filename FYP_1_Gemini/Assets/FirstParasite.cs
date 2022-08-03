using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstParasite : MonoBehaviour
{
    public Transform firstParasite;
    public Transform FirstContactDissapear;
    Vector3 firstParasitePos;
    Vector3 disspaearPos;
    public float speed;
    public static bool Check = false;
    void Start()
    {
        firstParasitePos = new Vector3(firstParasite.position.x, firstParasite.position.y, firstParasite.position.z);
        disspaearPos = new Vector3(FirstContactDissapear.position.x, FirstContactDissapear.position.y, FirstContactDissapear.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(Check == true)
        {
            MoveForward();
        }
    }

    void MoveForward()
    {
        var step = speed * Time.deltaTime;
        firstParasitePos = Vector3.MoveTowards(firstParasitePos, disspaearPos, step);
        transform.position = firstParasitePos;
        if((Vector3.Distance(firstParasitePos, disspaearPos) < 0.1f))
        {
            Destroy(this.gameObject);
        }
    }
}
