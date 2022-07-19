using Microsoft.AspNetCore.Mvc;
using DTO;
using Model;
using Microsoft.AspNetCore.Authorization;

namespace Controller.Controllers
{
    [ApiController]
    [Route("store")]
    public class StoreController : ControllerBase
    {
        [HttpGet]
        [Route("get/all")]
        public object getAllStore()
        {
            var lojas = Model.Store.getStores();
            return lojas;
        }

        [Authorize]
        [HttpGet]
        [Route("all/{ownerlogin}")]
        public object getAllStoreFromOwner(string ownerLogin)
        {
            int ownerid = Owner.findByUsername(ownerLogin);
            var lojas = Model.Store.getStores().Where(s => s.owner.login == ownerLogin);

            return lojas;
        }

        [Authorize]
        [HttpPost]
        [Route("register")]
        public object registerStore([FromBody] StoreDTO store)
        {
            var nstore = Model.Store.convertDTOToModel(store);
            int ownerid = Owner.findByUsername(store.owner.login);

            var id = nstore.save(ownerid);
            return new
            {
                id = id,
                nome = store.name,
                CNPJ = store.CNPJ,
                owner = store.owner
            };
        }

        [HttpGet]
        [Route("getStore/{cnpj}")]
        public object getStoreInformation(string cnpj)
        {
            var store = Model.Store.getStoreInfo(cnpj);
            return store;
        }
    }
}
