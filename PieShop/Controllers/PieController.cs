using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PieShop.Models;
using PieShop.ViewModels;

namespace PieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)  //Repositories brought in by Dependency Injection Startup-Config Svcs.
        {
            // Keep track of the injected repositories locally
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;

        }
        // Once you have the local readonly fields tracking the injected repository models
        // you then need to start making Action methods that will actually handle the incoming requests


        public ViewResult List()
        {
            PiesListViewModel piesListViewModel = new PiesListViewModel();
            piesListViewModel.Pies = _pieRepository.AllPies;

            piesListViewModel.CurrentCategory = "Cheese Cakes!";
            // return a view that will dipslay all of the Pies coming out of the repository model
            return View(piesListViewModel);


        }

     

    }
}
