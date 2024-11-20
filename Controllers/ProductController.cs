using Microsoft.AspNetCore.Mvc;
using MyStoreAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        // Liste statique pour stocker les produits temporairement
        private static List<Produit> Produits = new List<Produit>
        {
            new Produit { Id = 1, Nom = "Produit1", Description = "Description1", Prix = 9.99M },
            new Produit { Id = 2, Nom = "Produit2", Description = "Description2", Prix = 19.99M }
        };

        // GET: api/Product
        [HttpGet]
        public ActionResult<IEnumerable<Produit>> GetProduits()
        {
            return Produits;
        }

        // GET: api/Product/{id}
        [HttpGet("{id}")]
        public ActionResult<Produit> GetProduit(int id)
        {
            var produit = Produits.FirstOrDefault(p => p.Id == id);
            if (produit == null)
                return NotFound();

            return produit;
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult<Produit> CreateProduit(Produit produit)
        {
            produit.Id = Produits.Count + 1;
            Produits.Add(produit);
            return CreatedAtAction(nameof(GetProduit), new { id = produit.Id }, produit);
        }

        // PUT: api/Product/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateProduit(int id, Produit produitMisAJour)
        {
            var produit = Produits.FirstOrDefault(p => p.Id == id);
            if (produit == null)
                return NotFound();

            produit.Nom = produitMisAJour.Nom;
            produit.Description = produitMisAJour.Description;
            produit.Prix = produitMisAJour.Prix;

            return NoContent();
        }

        // DELETE: api/Product/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteProduit(int id)
        {
            var produit = Produits.FirstOrDefault(p => p.Id == id);
            if (produit == null)
                return NotFound();

            Produits.Remove(produit);
            return NoContent();
        }
    }
}
