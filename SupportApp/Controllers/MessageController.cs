using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportApp.Models;
using SupportApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportApp.Controllers
{
    public class MessageController : Controller
    {
        private readonly MessagesRepository repository;

        public MessageController(MessagesRepository repository)
        {
            this.repository=repository;
        }

        // GET: MessageController
        public ActionResult Index()
        {
            var model = repository.GetAllMessages();
            return View(model);
        }

        // GET: MessageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MessageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Messages messages)
        {
            try
            {
                repository.AddMessages(messages);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MessageController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = repository.GetMessages(id);
            return View(model);
        }

        // POST: MessageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Messages messages)
        {
            try
            {
                repository.UpdateMessages(messages);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MessageController/Delete/5
        public ActionResult Delete(int id)
        {
            repository.DeleteMessages(id);

            return RedirectToAction(nameof(Index));
        }

        // POST: MessageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
