using BLL.DTO;

namespace PizzaSuperb.ViewModels
{
    public class OrderViewModel
    {
        public List<PizzaOrderViewModel> PizzaTypes { get; set; }
        public List<DoppingDTO> Doppings { get; set; }
    }
}
