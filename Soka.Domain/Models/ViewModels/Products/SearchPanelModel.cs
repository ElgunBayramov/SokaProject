using Soka.Domain.AppCode.Infrastructure;
using System.Collections.Generic;

namespace Soka.Domain.Models.ViewModels.Products
{
    public class SearchPanelModel
    {
        public IEnumerable<HolderChooseModel> Brands { get; set; }
        public IEnumerable<HolderChooseModel> Colors { get; set; }
        public IEnumerable<HolderChooseModel> Sizes { get; set; }
        public IEnumerable<HolderChooseModel> Types { get; set; }

        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}
