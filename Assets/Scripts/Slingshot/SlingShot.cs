using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Slingshot;
using Borbs;
using UnityEngine;

public class SlingShot : MonoBehaviour
{
    [SerializeField] private BorbTransfer borbTransfer = new();
    [SerializeField] private float power = 10;
    [SerializeField] private float count = 3;
    [Header("Dependencies")] [SerializeField]
    private ShootPoint shotPoint = null!;
    [SerializeField] private BorbSpawner borbSource = null!;

    private void Awake()
    {
        // => shotPoint.EnsureNotNull(); ??
        // => borbSource.EnsureNotNull();
    }

    private IEnumerator Start()
    {
        for (int i = 0; i < count; i++)
        {
            var borb = borbSource.NextBorb();
            yield return SeatBorb(borb);
            yield return WaitShot(borb);
        }
        print($"The borbs are over");
    }

    private IEnumerator WaitShot(Borb borb)
    {
        var done = false;

        void Shot(Vector3 direction)
        {
            done = true;
            //print($"Direction {direction}");
            // => borb.EnsureNotNull().Launch(-direction * power); ??
            borb!.Launch(-direction * power);
        }

        shotPoint.release!.AddListener(Shot);
        // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
        while (done == false)
        {
            borb.transform.position = shotPoint.transform.position;
            yield return null;
        }

        shotPoint.release.RemoveListener(Shot);
    }


    private IEnumerator SeatBorb(Borb borb)
    {
        shotPoint.enabled = false;
        yield return borbTransfer.Transfer(borb, shotPoint.transform.position);
        shotPoint.enabled = true;
    }
}
