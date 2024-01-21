namespace POCMongoDBId.Core.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Metadados> Metadados { get; set;}
    }
}
