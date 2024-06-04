using DG.Tweening;
using UnityEngine;
using VContainer;

namespace MysteryFoxes.Outpost.Productions
{
    internal class Production : MonoBehaviour
    {
        ProductionModel model;

        [Inject]
        void Construct(ProductionModel model)
        {
            this.model = model;
        }

        private void Start()
        {
            transform.DOScale(Vector3.one, 0.5f).From(0).SetEase(Ease.OutBack);
        }

        public ProductionModel Model => model;
    }
}
