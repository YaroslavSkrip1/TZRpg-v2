
using System.Collections.Generic;
using Config.Data;

namespace Character.Service.Impls
{
    public interface ICharacterRepository
    {
        IReadOnlyList<CharacterEntry> GetAll();
    }
}