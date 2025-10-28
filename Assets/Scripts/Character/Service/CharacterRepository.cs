using System.Collections.Generic;
using Character.Service.Impls;
using Config;
using Config.Data;

namespace Character.Service
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly CharacterCatalog _characterCatalog;

        public CharacterRepository(CharacterCatalog characterCatalog) => _characterCatalog = characterCatalog;

        public IReadOnlyList<CharacterEntry> GetAll() => _characterCatalog.Characters;
    }
}