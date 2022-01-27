namespace CHETUPROJECT.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount {get; set;}
        public Category Category { get; set; }
       
        public string ImageUrl { get; set; }    

    }
}
