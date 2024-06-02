﻿using MysteryFoxes.Outpost.Storages;
using UnityEngine;

namespace MysteryFoxes.Outpost.Player
{
    [CreateAssetMenu(fileName ="player data",menuName ="Outpost/Data/Player")]
    internal class PlayerSO : EntitySO
    {
        [SerializeField]
        StorageData walletData;

        [SerializeField]
        StorageData handsData;

        public StorageData WalletData => walletData;
        public StorageData HandsData => handsData;
    }
}