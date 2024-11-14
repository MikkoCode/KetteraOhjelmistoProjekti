using Gym_management_project.gym_management;


namespace Gym_management_project.Modules
{
    public class ProductModule
    {

        private GymManagementContext Context;

        public ProductModule(GymManagementContext context)
        {
            Context = context;
        }

        public void SearchProducts()
        {
            ConsoleHelper.WriteHeader("SEARCH PRODUCTS");
           
            string searchFilter = ConsoleHelper.Prompt("Enter product name");
            ConsoleHelper.WriteInfo($"Searching Products which name contains '{searchFilter}'");

            var products = Context.Products.Where(r => r.Name.Contains(searchFilter)).ToList();

            ConsoleHelper.WriteLine($"Found {products.Count} products:", ConsoleColor.DarkYellow);
            ConsoleHelper.WriteLine();
            foreach (var product in products)
            {
                var text = $"{product.ProductId}: {product.Name}";
                ConsoleHelper.WriteLine(text);
            }
            ConsoleHelper.WriteLine();
        }

        public void AddProducts()
        {
            ConsoleHelper.WriteHeader("ADD PRODUCT");

            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss");
            ConsoleHelper.WriteLine("Adding products");

            var name = ConsoleHelper.Prompt("Enter product name");

            var product1 = new Product()
            {
                Name = $"{name} {timestamp}",
            };

            Context.Products.Add(product1);
            Context.SaveChanges();

            ConsoleHelper.WriteLine("Products added into database");
            ConsoleHelper.WriteLine();
            ConsoleHelper.WriteLine($"- {product1.ProductId}: {product1.Name}");
            ConsoleHelper.WriteLine();
        }

    }

}
