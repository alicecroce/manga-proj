﻿using System.Data;
using System.Net;

namespace manga_project.Domain
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Character Id: {CharacterId}, Name: {Name} ";
        }

        public ICollection<MangaCharacter> MangaCharacter { get; set; }

    }

    
}
