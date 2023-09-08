namespace AroniumDataExtractor.Models.QueryResultModels
{
    /// <summary>
    /// Contains all the customer, product and quantity information
    /// </summary>
    public class CustomerItemQuantities
    {
        public List<string> CustomerName = new List<string>();
        public List<string> Products = new List<string>();
        public List<int> Quantities = new List<int>();
    }
}
