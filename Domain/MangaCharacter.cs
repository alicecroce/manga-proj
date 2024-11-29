namespace manga_project.Domain
{
    public class MangaCharacter
    {
        public int MangaCharacterId {  get; set; }
        public int MangaId { get; set; }//chiave esterna
        public Manga Manga { get; set; }//proprietà di navigazione inversa 
        public int CharacterId { get; set; }//chiave esterna
        public Character Character { get; set; }//proprietà di navigazione inversa 
        public  bool IsCrossover { get; set; }

        public override string ToString()
        {
            var mangaInfo = Manga != null ? $"Manga: {Manga.Title}" : "Manga not loaded";
            var characterInfo = Character != null ? $"Character: {Character.Name}" : "Character not loaded";

            return $"MangaCharacterId: {MangaCharacterId}, {mangaInfo}, {characterInfo}, IsCrossover: {IsCrossover}";
        }


    }
}
