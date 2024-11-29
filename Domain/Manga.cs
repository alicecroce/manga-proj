namespace manga_project.Domain
{
    public class Manga
    {
        public int MangaId { get; set; }
        public string  Title { get; set; }
        public int ReleaseYear { get; set; }
        public int MagazineId { get; set; }

        public override string ToString()
        {
            return $"Character Id: {MangaId}, Title: {Title}, Release year: {ReleaseYear}, Magazine Id: {MagazineId} ";
        }
    }


}
