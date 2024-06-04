using MessagePipe;
using MysteryFoxes.Outpost.Items;
using MysteryFoxes.Outpost.Player;
using MysteryFoxes.Outpost.Storages;
using R3;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using VContainer;

namespace Game
{
    public class PlayerDebug : MonoBehaviour
    {

        [SerializeField]
        UIDocument document;

        StorageVisual handsVisual;
        StorageVisual walletVisual;

        Player player;
        ItemFactory itemFactory;

        [Inject]
        void Construct(IBufferedSubscriber<Player> playerSubscriber, ItemFactory itemFactory)
        {
            this.itemFactory = itemFactory;
            playerSubscriber.Subscribe(x => Setup(x)).AddTo(this);
        }

        void Setup(Player player)
        {
            this.player = player;
            walletVisual = new StorageVisual(player.Model.Wallet, document, "wallet").AddTo(this);
            handsVisual = new StorageVisual(player.Model.Hands, document, "hands").AddTo(this);
        }
        [Button("Add")]
        void AddItem(ItemSO item, int count)
        {
            player.Model.Wallet.Add(item, count);
        }
        class StorageVisual : IDisposable
        {
            public StorageModel Model { get; private set; }
            public Label Label { get; private set; }
            public Image Image { get; private set; }
            IDisposable disposable;
            public StorageVisual(StorageModel model, UIDocument document, string selector)
            {
                Model = model;
                Label = document.rootVisualElement.Query(selector).Children<Label>($"label").First();
                Image = document.rootVisualElement.Query(selector).Children<Image>($"image").First();

                Gen(Model.Current);

                disposable = model.StorageChanged.Subscribe(Gen);
            }

            private void Gen(IReadOnlyDictionary<ItemSO, int> dict)
            {
                KeyValuePair<ItemSO, int> pair = dict.FirstOrDefault();
                Image.sprite = pair.Key?.Icon;
                Label.text = pair.Value.ToString();
            }

            public void Dispose()
            {
                disposable?.Dispose();
            }
        }
    }
}
