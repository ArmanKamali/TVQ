﻿namespace Genometric.TVQ.API.Model
{
    public class AuthorPublication
    {
        public int AuthorID { set; get; }
        public Author Author { set; get; }

        public int PublicationID { set; get; }
        public Publication Publication { set; get; }

        // This parameterless constructor is required by EF.
        public AuthorPublication() { }

        public AuthorPublication(Author author, Publication publication)
        {
            Author = author;
            Publication = publication;
        }
    }
}
