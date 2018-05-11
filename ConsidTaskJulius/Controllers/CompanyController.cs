using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsidTaskJulius.Models;
using ConsidTaskJulius.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ConsidTaskJulius.Controllers
{
    public class CompanyController : Controller
    {
        ICompanyRepository companyRepository;

        public CompanyController(ICompanyRepository _repo)
        {
            companyRepository = _repo;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var companies = await companyRepository.List();
            return View(companies);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid Id)
        {
            Companies company = await companyRepository.GetById(Id);
            return View(company);
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<ActionResult> DeleteCompany(Guid Id)
        {

            var company = await companyRepository.GetById(Id);
            if (company == null)
                return RedirectToAction("Index");


            companyRepository.Delete(company);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Companies company)
        {
            company.Id = Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                return View();
            }
            await companyRepository.Create(company);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Edit(Guid Id)
        {
            Companies company = await companyRepository.GetById(Id);
            return View(company);
        }

        [HttpPost]
        [ActionName("Edit")]
        public async Task<ActionResult> EditInDatabase(Companies company)
        {
            
            if (!ModelState.IsValid)
            {
                return View(company);
            }


            companyRepository.Update(company);
            return RedirectToAction("Index");
        }

    }
}
