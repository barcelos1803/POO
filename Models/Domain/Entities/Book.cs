namespace Domain.Entities
{
    public class Book : Entity
    {
        public int UserId { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }
    
        

        /* EF Relations */
        public IList<Author> Authors { get; set; }
        public User User { get; set; }
    }
}