using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CielaSpike;
using System.Threading;


public class MultithreadTest : MonoBehaviour
{
    public List<Vector3> vectors;
    public int numcalculs;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<500; i++)
        {
            vectors.Add(new Vector3(Random.value * 500, Random.value * 500, Random.value * 500));
        }
        numcalculs = 0;
        Debug.Log("time:"+Time.realtimeSinceStartup);
         StartCoroutine(DoAverages());
       //  DoAverages();
        Debug.Log("time:" + Time.realtimeSinceStartup);

    }

    IEnumerator DoAverages()
    {
        List<Task> tasks = new List<Task>() ;
        for (int i = 0; i < vectors.Count; i++)
        {
            Task task;
            this.StartCoroutineAsync(DoAverage(vectors[i]), out task);
            tasks.Add(task);
                     

        }
        while (tasks.Count>0)
        {
            List<Task> toberemoved = new List<Task>();
            for (int i = 0; i < tasks.Count; i++)
            {
                if(tasks[i].State == TaskState.Error)
                {
                    tasks[i].Cancel();
                    toberemoved.Add(tasks[i]);
                }
                if (tasks[i].State == TaskState.Done)
                {
                    toberemoved.Add(tasks[i]);
                }
            }
            foreach(Task task in toberemoved)
            {
                tasks.Remove(task);
            }
            //Thread.Sleep(1);
        }
        Debug.Log("finished");
        yield break;

    }

    IEnumerator DoAverage(Vector3 firstvector)
    {
        
        for (int j = 0; j < vectors.Count; j++)
        {
            Vector3 tempvec = vectors[j];
            float bob = Vector3.Distance(tempvec, firstvector);
            /* yield return Ninja.JumpToUnity;

             yield return Ninja.JumpBack;*/
       
           
        }
        //yield return Ninja.JumpToUnity;

        numcalculs++;
        Debug.Log("calculs:" + numcalculs);
        // yield return Ninja.JumpBack;
        yield break;


    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
