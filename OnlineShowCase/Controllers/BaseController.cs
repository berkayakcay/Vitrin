using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineShowCase.Repository;
using OnlineShowCase.Models;

namespace OnlineShowCase.Controllers
{

    public class BaseController : Controller
    {

        public ShowCaseContext Entity;

        public BaseController()
        {
            Entity = new ShowCaseContext();
            List<Category> categories = Entity.Categories.ToList();
            ViewBag.categories = categories;
            List<MainMenu> mainmenus = Entity.MainMenus.ToList();
            ViewBag.mainmenus = mainmenus;
        }

        #region Alerts
        private void AddAlert(string alertStyle, string message, bool dismissable)
        {
            var alerts = TempData.ContainsKey(Alerts.Alert.TempDataKey)
                ? (List<Alerts.Alert>)TempData[Alerts.Alert.TempDataKey]
                : new List<Alerts.Alert>();
            alerts.Add(new Alerts.Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable
            });

            TempData[Alerts.Alert.TempDataKey] = alerts;
        }

        public void Success(string message, bool dismissable = false)
        {
            AddAlert(Alerts.AlertStyles.Success, message, dismissable);
        }

        public void Information(string message, bool dismissable = false)
        {
            AddAlert(Alerts.AlertStyles.Information, message, dismissable);
        }

        public void Warning(string message, bool dismissable = false)
        {
            AddAlert(Alerts.AlertStyles.Warning, message, dismissable);
        }

        public void Danger(string message, bool dismissable = false)
        {
            AddAlert(Alerts.AlertStyles.Danger, message, dismissable);
        }
        #endregion



        #region Not Found

        #endregion
    }
}