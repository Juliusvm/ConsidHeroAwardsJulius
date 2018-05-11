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
            var companies = await companyRepository.GetCompanies();
            return View(companies);
        }

        [HttpGet]
        public async Task<ActionResult> Delete(Guid Id)
        {
            Companies company = await companyRepository.GetCompany(Id);
            return View(company);
        }

        [ActionName("Delete")]
        [HttpPost]
        public async Task<ActionResult> DeleteCompany(Guid Id)
        {

            var company = await companyRepository.GetCompany(Id);
            if (company == null)
                return RedirectToAction("Index");


            await companyRepository.DeleteCompany(company);
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
            await companyRepository.CreateCompany(company);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<ActionResult> Edit(Guid Id)
        {
            Companies company = await companyRepository.GetCompany(Id);
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


            await companyRepository.UpdateCompany(company);
            return RedirectToAction("Index");
        }

    }
}
