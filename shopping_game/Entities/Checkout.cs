namespace shopping_game.Entities
{
    public class Checkout
    {
        private List<Rule> _rules { get; set; }
        private List<Product> _products { get; set; } = new();

        public Checkout(List<Rule> rules)
        {
            _rules = rules;
        }

        public void Scan(Product product)
        {
            _products.Add(product);

            UpdateProductForRule();
        }

        public decimal Total()
        {
            return _rules.Sum(rule => rule.Total());
        }

        private void UpdateProductForRule()
        {
            _rules.ForEach(rule => rule.Products = _products);
        }
    }
}
