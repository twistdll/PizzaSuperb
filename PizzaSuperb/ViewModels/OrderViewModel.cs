namespace PizzaSuperb.ViewModels
{
    public class OrderViewModel
    {
        public List<PizzaTypeOrderViewModel> PizzaTypes { get; set; }
        public List<DoppingOrderViewModel> Doppings { get; set; }
    }
}
