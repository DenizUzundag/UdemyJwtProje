using System;
using System.Collections.Generic;
using System.Text;
using YSK.UdemyJwtProje.Business.Interfaces;
using YSK.UdemyJwtProje.DataAccess.Interfaces;
using YSKProje.UdemyJwtProje.Entities.Concrete;

namespace YSK.UdemyJwtProje.Business.Concrete
{
    public class ProductManager:GenericManager<Product>,IProductService
    {
        public ProductManager(IGenericDal<Product>genericDal):base(genericDal)
        {

        }
    }
}
