using BLL.DTO;
using PizzaSuperb.Constants;
using PizzaSuperb.ViewModels;

namespace PizzaSuperb.Extensions
{
    internal static class DTOExtensions
    {
        public static List<PizzaTypeViewModel> ToViewModelList(this List<PizzaTypeDTO> dtos,
                                                               List<KeyValuePair<string, string>> filteredCookies)

        {
            var model = new List<PizzaTypeViewModel>();
            var nameCountPairs = filteredCookies;


            foreach (var dto in dtos)
            {
                string notParsedCount = nameCountPairs
                                            .Where(x =>
                                                    x.Key.Split(CookieConstants.ProductPrefix)[1].Replace("%20", " ") == dto.Name)
                                            .FirstOrDefault()
                                            .Value;

                int count = int.Parse(string.IsNullOrEmpty(notParsedCount) ? "0" : notParsedCount);

                model.Add(new PizzaTypeViewModel()
                {
                    Name = dto.Name,
                    Description = dto.Description,
                    PhotoUrl = dto.PhotoUrl,
                    OldPrice = dto.OldPrice,
                    Price = dto.Price,
                    Count = count
                });
            }

            return model;
        }       
    }
}
