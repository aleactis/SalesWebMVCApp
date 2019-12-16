using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvcApp.Models;
using SalesWebMvcApp.Models.ViewModels;
using SalesWebMvcApp.Services;
using SalesWebMvcApp.Services.Exceptions;

namespace SalesWebMvcApp.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            //Implementação paleativa
            if (id == null)
            {
                return NotFound();
            }

            //Pegar o objeto que estamos querendo deletar
            var obj = _sellerService.FindById(id.Value);

            //Implementação paleativa
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            //Solução paleativa
            if (id == null)
            {
                return NotFound();
            }

            //Pegar o objeto que estamos querendo detalhar
            var obj = _sellerService.FindById(id.Value);

            //Implementação paleativa
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            
            //Testar se o Id existe
            if (id == null)
            {
                //soluçãopaleativa
                return NotFound();
            }

            //Testar se o Id é nulo
            var obj = _sellerService.FindById(id.Value);
            
            if (obj == null)
            {
                return NotFound();
            }

            //Listar os departamentos na tela de edição
            List<Department> departments = _departmentService.FindAll();

            //Criar um objeto do tipo SellerFormViewModel e passar os dados para ele por se tratar de uma edição
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                //Solução paleativa
                return BadRequest();
            }

            //Tratar excessões
            try {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            } 
            catch (NotFoundException)
            {
                return NotFound();
            } 
            catch (DbConcurrencyException)
            {
                return BadRequest();
            }
        }
    }
}