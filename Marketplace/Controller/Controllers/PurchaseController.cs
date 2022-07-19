using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
using Microsoft.AspNetCore.Authorization;

namespace Controller.Controllers;

[ApiController]
[Route("purchase")]
public class PurchaseController : ControllerBase
{

    [Authorize]
    [HttpGet]
    [Route("client/{clientID}")]
    public object getClientPurchase(string clientID)
    {
        return Purchase.findByClientId(clientID);
    }

    [Authorize]
    [HttpGet]
    [Route("store/{storeID}")]
    public object getStorePurchase(int storeID)
    {
        return Purchase.findByStoreId(storeID);
    }

    [Authorize]
    [HttpPost]
    [Route("buy/{storeID}/{productID}/{clientName}")]
    public object makePurchase(int storeID, int productID, string clientName)
    {
        // ! > stock
        // ! > get current time
        // ! > generate nf & conf_number
        // ! > find store and product
        var stock = Product.findProduct(productID, storeID);
        Random rand = new Random();
        var client = Client.findByUsername(clientName);
        var store = Store.findByIdNumber(storeID);
        var product = Product.findProdById(productID);

        PurchaseDTO purchase = new PurchaseDTO()
        {
            client = client,
            store = store,
            productsDTO = new List<ProductDTO>()
            {
                product
            },
            data_purchase = DateTime.Now,
            purchase_value = (double)stock.GetType().GetProperty("price").GetValue(stock, null),
            purchase_status = 1,
            payment_type = 2,
            number_nf = rand.Next(10000, 99999).ToString() + rand.Next(10000, 99999).ToString(),
            confirmation_number = rand.Next(10000, 99999).ToString() + rand.Next(10000, 99999).ToString() + rand.Next(10000, 99999).ToString()
            // 423894723456
        };

        var npurchase = Model.Purchase.convertDTOToModel(purchase);

        var id = npurchase.save();
        return new
        {
            data_compra = purchase.data_purchase,
            valor_compra = purchase.purchase_value,
            tipo_pagamento = purchase.payment_type,
            status_compra = purchase.purchase_status,
            numero_confirmacao = purchase.confirmation_number,
            numero_nf = purchase.number_nf,
            cliente = purchase.client,
            loja = purchase.store,
            produtos = purchase.productsDTO,
            id = id
        };
    }
}
