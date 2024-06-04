using Sirenix.OdinInspector;
using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Constructions
{
    [RequireComponent(typeof(UniqueID))]
    internal class ConstructionSpawner : MonoBehaviour
    {
        [SerializeField, ReadOnly]
        UniqueID uniqueID;

        [SerializeField]
        ConstructionConfig data;

        ConstructionFactory constructionFactory;

        [Inject]
        void Construct(ConstructionFactory constructionFactory)
        {
            this.constructionFactory = constructionFactory;

        }

        private void Start()
        {
            Construction construction = constructionFactory.Create(data, uniqueID.Id);
            construction.transform.SetParent(transform.parent);
            construction.transform.SetPositionAndRotation(transform.position, transform.rotation);

            Destroy(gameObject);
        }

        private void Reset()
        {
            uniqueID = GetComponent<UniqueID>();
        }
    }
}
