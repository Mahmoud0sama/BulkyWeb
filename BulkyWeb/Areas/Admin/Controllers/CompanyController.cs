
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Bulky.Utility;
using BulkyWeb.DataAccess.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using System.Collections.Generic;


namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
         
            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id)
        {
           
            if (id == null || id == 0)
            {
				return View(new Company());
			}
            else
            {
                Company companyobj=_unitOfWork.Company.Get(u=>u.Id == id);
                return View(companyobj);
            }
		}

        [HttpPost]
        public IActionResult Upsert(Company Companyobj)
        {
            if (ModelState.IsValid)
            {
                
                if (Companyobj.Id == 0)
                {
					_unitOfWork.Company.Add(Companyobj);
                    TempData["success"] = "Company Created Successfully";
                }
                else
                {
					_unitOfWork.Company.Update(Companyobj);
                    TempData["success"] = "Company Updated Successfully";
                }
                
                _unitOfWork.Save();
               
                return RedirectToAction("Index");
            }
            else
            {
                
				return View(Companyobj);
			}
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Company> objCompanyList = _unitOfWork.Company.GetAll().ToList();
            return Json(new { data = objCompanyList });
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDeleted= _unitOfWork.Company.Get(u=>u.Id == id);
            if (CompanyToBeDeleted == null)
            {
                return Json(new { success = false , message = " Error while deleting " });
            }
            _unitOfWork.Company.Remove(CompanyToBeDeleted);
            _unitOfWork.Save();
           
            return Json(new { success = true, massege= "Delete Successful" });
        }
        #endregion
    }
}
