using Microsoft.AspNetCore.Mvc;
using MyPortfolioUdemy.DAL.Context;
using MyPortfolioUdemy.DAL.Entities;

namespace MyPortfolioUdemy.Controllers
{
	public class SkillController : Controller
	{
		MyPortfolioContext portfolioContext = new MyPortfolioContext();
		public IActionResult SkillList()
		{
			var value = portfolioContext.Skills.ToList();
			return View(value);
		}

		[HttpGet]
		public IActionResult CreateSkill() 
		{
			return View();		
		}
		[HttpPost]
		public IActionResult CreateSkill(Skill skill) 
		{ 
			var value = portfolioContext.Skills.Add(skill);
			portfolioContext.SaveChanges();
			return RedirectToAction("SkillList", "Skill");

		}

		public IActionResult DeleteSkill(int id)
		{
			var values = portfolioContext.Skills.Find(id);
			portfolioContext.Skills.Remove(values);
			portfolioContext.SaveChanges();
			return RedirectToAction("SkillList", "Skill");
		}

		[HttpGet]
		public IActionResult UpdateSkill(int id) 
		{
			var value = portfolioContext.Skills.Find(id);
			return View(value);
		}

		[HttpPost]
		public IActionResult UpdateSkill(Skill skill)
		{
			portfolioContext.Skills.Update(skill);
			portfolioContext.SaveChanges();
			return RedirectToAction("SkillList", "Skill");
		}
	}
}
