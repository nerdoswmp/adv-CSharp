using Microsoft.AspNetCore.Mvc;
using DTO;
using Microsoft.AspNetCore.Authorization;

namespace Controller.Controllers
{
    [ApiController]
    [Route("stock")]
    public class StockController : ControllerBase
    {

        [Authorize]
        [HttpPost("add")]
        public object addProductToStock([FromBody] StocksDTO stocks)
        {
            var nstocks = Model.Stocks.convertDTOToModel(stocks);

            var id = nstocks.save(stocks.store.CNPJ, stocks.product.bar_code, stocks.quantity, stocks.unit_Price);
            return new
            {
                loja = stocks.store,
                produto = stocks.product,
                quantidade = stocks.quantity,
                preço = stocks.unit_Price,
                id = id
            };

        }

        [Authorize]
        [HttpPut]
        [Route("update")]
        public string updateStock([FromBody] StocksDTO stocks)
        {
            var nstocks = Model.Stocks.convertDTOToModel(stocks);

            nstocks.updateStock();

            return "deu";
        }
    }
}
