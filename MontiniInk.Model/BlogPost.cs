using System;
namespace MontiniInk.Model
{
    public class BlogPost: Entity
    {
        

        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public string Titel { get; set; }
        public string Content { get; set; }
        public string ImgLink { get; set; }
        public DateTime Datum { get; set; }


        public BlogPost(string Vorname, string Nachname, string Titel, string Content, string ImgLink)
        {
            this.Vorname= Vorname;
            this.Vorname= Vorname;
            this.Titel= Titel; 
            this.Content= Content;
            this.ImgLink= ImgLink;
            Datum= DateTime.Now;
        }
         public BlogPost(string Vorname, string Nachname, string Titel, string Content)
        {
            this.Vorname= Vorname;
            this.Vorname= Vorname;
            this.Titel= Titel; 
            this.Content= Content;
            Datum= DateTime.Now;
        }
            public BlogPost()
        {
            Titel= "Finde einen interessanten Titel";
            Content= "Worum geht es? Schreib ein paar Zeilen dazu";
            Datum= DateTime.Now;
        }

        public string ToSrc()
        {
            return "src="+ImgLink;
        }
       

    }
}