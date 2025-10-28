using System.Collections.Generic;
using Config.Data;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(menuName = "Game/Character Catalog", fileName = "CharacterCatalog")]
    public class CharacterCatalog : ScriptableObject
    {
        public List<CharacterEntry> Characters;
    }
}