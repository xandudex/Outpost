using Unity.Cinemachine;
using UnityEngine;

namespace MirzaBeig.CinematicExplosionsFree
{
    public class CustomImpulse : MonoBehaviour
    {
        CinemachineImpulseSource source;
        void Start()
        {

        }

        void OnEnable()
        {
            if (!source)
            {
                source = GetComponent<CinemachineImpulseSource>();
            }

            source.GenerateImpulse();
        }
    }
}
