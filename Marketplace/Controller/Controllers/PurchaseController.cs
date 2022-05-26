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
    public object getStorePurchase(string storeID)
    {
        return Purchase.findByStoreId(storeID);
    }

    [Authorize]
    [HttpPost]
    [Route("buy")]
    public object makePurchase(PurchaseDTO purchase)
    {
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
