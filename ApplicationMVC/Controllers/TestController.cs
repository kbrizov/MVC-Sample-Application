using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;
using ApplicationMVC.Data;
using ApplicationMVC.ViewModels;
using ApplicationMVC.Repositories;
using ApplicationMVC.EntityModels;

namespace ApplicationMVC.Controllers
{
    public class TestController : Controller
    {
        private readonly IRepository<TestEntity> testRepository;

        public TestController()
          : this(new EfRepository<TestEntity>(new ApplicationDbContext())) // this(new InMemoryDataRepository())
        {
        }

        public TestController(IRepository<TestEntity> testRepository) 
            : base()
        {
            this.testRepository = testRepository;
        }

        public ActionResult Autocomplete(string term)
        {
            var autocompleteData = this.testRepository
                .GetAll()
                .Where(entity => entity.Text.Contains(term))
                .Select(item => new
                {
                    label = item.Text
                });

            return Json(autocompleteData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult List(string term = null, int take = 10)
        {
            IEnumerable<TestModel> viewModel = null;
            IQueryable<TestEntity> data = null;

            if (term == null)
            {
                data = this.testRepository.GetAll();
            }
            else
            {
                data = this.testRepository.GetAll().Where(entity => entity.Text.Contains(term));
            }

            viewModel = data
                .OrderBy(entity => entity.Number)
                .Take(take)
                .ToList()
                .Select(entity => TestModel.CreateFromTestEntity(entity));

            if (Request.IsAjaxRequest())
            {
                return PartialView("_TestItemsList", viewModel);
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TestEntity newEntity)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException("Model state is not valid.");
            }

            this.testRepository.Add(newEntity);

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var entity = this.testRepository.GetById(id);
            var viewModel = TestModel.CreateFromTestEntity(entity);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(TestEntity updatedEntity)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException("Model state is not valid.");
            }

            updatedEntity = this.testRepository.Update(updatedEntity.Id, updatedEntity);
            var viewModel = TestModel.CreateFromTestEntity(updatedEntity);

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var entity = this.testRepository.GetById(id);
            var viewModel = TestModel.CreateFromTestEntity(entity);

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(TestEntity toBeDeleted)
        {
            if (!ModelState.IsValid)
            {
                throw new InvalidOperationException("Model state is not valid.");
            }

            this.testRepository.Delete(toBeDeleted.Id);

            return RedirectToAction("List");
        }

        public ActionResult Details(int id)
        {
            var entity = this.testRepository.GetById(id);
            var model = TestModel.CreateFromTestEntity(entity);

            return View(model);
        }
    }
}