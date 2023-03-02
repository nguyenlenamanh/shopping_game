using shopping_game.Constants;

namespace shopping_game.Entities
{
    public abstract class Rule
    {
        public abstract decimal DiscountPrice { get; }
        public List<Product> Products { get; set; } = new();
        public abstract decimal Total();
        public int GetNumberOfProduct(string sku) => Products.Where(p => p.SKU == sku).Count();
        public Product GetProductInfo(string sku) => Products.FirstOrDefault(p => p.SKU == sku);
    }

    public class AppleTVRule : Rule
    {
        public override decimal DiscountPrice 
        {
            get => 73m;
        }

        public override decimal Total()
        {
            var appletvCount = GetNumberOfProduct(ShoppingGameConst.APPLETV);

            var appletv = GetProductInfo(ShoppingGameConst.APPLETV);

            // eg: 5 appletv: 3 with discount, 2 without discount
            return ((appletvCount - appletvCount % 3) * DiscountPrice) + (appletvCount % 3 * (appletv?.Price ?? 0));
        }
    }

    public class SuperIpadRule : Rule
    {
        public override decimal DiscountPrice
        {
            get => 499.99m;
        }

        public override decimal Total()
        {
            var ipadCount = GetNumberOfProduct(ShoppingGameConst.SUPERIPAD);

            var ipad = GetProductInfo(ShoppingGameConst.SUPERIPAD);

            return ipadCount > 4 ? ipadCount * DiscountPrice : ipadCount * (ipad?.Price ?? 0);
        }
    }

    public class MacbookAndVGARule : Rule
    {
        public override decimal DiscountPrice
        {
            get => 0m;
        }

        public override decimal Total()
        {
            var macbookCount = GetNumberOfProduct(ShoppingGameConst.MACBOOK);

            var vgaCount = GetNumberOfProduct(ShoppingGameConst.VGA);

            var macbook = GetProductInfo(ShoppingGameConst.MACBOOK);

            var vga = GetProductInfo(ShoppingGameConst.VGA);

            // eg: if 2 macbook but 3 vga cable, we should charge for 1 vga cable
            var additionVga = vgaCount - macbookCount;

            return (additionVga > 0 ? additionVga * vga.Price : 0) + (macbookCount * (macbook?.Price ?? 0));
        }
    }
}
