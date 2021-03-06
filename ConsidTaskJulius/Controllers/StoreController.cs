﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConsidTaskJulius.Repository;
using ConsidTaskJulius.Viewmodels;
using ConsidTaskJulius.Helpers;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConsidTaskJulius.Models
{
    public class StoreController : Controller
    {
        IStoreRepository storeRepository;
        ICompanyRepository companyRepository;

        public StoreController(IStoreRepository sr, ICompanyRepository cr)
        {
            storeRepository = sr;
            companyRepository = cr;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var s = await storeRepository.List();
            return View(s);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            StoreViewModel storeViewModel = new StoreViewModel();
            storeViewModel.companies = await companyRepository.List();
  
            return View(storeViewModel);

        }

        [HttpPost]
        public async Task<ActionResult> Create(StoreViewModel storeViewModel)
        {

            if (!ModelState.IsValid)
            {
                storeViewModel.companies = await companyRepository.List();
                return View(storeViewModel);
            }

            Stores storeToCreate = StoreViewModelConverter.toStore(storeViewModel, new Stores());
            storeToCreate.Id = Guid.NewGuid();


            await storeRepository.Create(storeToCreate);
            return RedirectToAction("Index");

        }


        [HttpGet]
        public async Task<ActionResult> Delete(Guid Id)
        {
            Stores store = await storeRepository.GetById(Id);
            return View(store);
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<ActionResult> DeleteFromDB(Guid Id)
        {

            var storeToDelete = await storeRepository.GetById(Id);
            if (storeToDelete == null)
                return RedirectToAction("Index");


            storeRepository.Delete(storeToDelete);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Edit(Guid Id)
        {
            Stores store = await storeRepository.GetById(Id);
            List<Companies> companies = await companyRepository.List();
            StoreViewModel storeViewModel = StoreViewModelConverter.fromStore(store, new StoreViewModel(), companies);
            return View(storeViewModel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<ActionResult> EditInDatabase(StoreViewModel storeViewModel)
        {

            if (!ModelState.IsValid)
            {
                storeViewModel.companies = await companyRepository.List();
                return View(storeViewModel);
            }


            Stores store = StoreViewModelConverter.toStore(storeViewModel, new Stores());
            storeRepository.Update(store);
            
            return RedirectToAction("Index");
        }


    }
}
