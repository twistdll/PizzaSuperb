using BLL.DTO;

namespace PizzaSuperb.ViewModels
{
    public class OrderViewModel
    {
        public List<PizzaTypeOrderViewModel> PizzaTypes { get; set; }
        public List<DoppingDTO> Doppings { get; set; }
    }
}
